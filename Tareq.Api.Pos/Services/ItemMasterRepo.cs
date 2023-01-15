using Microsoft.EntityFrameworkCore;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.Services
{
    public class ItemMasterRepo : IItemMaster
    {

        private  TareqDbContext _db;
        public ItemMasterRepo(TareqDbContext db)
        {
            _db = db;
        }


        public void Delete(ItemMaster item)
        {
            _db.Remove(item);
        }

        public List<ItemMaster> Getall()
        {
            return _db.ItemMaster.Include(c => c.Units).Include(c=>c.ItemCatagorys).Include(c=>c.ItemGroups).ToList();
        }

        public ItemMaster GetById(int id)
        {
            return _db.ItemMaster.Include(c => c.Units).Include(c => c.ItemCatagorys).Include(c => c.ItemGroups).Where(c => c.ItemId == id).FirstOrDefault();
        }
        //save for Graphql
        public ItemMaster GrapQlSave(ItemMaster item)
        {
            try
            {
                _db.Add(item);
                _db.SaveChanges();
                return item;
            }
            catch (Exception ex) {
                item.ItemName = ex.Message;
                return item;
            }
            
        }

        public void Insert(ItemMaster item)
        {
            _db.ItemMaster.Add(item);
        }

        public TransactionResult Save()
        {
            return CommonSaveChange.SaveChange(_db);
        }

        public void Update(ItemMaster item)
        {
            _db.Update(item);
        }
    }
}
