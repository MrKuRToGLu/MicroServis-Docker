using Ocelot.DependencyInjection; // AddOcelot
using Ocelot.Middleware; // UseOcelot();
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(c =>
{
    c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "JwtTokenServerApplication.com",
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("benbuservisinsecuritykeyiyim")),
        ClockSkew = TimeSpan.Zero
    };
}); //client'In gönderdiði tokenýn doðrulanmasý...

builder.Configuration.AddJsonFile("Ocelot.json"); // ocelot configurasyonu eklenir...
builder.Services.AddOcelot();

// Add services to the container.

var app = builder.Build();

app.UseOcelot();
// Configure the HTTP request pipeline.

app.Run();
