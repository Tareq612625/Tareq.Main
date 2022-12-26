using Tareq.Model;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.Interface
{
    public interface IUnit
    {
        List<Unit> Getall();
        Unit GetById(int id);
        void Insert(Unit unit);
        void Update(Unit unit);   
        void Delete(Unit unit);
        TransactionResult Save();

    }
}
