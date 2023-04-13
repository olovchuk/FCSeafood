using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
FCSeafood.WebAPI.Infrastructure.Configuration.ConfigurationService(builder.Services);
FCSeafood.BLL.Infrastructure.Configuration.ConfigurationService(builder.Services, connectionString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

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

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Logging.ClearProviders().AddConsole();
var app = builder.Build();

if (builder.Configuration.GetValue<bool>("AppSettings:UseCORS")) app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();