using Tareq.Model;
using Tareq.Model.Pos;
using XAct.Library.Settings;

namespace Tareq.Api.Pos.Interface
{
    public interface IAccounts
    {
        List<AppUser> Getall();
        AppUser GetById(string UserId);
        void Insert(AppUser unit);
        void Update(AppUser unit);   
        void Delete(AppUser unit);
        TransactionResult Save();
        AppUser Login(string UserId,string Password);
        public TblRefreshtoken TokenCheck(string UserId, string RefreshToken);
        
    }
}
