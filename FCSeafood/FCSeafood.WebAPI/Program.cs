using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
FCSeafood.WebAPI.Infrastructure.Configuration.ConfigurationService(builder.Services);
FCSeafood.BLL.Infrastructure.Configuration.ConfigurationService(builder.Services, connectionString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters() {
                ValidateIssuer = true
              , ValidIssuer = builder.Configuration.GetValue<string>("JWTAuthSetting:AuthIssuer")
              , ValidateAudience = true
              , ValidAudience = builder.Configuration.GetValue<string>("JWTAuthSetting:AuthAudience")
              , ValidateLifetime = true
              , IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWTAuthSetting:AuthSecret")))
              , ValidateIssuerSigningKey = true
            };
        });

if (builder.Configuration.GetValue<bool>("AppSettings:UseCORS"))
    builder.Services.AddCors(options => {
        options.AddDefaultPolicy(policy => {
            policy.WithOrigins(builder.Configuration.GetValue<string>("AppSettings:CORSAllowedHosts").Split(',')).AllowAnyHeader().AllowAnyMethod();
        });
    });

builder.Logging.ClearProviders().AddConsole();
var app = builder.Build();

if (builder.Configuration.GetValue<bool>("AppSettings:UseCORS")) app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();