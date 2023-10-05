using ClientesAPI.Models;

namespace ClientesAPI.Repositories.Contracts
{
    public interface IClienteRepository : IGenericRepository<ClienteModel>
    {
        Task<ClienteModel> GetClienteByCpf(string cpf);
    }
}
