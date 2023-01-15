using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using Tareq.Api.Pos.Interface;
using Tareq.Api.Pos.Services;
using Tareq.Model;
using Tareq.Model.Pos;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using GraphQL.Types;
using Tareq.Api.Pos;
using GraphQL.Server;
using Microsoft.AspNetCore.Mvc;
using Tareq.Api.Pos.ServiceExtension;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//database service
//builder.Services.AddDbContext<TareqDbContext>(options =>
//                options.UseSqlServer(
//                    builder.Configuration.GetConnectionString("DefaultConnection")));

////JWT authentication
//// Adding Authentication

//var _authkey = builder.Configuration.GetValue<string>("JwtSettings:securitykey");
//builder.Services.AddAuthentication(item =>
//{
//    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(item =>
//{
//    item.RequireHttpsMetadata = true;
//    item.SaveToken = true;
//    item.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ClockSkew = TimeSpan.Zero
//    };
//});

//Jwt Service
builder.Services.AddJWTServices(builder.Configuration);
//Repogitory Service
builder.Services.AddDataServices(builder.Configuration);
// register graphQL
builder.Services.AddGraphQLServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Jwt 
var _jwtsettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(_jwtsettings);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//for grapql 
app.UseGraphQLAltair();
//app.UseGraphQL<ISchema>();
app.UseGraphQL<ISchema>("/graphql");
//app.UseEndpoints(endpoint =>
//{
//    endpoint.MapGraphQL();
//});


app.Run();
