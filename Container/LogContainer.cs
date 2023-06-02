using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApiModulum.Models;
using WebApiModulum.Container;
using WebApiModulum.Entity;

namespace WebApiModulum.LogContainer;

public class LogContainer : ILogContainer
{
    private readonly ModulumContext _dBContext;
    private readonly IMapper _imapper;

    public LogContainer(ModulumContext dBContext, IMapper imapper)
    {
        this._dBContext = dBContext;
        this._imapper = imapper;
    }

    public async Task<List<Log>> BuscarTodos()
    {
        List<Log> logs = new List<Log>();
        logs = await _dBContext.Log.ToListAsync();
        if(logs == null)
        {
            logs = new List<Log>();
        }
        return logs;
    }

    public async Task<List<Log>> Excluir(List<Log> logs)
    {

    }

    public async Task<Log> Consultar(int id)
    {

    }
}