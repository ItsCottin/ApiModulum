using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApiModulum.Container;
using WebApiModulum.Models;
using WebApiModulum.Entity;
using WebApiModulum.Filters;
using Serilog;

namespace WebApiModulum.Controllers;

[RefreshTokenHeader]
[Authorize(Roles = "ADMIN")]
[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogContainer _iLogContainer;
    private readonly ILogger<ILogContainer> _logger;

    public LogController(ILogContainer iLogContainer, ILogger<ILogContainer> logger)
    {
        this._iLogContainer = iLogContainer;
        this._logger = logger;
    }

    [HttpGet("BuscarTodos")]
    public async Task<IActionResult> BuscarTodosAsync()
    {
        var response = await this._iLogContainer.BuscarTodos();
        return Ok(response);
    }

    [HttpPost("Excluir")]
    public async Task<IActionResult> ExcluirAsync([FromBody] List<ModulumLog> logs)
    {
        var response = await this._iLogContainer.Excluir(logs);
        return Ok(false); 
    }

    [HttpGet("Consultar")]
    public async Task<IActionResult> ConsultarAsync(int id)
    {
        var response = await this._iLogContainer.Consultar(id);
        return Ok(response);
    }
}