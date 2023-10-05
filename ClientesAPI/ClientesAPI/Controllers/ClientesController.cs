using ClientesAPI.DTOs.Cliente;
using ClientesAPI.Repositories.Contracts;
using ClientesAPI.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;   

        public ClientesController(IClienteService clienteService)
        {
            this._clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllClientes()
        {
            List<ReadClienteDTO> clientes = await _clienteService.GetClientes();

            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCliente(CreateClienteDTO createClienteDTO)
        {
            if (createClienteDTO != null)
            {
                bool clienteWithCpfAlreadyExists = await _clienteService.ThereIsClientWithCpf(createClienteDTO.Cpf);

                if (clienteWithCpfAlreadyExists || !_clienteService.IsCpfValid(createClienteDTO.Cpf))
                {
                    return BadRequest(clienteWithCpfAlreadyExists ? "DUPLICATE_CPF" : "INVALID_CPF");
                }
            }

            ReadClienteDTO clienteCriado = await _clienteService.InsertCliente(createClienteDTO);
            
            if(clienteCriado == null)
            {
                return BadRequest("ERROR_INSERTION");
            }

            return Ok(clienteCriado);   
        }
    }
}
