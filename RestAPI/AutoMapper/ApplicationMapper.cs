using RestAPI.Models.DTOs.DictadorDto;
using RestAPI.Models.DTOs.UserDto;
using AutoMapper;
using RestAPI.Models.Entity;
using RestAPI.Models.DTOs.UsuarioDTO;
using RestAPI.Models.DTOs.ProductoDTO;
using RestAPI.Models.DTOs.PedidoDTO;

namespace RestAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<DicatadorEntity, DicatadorDto>().ReverseMap();
            CreateMap<DicatadorEntity, CreateDicatadorDto>().ReverseMap();

            CreateMap<UsuarioEntity, UsuarioDto>().ReverseMap();
            CreateMap<UsuarioEntity, CreateUsuarioDto>().ReverseMap();

            CreateMap<ProductoEntity, ProductoDto>().ReverseMap();
            CreateMap<ProductoEntity, CreateProductoDto>().ReverseMap();

            CreateMap<PedidoEntity, PedidoDto>().ReverseMap();
            CreateMap<PedidoEntity, CreatePedidoDto>().ReverseMap();

            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
