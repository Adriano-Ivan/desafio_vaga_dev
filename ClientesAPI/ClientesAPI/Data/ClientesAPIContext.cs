using ClientesAPI.Configurations;
using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Data
{
    public class ClientesAPIContext : DbContext
    {
        public ClientesAPIContext(DbContextOptions<ClientesAPIContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteConfiguration());
            builder.ApplyConfiguration(new ProdutoConfiguration()); 
        }
    }
}
