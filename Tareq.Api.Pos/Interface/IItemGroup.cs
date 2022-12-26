using Tareq.Model;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.Interface
{
    public interface IItemGroup
    {
        List<ItemGroup> Getall();
        ItemGroup GetById(int id);
        void Insert(ItemGroup unit);
        void Update(ItemGroup unit);   
        void Delete(ItemGroup unit);
        TransactionResult Save();

    }
}
