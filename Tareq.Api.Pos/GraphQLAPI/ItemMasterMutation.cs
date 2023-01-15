using GraphQL;
using GraphQL.Types;
using Tareq.Api.Pos.Interface;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.GraphQLAPI
{
    public class ItemMasterMutation : ObjectGraphType
    {
        public ItemMasterMutation(IItemMaster itemMasterCreate)
        {
            //Field<ItemMasterGraphQL>("CreateItemMaster",
            //    arguments: new QueryArguments { new QueryArgument<NonNullGraphType<ItemMasterInput>> { Name:"itemMaster" } },
            //    resolve: x => itemMasterCreate.GrapQlSave(x.GetArgument<ItemMaster>("itemMaster")));

            Field<ItemMasterGraphQL>("createItemMaster",
                 arguments: new QueryArguments(new QueryArgument<ItemMasterInput> { Name = "itemMaster" }),
                 resolve: x => itemMasterCreate.GrapQlSave(x.GetArgument<ItemMaster>("itemMaster")));
        }
    }
}
