using Microsoft.AspNetCore.Mvc;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;
using Tareq.Utility.Web;

namespace Tareq.Api.Pos.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemCatagoryController : ControllerBase
    {
        private readonly IItemCatagory _ItemCatagory;
        public ItemCatagoryController(IItemCatagory ItemCatagory)
        {
            _ItemCatagory = ItemCatagory; 
        }

        [HttpGet]
        public IActionResult Getall()
        {
            if (_ItemCatagory.Getall().Count() == 0)
            {
                return NotFound();
            }
            return Ok(_ItemCatagory.Getall());
        }
        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_ItemCatagory.GetById(id) == null ? NotFound("No Data Found") : _ItemCatagory.GetById(id));
        }
        // POST api/<UnitController>
        [HttpPost]
        public TransactionResult Post(ItemCatagory obj)
        {
            obj.CreateDevice = TareqUtility.GetRemoteIPAddress().ipAddress;
            if (ModelState.IsValid)
            {
                _ItemCatagory.Insert(obj);
                return _ItemCatagory.Save();
            }
            else return null;
        }

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public TransactionResult Put(ItemCatagory obj)
        {
            obj.UpdateDevice = TareqUtility.GetRemoteIPAddress().ipAddress;
            _ItemCatagory.Update(obj);
            return _ItemCatagory.Save();
        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public TransactionResult Delete(ItemCatagory obj)
        {
            _ItemCatagory.Delete(obj);
            return _ItemCatagory.Save();
        }
    }
}
