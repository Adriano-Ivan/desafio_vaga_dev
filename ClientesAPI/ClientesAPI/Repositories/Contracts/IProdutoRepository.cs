using ClientesAPI.DTOs.Produto;
using ClientesAPI.Models;

namespace ClientesAPI.Repositories.Contracts
{
    public interface IProdutoRepository : IGenericRepository<ProdutoModel>
    {
       Task<ProdutoModel> ChangeCliente(Guid clientId, Guid produtoId);
       Task<List<ProdutoModel>> GetAllWithClientes();
       Task<List<ProdutoModel>> GetAllProdutosOrderedByCreationWithClientes();
    }
}
