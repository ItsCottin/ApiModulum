#pragma warning disable CS1591
using ApiModulum.Models;
using ApiModulum.Entity;
using ApiModulum.DTO;

namespace ApiModulum.Container;

public interface ILogContainer
{
    Task<List<ModelLog>> BuscarTodos();
    Task<bool> Excluir(List<ModelLogIdDTO> idlogs);
    Task<ModelLog> Consultar(int id);
}