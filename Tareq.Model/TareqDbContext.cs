using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareq.Model.Pos;

namespace Tareq.Model
{
    public class TareqDbContext :DbContext
    {
        public TareqDbContext(DbContextOptions<TareqDbContext> options) : base(options)
        {

        }
        public DbSet<ItemMaster> ItemMaster { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<ItemCatagory> ItemCatagory { get; set; }
        public DbSet<ItemGroup> ItemGroup { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<TblRefreshtoken> TblRefreshtoken { get; set; }
    }

}
