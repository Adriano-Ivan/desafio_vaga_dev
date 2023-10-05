using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientesAPI.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> modelBuilder)
        {
            modelBuilder
                .HasIndex(e => e.Cpf)
                .IsUnique();

            modelBuilder
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
