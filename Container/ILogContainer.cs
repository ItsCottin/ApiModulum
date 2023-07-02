#pragma warning disable CS1591
using WebApiModulum.Models;
using WebApiModulum.Entity;
using WebApiModulum.DTO;

namespace WebApiModulum.Container;

public interface ILogContainer
{
    Task<List<ModelLog>> BuscarTodos();
    Task<bool> Excluir(List<ModelLogIdDTO> idlogs);
    Task<ModelLog> Consultar(int id);
}