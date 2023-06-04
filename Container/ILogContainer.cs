using WebApiModulum.Models;
using WebApiModulum.Entity;

namespace WebApiModulum.Container;

public interface ILogContainer
{
    Task<List<ModulumLog>> BuscarTodos();
    Task<bool> Excluir(List<ModulumLog> logs);
    Task<ModulumLog> Consultar(int id);
}