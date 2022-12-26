using Microsoft.AspNetCore.Mvc;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;
using Tareq.Utility.Web;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XAct.Users;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using XAct;

namespace Tareq.Api.Pos.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class AccountsController : ControllerBase
    {
        private readonly IAccounts _Accounts;
        private readonly IRefreshTokenGenerator _RefreshTokenGenerator;
        private readonly JwtSettings jwtSettings;
        public AccountsController(IAccounts Accounts,IRefreshTokenGenerator RefreshTokenGenerator, IOptions<JwtSettings> options)
        {
            _Accounts = Accounts;
            _RefreshTokenGenerator = RefreshTokenGenerator;
            this.jwtSettings = options.Value;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Getall()
        {
            if (_Accounts.Getall().Count() == 0)
            {
                return NotFound();
            }
            return Ok(_Accounts.Getall());
        }
        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string UserId)
        {
            return Ok(_Accounts.GetById(UserId) == null ? NotFound("No Data Found") : _Accounts.GetById(UserId));
        }
        // POST api/<UnitController>
        [HttpPost]
        public TransactionResult Post(AppUser obj)
        {
            obj.CreateDevice = TareqUtility.GetRemoteIPAddress().ipAddress;
            obj.Password = GetPasswordManage.Encrypt_Password(obj.Password);
            if (ModelState.IsValid)
            {
                _Accounts.Insert(obj);
                return _Accounts.Save();
            }
            else return null;
        }

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public TransactionResult Put(AppUser obj)
        {
            obj.UpdateDevice = TareqUtility.GetRemoteIPAddress().ipAddress;
            _Accounts.Update(obj);
            return _Accounts.Save();
        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public TransactionResult Delete(AppUser obj)
        {
            _Accounts.Delete(obj);
            return _Accounts.Save();
        }
        
        [HttpPost]
        public IActionResult Login(string UserId, string Password)
        {
            TokenResponse tokenResponse = new TokenResponse();

            Password = GetPasswordManage.Encrypt_Password(Password);
            var loginInfo = _Accounts.Login(UserId, Password);
            if (loginInfo == null)
            {
                return Unauthorized();
            }
            else
            {
                /// Generate Token
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
                var tokendesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, loginInfo.UserId) }),
                    Expires = DateTime.Now.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenhandler.CreateToken(tokendesc);
                string finalToken = tokenhandler.WriteToken(token);


                tokenResponse.JWTToken = finalToken;
                tokenResponse.RefreshToken = _RefreshTokenGenerator.GenerateToken(loginInfo.UserId);

                return Ok(tokenResponse);
            }

        }

        [NonAction]
        public TokenResponse Authenticate(string username, Claim[] claims)
        {
            TokenResponse tokenResponse = new TokenResponse();
            var tokenkey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
            var tokenhandler = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                 signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)

                );
            tokenResponse.JWTToken = new JwtSecurityTokenHandler().WriteToken(tokenhandler);
            tokenResponse.RefreshToken = _RefreshTokenGenerator.GenerateToken(username);

            return tokenResponse;
        }

        //[Route("Refresh")]
        [HttpPost]
        public IActionResult Refresh([FromBody] TokenResponse token)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token.JWTToken);
            var username = securityToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;


            //var username = principal.Identity.Name;
            var _reftable = _Accounts.TokenCheck(username, token.RefreshToken);
            if (_reftable == null)
            {
                return Unauthorized();
            }
            TokenResponse _result = Authenticate(username, securityToken.Claims.ToArray());
            return Ok(_result);
        }

    }
}
