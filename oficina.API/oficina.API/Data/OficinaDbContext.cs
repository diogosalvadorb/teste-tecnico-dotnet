using Microsoft.EntityFrameworkCore;
using oficina.API.Models;

namespace oficina.API.Data;

public class OficinaDbContext(DbContextOptions<OficinaDbContext> options) : DbContext(options)
{
    public DbSet<Orcamento> Orcamentos => Set<Orcamento>();
    public DbSet<OrcamentoItem> OrcamentoItens => Set<OrcamentoItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Orcamento>(entity =>
        {
            entity.HasKey(orcamento => orcamento.Id);
            entity.Property(orcamento => orcamento.Total).HasPrecision(18, 2);

            entity.HasMany(orcamento => orcamento.Itens)
                .WithOne(item => item.Orcamento)
                .HasForeignKey(item => item.OrcamentoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OrcamentoItem>(entity =>
        {
            entity.HasKey(item => item.Id);
            entity.Property(item => item.Descricao).HasMaxLength(200).IsRequired();
            entity.Property(item => item.ValorUnitario).HasPrecision(18, 2);
        });
    }
}
