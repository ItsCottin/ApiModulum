#pragma warning disable CS1591
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApiModulum.Container;
using WebApiModulum.Models;
using WebApiModulum.Entity;
using WebApiModulum.Filters;
using WebApiModulum.DTO;
using Serilog;

namespace WebApiModulum.Controllers;

[ITokenHeader]
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

    /// <summary>
    /// Busca Todos os logs
    /// </summary>
    /// <returns></returns>
    [ITokenHeader]
    [Authorize]
    [HttpGet("BuscarTodos")]
    [Produces("application/json")]
    [RequiredHeader(IsRequired = true)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ModelLog>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(DefaultResponse))]
    public async Task<IActionResult> BuscarTodosAsync()
    {
        var response = await this._iLogContainer.BuscarTodos();
        return Ok(response);
    }

    /// <summary>
    /// Exclui uma lista de Logs
    /// </summary>
    /// <returns></returns>
    [ITokenHeader]
    [Authorize]
    [HttpPost("Excluir")]
    [Produces("application/json")]
    [RequiredHeader(IsRequired = true)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(DefaultResponse))]
    public async Task<IActionResult> ExcluirAsync([FromBody] List<ModelLogIdDTO> idlogs)
    {
        var response = await this._iLogContainer.Excluir(idlogs);
        return Ok(false); 
    }

    /// <summary>
    /// Consulta um Log em especifico
    /// </summary>
    /// <returns></returns>
    [ITokenHeader]
    [Authorize]
    [HttpGet("Consultar")]
    [Produces("application/json")]
    [RequiredHeader(IsRequired = true)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ModelLog))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(DefaultResponse))]
    public async Task<IActionResult> ConsultarAsync(int id)
    {
        var response = await this._iLogContainer.Consultar(id);
        return Ok(response);
    }
}