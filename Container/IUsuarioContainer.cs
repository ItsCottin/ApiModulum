#pragma warning disable CS1591
using ApiModulum.Models;
using ApiModulum.Entity;

namespace ApiModulum.Container;

public interface IUsuarioContainer
{
    Task<List<UsuarioEntity>> GetAll();
    Task<UsuarioEntity> ConsultaUsuario(int id);
    Task<DefaultResponse> ExcluirUsuario(int id);
    Task<DefaultResponse> IncluirUsuario(UsuarioEntity _usuario);
}