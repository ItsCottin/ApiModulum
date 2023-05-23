using Microsoft.AspNetCore.Mvc;
using WebApiModulum.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApiModulum.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private readonly ModulumContext _DBContext;

    public UsuarioController(ModulumContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var usuario = this._DBContext.Usuario.ToList();
        return Ok(usuario);
    }

    [HttpGet("Consultar/{id}")]
    public IActionResult ConsultaUsuario(int id)
    {
        var usuario = this._DBContext.Usuario.FirstOrDefault(o=>o.Id==id);
        return Ok(usuario);
    }

    [HttpDelete("Excluir/{id}")]
    public IActionResult ExcluirUsuario(int id)
    {
        var usuario = this._DBContext.Usuario.FirstOrDefault(o=>o.Id==id);
        if (usuario != null)
        {
            this._DBContext.Remove(usuario);
            this._DBContext.SaveChanges();
            return Ok(true);
        }
        return Ok(false);
    }

    [HttpPost("Incluir")]
    public IActionResult IncluirUsuario([FromBody] Usuario _usuario)
    {
        var usuario = this._DBContext.Usuario.FirstOrDefault(o=>o.Id==_usuario.Id);
        if (usuario != null)
        {
            usuario.Nome = _usuario.Nome;
            usuario.Login = _usuario.Login;
            usuario.Senha = _usuario.Senha;
            this._DBContext.SaveChanges();
        }
        else
        {
            this._DBContext.Add(_usuario);
            this._DBContext.SaveChanges();
        }
        return Ok(true);
    }
}
