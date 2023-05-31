using WebApiModulum.Models;
using WebApiModulum.Entity;

namespace WebApiModulum.Container;

public interface IUsuarioContainer
{
    Task<List<UsuarioEntity>> GetAll();
    Task<UsuarioEntity> ConsultaUsuario(int id);
    Task<bool> ExcluirUsuario(int id);
    Task<bool> IncluirUsuario(UsuarioEntity _usuario);
}