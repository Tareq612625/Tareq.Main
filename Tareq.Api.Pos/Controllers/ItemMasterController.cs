using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.Design;
using System.Dynamic;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;
using Tareq.Utility.Web;

namespace Tareq.Api.Pos.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemMasterController : ControllerBase
    {
        private readonly IItemMaster _itemMaster;
        public ItemMasterController(IItemMaster itemMaster)
        {
            _itemMaster = itemMaster;
        }

        // GET: api/<ItemMasterController>
        [HttpGet]
        public IActionResult Getall()
        {
            if (_itemMaster.Getall().Count() == 0)
            {
                return NotFound();
            }
            return Ok(_itemMaster.Getall());
        }
        // GET api/<ItemMasterController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //////////////////////////////////////////////////////One way////////////////////////
            //dynamic dmItemList= new ExpandoObject();
            //dmItemList.ItemMaster = _itemMaster.GetById(id);
            //if(dmItemList.ItemMaster == null)
            //{
            //    dmItemList.Result = new SelectResult(true, AppEnum.ResultMessage.Found.ToString(), 0) ;
            //}
            //else
            //{
            //    dmItemList.Result = new SelectResult(true,AppEnum.ResultMessage.Notfound.ToString(), 1);
            //}            
            //return Ok(dmItemList);
            ///////////////////////////////////////////////////Another Way///////////////////////
            return Ok(_itemMaster.GetById(id) == null ? NotFound("No Data Found") : _itemMaster.GetById(id));
        }
        // POST api/<ItemMasterController>
        [HttpPost]
        public TransactionResult Post(ItemMaster obj)
        {
            obj.CreateDevice= TareqUtility.GetRemoteIPAddress().ipAddress;
            if (ModelState.IsValid)
            {
                _itemMaster.Insert(obj);
                return _itemMaster.Save();
            }
            else return null;
        }

        // PUT api/<ItemMasterController>/5
        [HttpPut("{id}")]
        public TransactionResult Put(ItemMaster obj)
        {
            obj.UpdateDevice = TareqUtility.GetRemoteIPAddress().ipAddress;
            _itemMaster.Update(obj);
            return _itemMaster.Save();
        }

        // DELETE api/<ItemMasterController>/5
        [HttpDelete("{id}")]
        public TransactionResult Delete(ItemMaster obj)
        {
            _itemMaster.Delete(obj);
            return _itemMaster.Save();
        }
    }
}
