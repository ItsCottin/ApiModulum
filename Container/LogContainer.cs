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

    public async Task<List<ModulumLog>> BuscarTodos()
    {
        List<ModulumLog> logs = new List<ModulumLog>();
        logs = await _dBContext.ModulumLog.ToListAsync();
        if(logs == null)
        {
            logs = new List<ModulumLog>();
        }
        return logs;
    }

    public async Task<bool> Excluir(List<ModulumLog> logs)
    {
        foreach (var item in logs)
        {
            _dBContext.ModulumLog.Remove(item);
        }
        return true;
    }

    public async Task<ModulumLog> Consultar(int id)
    {
        var log = await this._dBContext.ModulumLog.FindAsync(id);
        if (log != null)
        {
            return log;
        }
        else 
        {
            return new ModulumLog();
        }
    }
}