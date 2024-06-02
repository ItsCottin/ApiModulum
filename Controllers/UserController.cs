#pragma warning disable CS1591
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiModulum.Container;
using ApiModulum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using ApiModulum.Handler;
using ApiModulum.Filters;

namespace ApiModulum.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ModulumContext _dbContext;
    private readonly JwtSettings jwtsettings;
    private readonly IITokenGenerator iTokenGenerator;

    [NonAction]
    public DateTime getDateNow()
    {
        return DateTime.Now.AddHours(3).AddSeconds(20);     // Comentar essa linha antes de subir o fonte
        //return DateTime.Now.AddSeconds(20);
    }
    public UserController(ModulumContext dbContext, IOptions<JwtSettings> options, IITokenGenerator refresh)
    {
        this._dbContext = dbContext;
        this.jwtsettings = options.Value;
        this.iTokenGenerator = refresh;
    }

    [NonAction]
    public async Task<TokenResponse> tokenAuthenticate(string user, Claim[] claims)
    {
        var token = new JwtSecurityToken
        (
            claims:claims, 
            expires:getDateNow(),
            signingCredentials: new SigningCredentials
            (
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsettings.securitykey)),
                SecurityAlgorithms.HmacSha256
            )
        );
        var jwttoken = new JwtSecurityTokenHandler().WriteToken(token);
        return new TokenResponse()
        {
            jwttoken = jwttoken,
            iToken = await iTokenGenerator.GenerateToken(user)
        };
    }

    /// <summary>
    /// Autenticação do Usuário
    /// </summary>
    /// <returns></returns>
    [HttpPost("Authenticate")]
    [Produces("application/json")]
    [RequiredHeader(IsRequired = false)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(DefaultResponse))]
    public async Task<IActionResult> Authenticate([FromBody]UserCred userCred)
    {
        var user = await this._dbContext.Usuario.FirstOrDefaultAsync(item=> item.Login == userCred.username && item.Senha == userCred.password);
        if(user == null)
        {
            return Unauthorized();
        }
        var tokenhandler = new JwtSecurityTokenHandler();
        var tokenkey = Encoding.UTF8.GetBytes(this.jwtsettings.securitykey);
        var tokendesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity
            (
                new Claim[] {new Claim(ClaimTypes.Name, user.Login), new Claim(ClaimTypes.Role, user.TpUsuario)}
            ),
            Expires = getDateNow(),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenhandler.CreateToken(tokendesc);
        string finaltoken = tokenhandler.WriteToken(token);

        var response = new TokenResponse()
        {
            jwttoken = finaltoken,
            iToken = await iTokenGenerator.GenerateToken(userCred.username)
        };

        return Ok(response);
    }

    /// <summary>
    /// Refresh da expiração do iToken
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpPost("RefreshIToken")]
    [Produces("application/json")]
    [RequiredHeader(IsRequired = true)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(DefaultResponse))]
    public async Task<IActionResult> RefreshIToken([FromBody]TokenResponse tokenResponse)
    {
        var tokenhandler = new JwtSecurityTokenHandler();
        var tokenkey = Encoding.UTF8.GetBytes(this.jwtsettings.securitykey);
        SecurityToken securityToken; 
        var principal = tokenhandler.ValidateToken(tokenResponse.jwttoken, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(tokenkey),
            ValidateIssuer = false,
            ValidateAudience = false
        }, out securityToken);

        var token = securityToken as JwtSecurityToken;
        if(token != null && !token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
        {
            return Unauthorized();
        }
        var username = principal.Identity?.Name;
        var user = await this._dbContext.IToken.FirstOrDefaultAsync(item=> item.loginUsu == username && item.iToken == tokenResponse.iToken);
        if(user == null)
        {
            return Unauthorized();
        }
        var response = tokenAuthenticate(username, principal.Claims.ToArray()).Result;

        return Ok(response);
    }
}