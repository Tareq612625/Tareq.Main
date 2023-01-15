using GraphQL.Types;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tareq.Model.Pos;

namespace Tareq.Api.Pos.GraphQLAPI
{
    public class ItemMasterGraphQL : ObjectGraphType<ItemMaster>
    {
        public ItemMasterGraphQL()
        {
            Field(x => x.ItemId);
            Field(x => x.ItemName);
            Field(x => x.ItemDescription);
            Field(x => x.UnitId);
            Field(x => x.GroupId);
            Field(x => x.CatagoryId);
            Field(x => x.ItemKeyword);
            Field(x => x.ItemRate);
            Field(x => x.IsActive);
            Field(x => x.ItemImage);
            //Field(x => x.CreateDate);
            //Field(x => x.CreateUser);
            //Field(x => x.UpdateUser);
            ////Field(x => x.UpdateDate);
            //Field(x => x.UpdateDevice);
        }
    }
}