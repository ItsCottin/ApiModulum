#pragma warning disable CS1591
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiModulum.Container;
using ApiModulum.Models;
using ApiModulum.Entity;
using ApiModulum.Filters;
using ApiModulum.DTO;
using Serilog;

namespace ApiModulum.Controllers;

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