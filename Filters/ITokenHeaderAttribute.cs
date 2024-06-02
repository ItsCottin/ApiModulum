#pragma warning disable CS1591
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ApiModulum.Models;
using ApiModulum.Container;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace ApiModulum.Filters;

// Class utilizada para validação dos parâmetros Header em endpoints de programados com a notação '[iTokenHeader]'
public class ITokenHeaderAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.ContainsKey("iToken"))
        {
            context.Result = new BadRequestObjectResult("itoken header is required.");
            return;
        }
        var dbContext = (ModulumContext)context.HttpContext.RequestServices.GetService(typeof(ModulumContext));
        var iToken = context.HttpContext.Request.Headers["iToken"].FirstOrDefault();
        var usuarioId = GetUserIdFromJwt(context.HttpContext);
        if(usuarioId != null)
        {        
            if(usuarioId.Equals(""))
            {
                context.Result = new UnauthorizedResult();
            }
        }
        else
        {
            context.Result = new UnauthorizedResult();
        }
        var responseValidate = ValidateItoken(usuarioId, iToken, dbContext);

        if (!responseValidate)
        {
            context.Result = new UnauthorizedResult();
        }
    }
    private string GetUserIdFromJwt(HttpContext httpContext)
    {
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        var configuration = configBuilder.Build();
        var jwtSecurityKey = configuration.GetValue<string>("JwtSettings:securitykey");
        var tokenjwt = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var tokenkey = Encoding.UTF8.GetBytes(jwtSecurityKey);
        var tokenhandler = new JwtSecurityTokenHandler();

        SecurityToken securityToken; 
        var principal = tokenhandler.ValidateToken(tokenjwt, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(tokenkey),
            ValidateIssuer = false,
            ValidateAudience = false
        }, out securityToken);

        var token = securityToken as JwtSecurityToken;
        if(token != null && !token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
        {
            return "";
        }
        var username = principal.Identity?.Name;
        return username;
    }

    private bool ValidateItoken(string usuarioId, string iToken, ModulumContext _dbContext)
    {
        var response = _dbContext.IToken.FirstOrDefault(item => item.loginUsu == usuarioId && item.iToken == iToken);
        if(response != null)
        {
            int resultado = response.dateValidade.CompareTo(DateTime.Now);
            if (resultado > 0)
            {
                response.dateValidade = DateTime.Now.AddMinutes(10);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                response.isActive = false;
                _dbContext.SaveChanges();
                return false;
            }
        }
        else
        {
            return false;
        }
        
    }
}