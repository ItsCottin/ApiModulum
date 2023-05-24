using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApiModulum.Container;

namespace WebApiModulum.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private readonly IUsuarioContainer _iUsuarioContainer;

    public UsuarioController(IUsuarioContainer iUsuarioContainer)
    {
        this._iUsuarioContainer = iUsuarioContainer;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var usuario = await this._iUsuarioContainer.GetAll();
        return Ok(usuario);
    }

    [HttpGet("Consultar/{id}")]
    public async Task<IActionResult> ConsultaUsuarioAsync(int id)
    {
        var usuario = await this._iUsuarioContainer.ConsultaUsuario(id);
        return Ok(usuario);
    }

    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> ExcluirUsuarioAsync(int id)
    {
        var usuario = await this._iUsuarioContainer.ExcluirUsuario(id);
        return Ok(false);
    }

    [HttpPost("Incluir")]
    public async Task<IActionResult> IncluirUsuarioAsync([FromBody] Usuario _usuario)
    {
        var usuario = await this._iUsuarioContainer.IncluirUsuario(_usuario);
        return Ok(true);
    }
}
