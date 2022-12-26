using Microsoft.AspNetCore.Mvc;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;
using Tareq.Utility.Web;

namespace Tareq.Api.Pos.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnit _Unit;
        public UnitController(IUnit Unit)
        {
            _Unit = Unit; 
        }

        [HttpGet]
        public IActionResult Getall()
        {
            if (_Unit.Getall().Count() == 0)
            {
                return NotFound();
            }
            return Ok(_Unit.Getall());
        }
        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {            return Ok(_Unit.GetById(id) == null ? NotFound("No Data Found") : _Unit.GetById(id));
        }
        // POST api/<UnitController>
        [HttpPost]
        public TransactionResult Post(Unit obj)
        {
            obj.CreateDevice = TareqUtility.GetRemoteIPAddress().ipAddress;
            if (ModelState.IsValid)
            {
                _Unit.Insert(obj);
                return _Unit.Save();
            }
            else return null;
        }

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public TransactionResult Put(Unit obj)
        {
            obj.UpdateDevice = TareqUtility.GetRemoteIPAddress().ipAddress;
            _Unit.Update(obj);
            return _Unit.Save();
        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public TransactionResult Delete(Unit obj)
        {
            _Unit.Delete(obj);
            return _Unit.Save();
        }
    }
}
