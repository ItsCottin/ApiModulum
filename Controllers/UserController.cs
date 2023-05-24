using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApiModulum.Container;
using WebApiModulum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace WebApiModulum.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ModulumContext _dbContext;
    private readonly JwtSettings jwtsettings;
    public UserController(ModulumContext dbContext, IOptions<JwtSettings> options)
    {
        this._dbContext = dbContext;
        this.jwtsettings = options.Value;
    }

    [HttpPost("Authenticate")]
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
                new Claim[] {new Claim(ClaimTypes.Name, user.Login)}
            ),
            Expires = DateTime.Now.AddSeconds(20),  // Subir com essa linha descomentada
            //Expires = DateTime.Now.AddHours(3).AddSeconds(20),  // Subir com essa linha comentada.
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenhandler.CreateToken(tokendesc);
        string finaltoken = tokenhandler.WriteToken(token);

        return Ok(finaltoken);
    }
}