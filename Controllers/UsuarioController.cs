using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApiModulum.Container;
using WebApiModulum.Models;
using WebApiModulum.Entity;
using WebApiModulum.Filters;
using Serilog;

namespace WebApiModulum.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private readonly IUsuarioContainer _iUsuarioContainer;
    private readonly ILogger<IUsuarioContainer> _logger;

    public UsuarioController(IUsuarioContainer iUsuarioContainer, ILogger<IUsuarioContainer> logger)
    {
        this._iUsuarioContainer = iUsuarioContainer;
        this._logger = logger;
    }

    [RefreshTokenHeader]
    [Authorize]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var usuario = await this._iUsuarioContainer.GetAll();
        return Ok(usuario);
    }

    [RefreshTokenHeader]
    [Authorize]
    [HttpGet("Consultar/{id}")]
    public async Task<IActionResult> ConsultaUsuarioAsync(int id)
    {
        var usuario = await this._iUsuarioContainer.ConsultaUsuario(id);
        return Ok(usuario);
    }

    [RefreshTokenHeader]
    [Authorize]
    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> ExcluirUsuarioAsync(int id)
    {
        var usuario = await this._iUsuarioContainer.ExcluirUsuario(id);
        return Ok(false);
    }

    [HttpPost("Incluir")]
    public async Task<IActionResult> IncluirUsuarioAsync([FromBody] UsuarioEntity _usuario)
    {
        var usuario = await this._iUsuarioContainer.IncluirUsuario(_usuario);
        return Ok(true);
    }
}
