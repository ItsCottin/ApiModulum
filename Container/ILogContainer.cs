using WebApiModulum.Models;
using WebApiModulum.Entity;

namespace WebApiModulum.Container;

public interface ILogContainer
{
    public async Task<List<Log>> BuscarTodos();
    public async Task<List<Log>> Excluir(List<Log> logs);
    public async Task<Log> Consultar(int id);
}