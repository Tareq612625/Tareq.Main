using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tareq.Api.Pos.GraphQLAPI;
using Tareq.Api.Pos.Interface;
using Tareq.Api.Pos.Services;
using Tareq.Model;

namespace Tareq.Api.Pos.ServiceExtension
{
    public static class ServiceExtension
    {
        //repository and database service
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TareqDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddTransient<IItemMaster, ItemMasterRepo>();
            services.AddTransient<IItemCatagory, ItemCatagoryRepo>();
            services.AddTransient<IUnit, UnitRepo>();
            services.AddTransient<IItemGroup, ItemGroupRepo>();
            services.AddTransient<IAccounts, AccountsRepo>();
            services.AddTransient<IRefreshTokenGenerator, RefreshTokenGenerator>();

            return services;
        }
        //JWT authentication and bearar token service
        public static IServiceCollection AddJWTServices(this IServiceCollection services, IConfiguration configuration)
        {
            var _authkey = configuration.GetValue<string>("JwtSettings:securitykey");
            services.AddAuthentication(item =>
            {
                item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(item =>
            {
                item.RequireHttpsMetadata = true;
                item.SaveToken = true;
                item.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;
        }
        //GrapQl Service service
        public static IServiceCollection AddGraphQLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ItemMasterGraphQL>();
            services.AddScoped<ItemMasterQuery>();
            services.AddScoped<ISchema, ItemMasterSchema>();
            services.AddScoped<ItemMasterMutation>();
            services.AddScoped<ItemMasterInput>();

            services.AddGraphQL(opt => opt.EnableMetrics = false).AddSystemTextJson();
            return services;
        }
    }
}
