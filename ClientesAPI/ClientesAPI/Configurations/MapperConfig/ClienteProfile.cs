using AutoMapper;
using ClientesAPI.DTOs.Cliente;
using ClientesAPI.Models;

namespace ClientesAPI.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDTO, ClienteModel>().ReverseMap();
            CreateMap<ReadClienteDTO, ClienteModel>().ReverseMap();
        }
    }
}
