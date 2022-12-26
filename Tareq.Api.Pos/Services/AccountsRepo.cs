using Microsoft.EntityFrameworkCore;
using Tareq.Api.Pos.Interface;
using Tareq.Model;
using Tareq.Model.Pos;
using XAct.Users;

namespace Tareq.Api.Pos.Services
{
    public class AccountsRepo : IAccounts
    {

        private TareqDbContext _db;
        public AccountsRepo(TareqDbContext db)
        {
            _db = db;
        }


        public void Delete(AppUser AppUser)
        {
            _db.Remove(AppUser);
        }

        public List<AppUser> Getall()
        {
            return _db.AppUser.ToList();
        }

        public AppUser GetById(string userId)
        {
            return _db.AppUser.Where(c => c.UserId == userId).FirstOrDefault();
        }

        public void Insert(AppUser AppUser)
        {
            _db.AppUser.Add(AppUser);
        }
        public void Update(AppUser AppUser)
        {
            _db.Update(AppUser);
        }
        public TransactionResult Save()
        {
            return CommonSaveChange.SaveChange(_db);          
        }

        public AppUser Login(string UserId, string Password)
        {
            return _db.AppUser.Where(c => c.UserId == UserId && c.Password==Password).FirstOrDefault();
        }
        public TblRefreshtoken TokenCheck(string UserId, string RefreshToken)
        {
            return _db.TblRefreshtoken.Where(c => c.UserId == UserId && c.RefreshToken == RefreshToken).FirstOrDefault();
        }
    }
}
