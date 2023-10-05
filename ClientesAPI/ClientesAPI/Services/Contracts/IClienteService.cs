using ClientesAPI.DTOs.Cliente;

namespace ClientesAPI.Services.Contracts
{
    public interface IClienteService
    {
        Task<List<ReadClienteDTO>> GetClientes();
        Task<ReadClienteDTO> GetCliente(Guid clienteId);
        Task<ReadClienteDTO> InsertCliente(CreateClienteDTO createCliente);
        Task<bool> ThereIsClientWithCpf(string cpf);
        bool IsCpfValid(string cpf);
    }
}
