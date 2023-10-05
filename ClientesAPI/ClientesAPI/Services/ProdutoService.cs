using AutoMapper;
using ClientesAPI.DTOs.Cliente;
using ClientesAPI.DTOs.Produto;
using ClientesAPI.Models;
using ClientesAPI.Repositories.Contracts;
using ClientesAPI.Services.Contracts;

namespace ClientesAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            this._produtoRepository = produtoRepository;
            this._clienteRepository = clienteRepository;
            this._mapper = mapper;
        }

        public async Task<ReadProdutoDTO> ChangeCliente(Guid clienteId, Guid produtoId)
        {
            ProdutoModel produtoModel = await _produtoRepository.ChangeCliente(clienteId, produtoId);
            ReadProdutoDTO produtoDTO = _mapper.Map<ReadProdutoDTO>(produtoModel);

            return produtoDTO;
        }

        public async Task<ReadProdutoDTO> GetProduto(Guid produtoId)
        {
            ProdutoModel produtoModel = await _produtoRepository.GetAsync(produtoId);
            ReadProdutoDTO readProdutoDTO = _mapper.Map<ReadProdutoDTO>(produtoModel);

            return readProdutoDTO;
        }

        public async Task<List<ReadProdutoDTO>> GetProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepository.GetAllProdutosOrderedByCreationWithClientes();
            List<ReadProdutoDTO> produtosDTO = _mapper.Map<List<ReadProdutoDTO>>(produtos);

            return produtosDTO;
        }

        public async Task<ReadProdutoDTO> InsertProduto(CreateProdutoDTO createProdutoDTO)
        {
            try
            {
                ProdutoModel produto = _mapper.Map<ProdutoModel>(createProdutoDTO);
                await _produtoRepository.AddAsync(produto);
                ReadProdutoDTO produtoCriado = _mapper.Map<ReadProdutoDTO>(produto);
                return produtoCriado;
            }
            catch
            {
                return null;
            }
        }
    }
}
