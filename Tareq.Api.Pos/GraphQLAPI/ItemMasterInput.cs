using GraphQL.Types;

namespace Tareq.Api.Pos.GraphQLAPI
{
    public class ItemMasterInput:InputObjectGraphType
    {
        public ItemMasterInput() {
            Field<IntGraphType>("itemId");
            Field<StringGraphType>("itemName");
            Field<StringGraphType>("itemDescription");
            Field<IntGraphType>("catagoryId");
            Field<IntGraphType>("unitId");
            Field<IntGraphType>("groupId");
            Field<StringGraphType>("itemKeyword");
            Field<DecimalGraphType>("itemRate");
            Field<StringGraphType>("itemImage");
            Field<StringGraphType>("isActive");
        }
    }
}
