using Microsoft.EntityFrameworkCore;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.Services
{
    public class ItemCatagoryRepo : IItemCatagory
    {

        private  TareqDbContext _db;
        public ItemCatagoryRepo(TareqDbContext db)
        {
            _db = db;
        }


        public void Delete(ItemCatagory catagory)
        {
            _db.Remove(catagory);
        }

        public List<ItemCatagory> Getall()
        {
            return _db.ItemCatagory.ToList();
        }

        public ItemCatagory GetById(int id)
        {
            return _db.ItemCatagory.Where(c => c.CatagoryId==id).FirstOrDefault();
        }

        public void Insert(ItemCatagory catagroy)
        {
            _db.ItemCatagory.Add(catagroy);
        }

        public TransactionResult Save()
        {
            return CommonSaveChange.SaveChange(_db);
        }

        public void Update(ItemCatagory catagory)
        {
            _db.Update(catagory);
        }
    }
}
