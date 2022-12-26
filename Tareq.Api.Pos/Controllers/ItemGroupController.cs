using Microsoft.AspNetCore.Mvc;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;
using Tareq.Utility.Web;

namespace Tareq.Api.Pos.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemGroupController : ControllerBase
    {
        private readonly IItemGroup _ItemGroup;
        public ItemGroupController(IItemGroup ItemGroup)
        {
            _ItemGroup = ItemGroup; 
        }

        [HttpGet]
        public IActionResult Getall()
        {
            if (_ItemGroup.Getall().Count() == 0)
            {
                return NotFound();
            }
            return Ok(_ItemGroup.Getall());
        }
        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_ItemGroup.GetById(id) == null ? NotFound("No Data Found") : _ItemGroup.GetById(id));
        }
        // POST api/<UnitController>
        [HttpPost]
        public TransactionResult Post(ItemGroup obj)
        {
            obj.CreateDevice = TareqUtility.GetRemoteIPAddress().ipAddress;
            if (ModelState.IsValid)
            {
                _ItemGroup.Insert(obj);
                return _ItemGroup.Save();
            }
            else return null;
        }

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public TransactionResult Put(ItemGroup obj)
        {
            obj.UpdateDevice = TareqUtility.GetRemoteIPAddress().ipAddress;
            _ItemGroup.Update(obj);
            return _ItemGroup.Save();
        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public TransactionResult Delete(ItemGroup obj)
        {
            _ItemGroup.Delete(obj);
            return _ItemGroup.Save();
        }
    }
}
