#pragma warning disable CS1591
using AutoMapper;
using ApiModulum.Entity;
using ApiModulum.Models;
using ApiModulum.DTO;

namespace ApiModulum.Handler;

public class AutoMapperHandler : Profile
{
    public AutoMapperHandler()
    {
        // Realiza o Map de um atributo de um Model para outro
        CreateMap<Usuario, UsuarioEntity>()
            .ForMember(item=> item.TpUsuario, opt=> opt.MapFrom(item=> item.TpUsuario == "ADMIN" ? "Administrador" : "Comum"))
            .ForMember(item=> item.Login, opt=> opt.MapFrom(item=> item.Login))
            .ReverseMap();
        
        CreateMap<ModelLog, ModelLogIdDTO>()
            .ForMember(item=> item.Id, opt=> opt.MapFrom(item=> item.Id))
            .ReverseMap();
    }
}