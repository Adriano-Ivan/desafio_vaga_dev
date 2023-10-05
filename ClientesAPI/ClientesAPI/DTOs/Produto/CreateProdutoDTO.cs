using System.ComponentModel.DataAnnotations;

namespace ClientesAPI.DTOs.Produto
{
    public class CreateProdutoDTO
    {
        [Required]
        public string Name { get; set; }
        public Guid ClienteId { get; set; }
    }
}
