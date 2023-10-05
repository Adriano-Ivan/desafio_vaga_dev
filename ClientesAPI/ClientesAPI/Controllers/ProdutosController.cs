using ClientesAPI.DTOs.Cliente;
using ClientesAPI.DTOs.Produto;
using ClientesAPI.Services;
using ClientesAPI.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllProdutos()
        {
            List<ReadProdutoDTO> clientes = await _produtoService.GetProdutos();

            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduto(CreateProdutoDTO createProdutoDTO)
        {
            ReadProdutoDTO produtoCriado = await _produtoService.InsertProduto(createProdutoDTO);

            if (produtoCriado == null)
            {
                return BadRequest("ERROR_INSERTION");
            }

            return Ok(produtoCriado);
        }

        [HttpPut]
        [Route("change-cliente")]
        public async Task<IActionResult> ChangeCliente(ChangeClienteDoProdutoDTO changeClienteDTO)
        {
            ReadProdutoDTO produtoModificado = await _produtoService.ChangeCliente(
                    changeClienteDTO.ClienteId, changeClienteDTO.ProdutoId
                );

            if (produtoModificado == null) return BadRequest("CHANGE_ERROR");

            return Ok(produtoModificado);
        }
    }
}
