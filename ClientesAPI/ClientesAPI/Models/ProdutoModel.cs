namespace ClientesAPI.Models
{
    public class ProdutoModel : BaseModel
    {
        public string Name { get; set; }
        public ClienteModel Cliente { get; set; }
        public Guid ClienteId { get; set; }
    }
}
