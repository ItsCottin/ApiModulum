using ApiModulum.Models;
using ApiModulum.Handler;
using ApiModulum.Container;
using ApiModulum.UsuarioContainer;
using ApiModulum.Entity;
using ApiModulum.Filters;
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
using ApiModulum.LogContainer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), xmlFile);
    //options.IncludeXmlComments(xmlPath);
    options.SwaggerDoc
    ("v1",
        new OpenApiInfo
        {
            Title = "Documentação Swagger API Modulum",
            Version = "v1",
            Description = "Essa e a documentação swagger da API Modulum utilizando swagger UI com interface do ReDoc",
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

builder.Services.AddDbContext<ModulumContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("constring"));
});

builder.Services.AddScoped<IUsuarioContainer, UsuarioContainer>();
builder.Services.AddScoped<ILogContainer, LogContainer>();
builder.Services.AddScoped<IITokenGenerator, ITokenGenerator>();

var automapper = new MapperConfiguration(item => item.AddProfile
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

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Modulum");
    });

    app.UseReDoc(options =>
    {
        options.DocumentTitle = "Swagger API Modulum Documentacao";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });
//}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
