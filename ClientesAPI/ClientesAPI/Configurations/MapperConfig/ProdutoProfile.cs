using AutoMapper;
using ClientesAPI.DTOs.Produto;
using ClientesAPI.Models;

namespace ClientesAPI.Configurations.MapperConfig
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDTO, ProdutoModel>().ReverseMap();
            CreateMap<ReadProdutoDTO, ProdutoModel>().ReverseMap();
        }
    }
}
