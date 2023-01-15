using GraphQL.Types;

namespace Tareq.Api.Pos.GraphQLAPI
{
    public class ItemMasterSchema : Schema
    {
        public ItemMasterSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ItemMasterQuery>();
            Mutation = serviceProvider.GetRequiredService<ItemMasterMutation>();

        }
    }
}
