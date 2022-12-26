using Tareq.Model;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.Interface
{
    public interface IItemMaster
    {
        List<ItemMaster> Getall();
        ItemMaster GetById(int id);
        void Insert(ItemMaster item);
        void Update(ItemMaster item);   
        void Delete(ItemMaster item);
        TransactionResult Save();

    }
}
