using WebApiModulum.Models;

namespace WebApiModulum.Container;

public interface IUsuarioContainer
{

    Task<List<Usuario>> GetAll();

    Task<Usuario> ConsultaUsuario(int id);

    Task<bool> ExcluirUsuario(int id);

    Task<bool> IncluirUsuario(Usuario _usuario);
}