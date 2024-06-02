#pragma warning disable CS1591
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ApiModulum.Models;
using ApiModulum.Container;
using ApiModulum.Entity;

namespace ApiModulum.UsuarioContainer;
public class UsuarioContainer : IUsuarioContainer
{
    private readonly ModulumContext _dBContext;
    private readonly IMapper _imapper;
    public UsuarioContainer (ModulumContext dBContext, IMapper imapper)
    {
        this._dBContext = dBContext;
        this._imapper = imapper;
    }

    public async Task<List<UsuarioEntity>> GetAll()
    {
        List<UsuarioEntity> response = new List<UsuarioEntity>();
        var usuario = await _dBContext.Usuario.ToListAsync();
        if(usuario != null)
        {
            response = _imapper.Map<List<Usuario>, List<UsuarioEntity>>(usuario);
        }
        return response;
    }

    public async Task<UsuarioEntity> ConsultaUsuario(int id)
    {
        var usuario = await _dBContext.Usuario.FindAsync(id);
        if (usuario != null)
        {
            UsuarioEntity response = _imapper.Map<Usuario, UsuarioEntity>(usuario);
            return response;
        }
        else 
        {
            return new UsuarioEntity();
        }
    }

    public async Task<DefaultResponse> ExcluirUsuario(int id)
    {
        var usuario = await _dBContext.Usuario.FindAsync(id);
        if (usuario != null)
        {
            this._dBContext.Remove(usuario);
            await this._dBContext.SaveChangesAsync();
            return GetDefaultResponse("Sucesso", new List<Erro>());
        }
        else 
        {
            return GetDefaultResponse("Erro", new List<Erro>()
            {
                new Erro() 
                {
                    codigo = "", detalhe = "Nenhum usuário encontrado com o id enviado"
                }
            });
        }
    }

    public async Task<DefaultResponse> IncluirUsuario(UsuarioEntity _usuario)
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
            Usuario _usu = _imapper.Map<UsuarioEntity, Usuario>(_usuario);
            this._dBContext.Add(_usu);
            await this._dBContext.SaveChangesAsync();
        }
        return GetDefaultResponse("Sucesso", new List<Erro>());
    }

    public DefaultResponse GetDefaultResponse(String status, List<Erro> erros)
    {
        return new DefaultResponse()
        {
            status = status,
            erros = erros
        };
    }
}