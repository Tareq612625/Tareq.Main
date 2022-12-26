using Microsoft.EntityFrameworkCore;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.Services
{
    public class UnitRepo : IUnit
    {

        private TareqDbContext _db;
        public UnitRepo(TareqDbContext db)
        {
            _db = db;
        }


        public void Delete(Unit unit)
        {
            _db.Remove(unit);
        }

        public List<Unit> Getall()
        {
            return _db.Unit.ToList();
        }

        public Unit GetById(int id)
        {
            return _db.Unit.Where(c => c.UnitId == id).FirstOrDefault();
        }

        public void Insert(Unit unit)
        {
            _db.Unit.Add(unit);
        }
        public void Update(Unit unit)
        {
            _db.Update(unit);
        }
        public TransactionResult Save()
        {
            return CommonSaveChange.SaveChange(_db);          
        }

    }
}
