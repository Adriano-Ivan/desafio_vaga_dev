using AutoMapper;
using ClientesAPI.Repositories.Contracts;
using ClientesAPI.Data;
using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Repositories
{
    public class ClienteRepository : GenericRepository<ClienteModel>, IClienteRepository
    {
        private readonly ClientesAPIContext _clientesAPIContext;

        public ClienteRepository(ClientesAPIContext clientesAPIContext) : base(clientesAPIContext)
        {
            this._clientesAPIContext = clientesAPIContext;
        }

        public async Task<ClienteModel> GetClienteByCpf(string cpf)
        {
            ClienteModel clienteModel = await _clientesAPIContext.Clientes.FirstOrDefaultAsync(e => e.Cpf.Equals(cpf));
            return clienteModel;
        }
        
        public async Task<List<ClienteModel>> GetAllClientesOrderedByCreation()
        {
            return await _clientesAPIContext.Clientes.OrderByDescending(e => e.CreatedAt).ToListAsync();
        }
    }
}
