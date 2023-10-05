using ClientesAPI.DTOs.Cliente;

namespace ClientesAPI.DTOs.Produto
{
    public class ReadProdutoDTO
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public ReadClienteDTO Cliente { get; set; }
        public Guid ClienteId { get; set; }
    }
}
