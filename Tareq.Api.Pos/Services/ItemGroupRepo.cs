using Microsoft.EntityFrameworkCore;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.Services
{
    public class ItemGroupRepo : IItemGroup
    {

        private  TareqDbContext _db;
        public ItemGroupRepo(TareqDbContext db)
        {
            _db = db;
        }


        public void Delete(ItemGroup group)
        {
            _db.Remove(group);
        }

        public List<ItemGroup> Getall()
        {
            return _db.ItemGroup.ToList();
        }

        public ItemGroup GetById(int id)
        {
            return _db.ItemGroup.Where(c => c.GroupId==id).FirstOrDefault();
        }

        public void Insert(ItemGroup group)
        {
            _db.ItemGroup.Add(group);
        }

        public TransactionResult Save()
        {
            return CommonSaveChange.SaveChange(_db);
        }

        public void Update(ItemGroup group)
        {
            _db.Update(group);
        }
    }
}
