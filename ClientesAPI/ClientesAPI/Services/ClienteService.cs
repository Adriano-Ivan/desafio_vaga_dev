using AutoMapper;
using ClientesAPI.DTOs.Cliente;
using ClientesAPI.Models;
using ClientesAPI.Repositories.Contracts;
using ClientesAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            this._clienteRepository = clienteRepository;
            this._mapper = mapper;
        }

        public async Task<ReadClienteDTO> GetCliente(Guid clienteId)
        {
            ClienteModel clienteModel = await _clienteRepository.GetAsync(clienteId);
            ReadClienteDTO readClienteDTO = _mapper.Map<ReadClienteDTO>(clienteModel);

            return readClienteDTO;
        }

        public async Task<List<ReadClienteDTO>> GetClientes()
        {
            List<ClienteModel> clientes = await _clienteRepository.GetAllAsync();
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
            // Remove caracteres não numéricos do CPF.
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF possui 11 dígitos.
            if (cpf.Length != 11)
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais.
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            // Calcula o primeiro dígito verificador.
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int firstDigit = 11 - (sum % 11);

            if (firstDigit >= 10)
            {
                firstDigit = 0;
            }

            // Calcula o segundo dígito verificador.
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            int secondDigit = 11 - (sum % 11);

            if (secondDigit >= 10)
            {
                secondDigit = 0;
            }

            // Verifica se os dígitos verificadores são iguais aos dígitos originais.
            if (cpf[9] - '0' == firstDigit && cpf[10] - '0' == secondDigit)
            {
                return true;
            }

            return false;
        }
    }
}
