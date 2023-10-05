using AutoMapper;
using ClientesAPI.DTOs.Cliente;
using ClientesAPI.Models;
using ClientesAPI.Repositories.Contracts;
using ClientesAPI.Services.Contracts;
using ClientesAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly CpfValidator _cpfValidator;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            this._clienteRepository = clienteRepository;
            this._mapper = mapper;
            _cpfValidator = new CpfValidator();
        }

        public async Task<ReadClienteDTO> GetCliente(Guid clienteId)
        {
            ClienteModel clienteModel = await _clienteRepository.GetAsync(clienteId);
            ReadClienteDTO readClienteDTO = _mapper.Map<ReadClienteDTO>(clienteModel);

            return readClienteDTO;
        }

        public async Task<List<ReadClienteDTO>> GetClientes()
        {
            List<ClienteModel> clientes = await _clienteRepository.GetAllClientesOrderedByCreation();
            List<ReadClienteDTO> clientesDTO = _mapper.Map<List<ReadClienteDTO>>(clientes);

            return clientesDTO;
        }

        public async Task<ReadClienteDTO> InsertCliente(CreateClienteDTO createCliente)
        {
            try
            {
                ClienteModel cliente = _mapper.Map<ClienteModel>(createCliente);
                await _clienteRepository.AddAsync(cliente);
                ReadClienteDTO clienteCriado = _mapper.Map<ReadClienteDTO>(cliente);     
                return clienteCriado;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<bool> ThereIsClientWithCpf(string cpf)
        {
            ClienteModel clienteModel = await _clienteRepository.GetClienteByCpf(cpf);
            return clienteModel != null ? true : false;
        }

        public bool IsCpfValid(string cpf)
        {
            return _cpfValidator.IsValid(cpf);
        }
    }
}
