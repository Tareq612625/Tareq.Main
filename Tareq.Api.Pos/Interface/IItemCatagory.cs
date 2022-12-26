using Tareq.Model;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.Interface
{
    public interface IItemCatagory
    {
        List<ItemCatagory> Getall();
        ItemCatagory GetById(int id);
        void Insert(ItemCatagory catagory);
        void Update(ItemCatagory catagory);   
        void Delete(ItemCatagory catagory);
        TransactionResult Save();

    }
}
