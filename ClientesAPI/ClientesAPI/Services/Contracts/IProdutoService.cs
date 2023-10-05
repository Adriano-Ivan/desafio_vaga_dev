using ClientesAPI.DTOs.Produto;

namespace ClientesAPI.Services.Contracts
{
    public interface IProdutoService
    {
        Task<List<ReadProdutoDTO>> GetProdutos();
        Task<ReadProdutoDTO> GetProduto(Guid id);
        Task<ReadProdutoDTO> InsertProduto(CreateProdutoDTO createProdutoDTO);
        Task<ReadProdutoDTO> ChangeCliente(Guid clienteId, Guid produtoId);

    }
}
