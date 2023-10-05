using ClientesAPI.Repositories.Contracts;
using ClientesAPI.Data;
using ClientesAPI.Models;
using ClientesAPI.DTOs.Produto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Repositories
{
    public class ProdutoRepository : GenericRepository<ProdutoModel>, IProdutoRepository
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ClientesAPIContext _clientesAPIContext;

        public ProdutoRepository(ClientesAPIContext clientesAPIContext, IClienteRepository clienteRepository,
            IMapper mapper) : base(clientesAPIContext)
        {
            this._clienteRepository = clienteRepository;
            this._clientesAPIContext = clientesAPIContext;
        }

        public async Task<ProdutoModel> ChangeCliente(Guid clientId, Guid produtoId)
        {
            var cliente = await _clienteRepository.GetAsync(clientId);
            var produto = await this.GetAsync(produtoId);

            if(cliente == null || produto == null)
            {
                return null;
            }

            produto.ClienteId = clientId;

            await _clientesAPIContext.SaveChangesAsync();

            return produto;
        }

        public async Task<List<ProdutoModel>> GetAllProdutosOrderedByCreationWithClientes()
        {
            return await _clientesAPIContext.Produtos.Include(e => e.Cliente).OrderByDescending(e => e.CreatedAt).ToListAsync();
        }

        public async Task<List<ProdutoModel>> GetAllWithClientes()
        {
            return await _clientesAPIContext.Produtos.Include(e => e.Cliente).ToListAsync();
        }
    }
}
