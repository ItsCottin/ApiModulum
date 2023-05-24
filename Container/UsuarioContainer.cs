using Microsoft.EntityFrameworkCore;
using WebApiModulum.Models;
using WebApiModulum.Container;

namespace WebApiModulum.UsuarioContainer;
public class UsuarioContainer : IUsuarioContainer
{
    private readonly ModulumContext _dBContext;
    public UsuarioContainer (ModulumContext dBContext)
    {
        this._dBContext = dBContext;
    }

    public async Task<List<Usuario>> GetAll()
    {
        return await _dBContext.Usuario.ToListAsync();
    }

    public async Task<Usuario> ConsultaUsuario(int id)
    {
        var usuario = await _dBContext.Usuario.FindAsync(id);
        if (usuario != null)
        {
            return usuario;
        }
        else 
        {
            return new Usuario();
        }
    }

    public async Task<bool> ExcluirUsuario(int id)
    {
        var usuario = await _dBContext.Usuario.FindAsync(id);
        if (usuario != null)
        {
            this._dBContext.Remove(usuario);
            await this._dBContext.SaveChangesAsync();
            return true;
        }
        else 
        {
            return false;
        }
    }

    public async Task<bool> IncluirUsuario(Usuario _usuario)
    {
        var usuario = this._dBContext.Usuario.FirstOrDefault(o => o.Id == _usuario.Id);
        if (usuario != null)
        {
            usuario.Nome = _usuario.Nome;
            usuario.Login = _usuario.Login;
            usuario.Senha = _usuario.Senha;
            await this._dBContext.SaveChangesAsync();
        }
        else
        {
            this._dBContext.Add(_usuario);
            await this._dBContext.SaveChangesAsync();
        }
        return true;
    }
}