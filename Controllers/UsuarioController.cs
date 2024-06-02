#pragma warning disable CS1591
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using ApiModulum.Container;
using ApiModulum.Models;
using ApiModulum.Entity;
using ApiModulum.Filters;
using Serilog;

namespace ApiModulum.Controllers;

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

    /// <summary>
    /// Busca Todos usuários registrados.
    /// </summary>
    /// <returns>A newly created TodoItem</returns>
    /// <response code="200">Retorna todos os Usuarios em forma de Lista</response>
    /// <response code="400">Quando ocorre erro por algum motivo</response>
    [Authorize]
    [HttpGet("GetAll")]
    [Produces("application/json")]
    [RequiredHeader(IsRequired = true)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Usuario>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
    public async Task<IActionResult> GetAllAsync()
    {
        var usuario = await this._iUsuarioContainer.GetAll();
        return Ok(usuario);
    }

    /// <summary>
    /// Realiza Consulta de Apenas um Usuario por Id
    /// </summary>
    /// <returns>A newly created TodoItem</returns>
    /// <response code="200">Retorna um objeto do tipo Usuario</response>
    /// <response code="400">Quando ocorre erro por algum motivo</response>
    [Authorize]
    [HttpGet("Consultar/{id}")]
    [Produces("application/json")]
    [RequiredHeader(IsRequired = true)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
    public async Task<IActionResult> ConsultaUsuarioAsync(int id)
    {
        var usuario = await this._iUsuarioContainer.ConsultaUsuario(id);
        return Ok(usuario);
    }

    /// <summary>
    /// Deleta um usuário especifico.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("Excluir/{id}")]
    [Produces("application/json")]
    [RequiredHeader(IsRequired = true)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
    public async Task<IActionResult> ExcluirUsuarioAsync(int id)
    {
        var response = await this._iUsuarioContainer.ExcluirUsuario(id);
        return Ok(response);
    }


    /// <summary>
    /// Inclui usuário.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Request Simples:
    ///
    ///     POST /Usuario/Incluir/
    ///     {
    ///         "nome": "string",
    ///         "login": "string",
    ///         "senha": "string",
    ///         "email": "string"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Retorna todos os Usuarios em forma de Lista</response>
    /// <response code="400">Quando ocorre erro por algum motivo</response> 
    [HttpPost("Incluir")]
    [Produces("application/json")]
    [RequiredHeader(IsRequired = false)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
    public async Task<IActionResult> IncluirUsuarioAsync([FromBody] UsuarioEntity _usuario)
    {
        var response = await this._iUsuarioContainer.IncluirUsuario(_usuario);
        return Ok(response);
    }
}
