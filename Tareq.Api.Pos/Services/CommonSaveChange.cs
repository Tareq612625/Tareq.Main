using Microsoft.EntityFrameworkCore;
using Tareq.Model;

namespace Tareq.Api.Pos.Services
{
    public static class CommonSaveChange
    {
        public static TransactionResult SaveChange(DbContext _db)
        {
            TransactionResult obj = new TransactionResult();
            try
            {
                _db.Database.BeginTransaction();
                obj.Rows = _db.SaveChanges();
                obj.Success = true;
                obj.Message = "Successfull";
                _db.Database.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                obj.Success = false;
                obj.Message = ex.Message;
                obj.Rows = 0;
                _db.Database.RollbackTransaction();
                return (obj);
            }
        }

    }
}
