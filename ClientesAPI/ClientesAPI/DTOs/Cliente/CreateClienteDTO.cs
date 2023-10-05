using System.ComponentModel.DataAnnotations;

namespace ClientesAPI.DTOs.Cliente
{
    public class CreateClienteDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cpf { get; set; }
    }
}
