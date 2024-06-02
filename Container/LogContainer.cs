#pragma warning disable CS1591
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ApiModulum.Models;
using ApiModulum.Container;
using ApiModulum.Entity;
using ApiModulum.DTO;

namespace ApiModulum.LogContainer;

public class LogContainer : ILogContainer
{
    private readonly ModulumContext _dBContext;
    private readonly IMapper _imapper;

    public LogContainer(ModulumContext dBContext, IMapper imapper)
    {
        this._dBContext = dBContext;
        this._imapper = imapper;
    }

    public async Task<List<ModelLog>> BuscarTodos()
    {
        List<ModelLog> logs = new List<ModelLog>();
        logs = await _dBContext.ModelLog.ToListAsync();
        if(logs == null)
        {
            logs = new List<ModelLog>();
        }
        return logs;
    }

    public async Task<bool> Excluir(List<ModelLogIdDTO> idlogs)
    {
        foreach (var idDto in idlogs)
        {
            var log = _imapper.Map<ModelLog>(idDto);
            _dBContext.ModelLog.Attach(log);
            _dBContext.ModelLog.Remove(log);
        }

        await _dBContext.SaveChangesAsync();
        return true;
    }

    public async Task<ModelLog> Consultar(int id)
    {
        var log = await this._dBContext.ModelLog.FindAsync(id);
        if (log != null)
        {
            return log;
        }
        else 
        {
            return new ModelLog();
        }
    }
}