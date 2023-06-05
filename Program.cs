using WebApiModulum.Models;
using WebApiModulum.Handler;
using WebApiModulum.Container;
using WebApiModulum.UsuarioContainer;
using WebApiModulum.Entity;
using WebApiModulum.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System.Text;
using AutoMapper;
using Serilog;
using Swashbuckle.AspNetCore.ReDoc;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using WebApiModulum.LogContainer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc
    ("v1",
        new OpenApiInfo
        {
            Title = "Swagger Web API Modulum Documentacao",
            Version = "v1",
            Description = "Essa e a documentacao swagger da API Web Modulum utilizando swagger UI com interface do ReDoc",
            Contact = new OpenApiContact
            {
                Name = "Rodrigo Cotting Fontes",
                Email = "cottingfontes@hotmail.com"
            }
        }
    );
    options.OperationFilter<AddRequiredHeaderParameter>();
});

var _authkey = builder.Configuration.GetValue<string>("JwtSettings:securitykey");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddDbContext<ModulumContext>(options=>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("constring"));
});

builder.Services.AddScoped<IUsuarioContainer, UsuarioContainer>();
builder.Services.AddScoped<ILogContainer, LogContainer>();
builder.Services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();

var automapper = new MapperConfiguration(item=> item.AddProfile
    (
        new AutoMapperHandler()
    )
);
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

var _logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.AddSerilog(_logger);

var _jwtsettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(_jwtsettings);

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API Modulum");
});

app.UseReDoc(options =>
{
    options.DocumentTitle = "Swagger Web API Modulum Documentacao";
    options.SpecUrl = "/swagger/v1/swagger.json";
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();