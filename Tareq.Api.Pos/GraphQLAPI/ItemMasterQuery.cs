using GraphQL;
using GraphQL.Types;
using Tareq.Api.Pos.Interface;

namespace Tareq.Api.Pos.GraphQLAPI
{
    public class ItemMasterQuery : ObjectGraphType
    {
        public ItemMasterQuery(IItemMaster itemMasterProvider)
        {
            Field<ListGraphType<ItemMasterGraphQL>>(Name = "ItemMaster", resolve: x => itemMasterProvider.Getall());
            Field<ItemMasterGraphQL>(Name = "ItemMasterById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: x => itemMasterProvider.Getall().FirstOrDefault(p => p.ItemId == x.GetArgument<int>("id")));
        }
    }
}
