using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientesAPI.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> modelBuilder)
        {
            modelBuilder
                 .Property(e => e.CreatedAt)
                 .HasDefaultValueSql("GETDATE()");
        }
    }
}
