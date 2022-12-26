using Microsoft.Identity.Client;
using System.Security.Cryptography;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;
using XAct;

namespace Tareq.Api.Pos.Services
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        private TareqDbContext _db;
        public RefreshTokenGenerator(TareqDbContext db)
        {
            _db = db;
        }

        public string GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using (var randomnumbergenerator = RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string RefreshToken = Convert.ToBase64String(randomnumber);

                var _user = _db.TblRefreshtoken.FirstOrDefault(o => o.UserId == username);
                if (_user != null)
                {
                    _user.RefreshToken = RefreshToken;
                    _db.SaveChanges();
                }
                else
                {
                    TblRefreshtoken tblRefreshtoken = new TblRefreshtoken()
                    {
                        UserId = username,
                        TokenId = new Random().Next().ToString(),
                        RefreshToken = RefreshToken,
                        IsActive = 1
                    };
                    _db.Add(tblRefreshtoken);
                    _db.SaveChanges(true);
                }

                return RefreshToken;
            }
        }
    }
}
