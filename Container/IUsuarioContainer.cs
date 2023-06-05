using WebApiModulum.Models;
using WebApiModulum.Entity;

namespace WebApiModulum.Container;

public interface IUsuarioContainer
{
    Task<List<UsuarioEntity>> GetAll();
    Task<UsuarioEntity> ConsultaUsuario(int id);
    Task<DefaultResponse> ExcluirUsuario(int id);
    Task<DefaultResponse> IncluirUsuario(UsuarioEntity _usuario);
}