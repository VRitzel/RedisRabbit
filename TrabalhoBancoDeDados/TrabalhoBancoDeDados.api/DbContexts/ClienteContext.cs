using Microsoft.EntityFrameworkCore;
using TrabalhoBancoDeDados.Entities;

namespace TrabalhoBancoDeDados.Contexts;

public class ClienteContext : DbContext{
    public DbSet<Cliente> Clientes {get; set;}
    public DbSet<Cidade> Cidades {get; set;}

    public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cliente = modelBuilder.Entity<Cliente>();

        var cidade = modelBuilder.Entity<Cidade>();
        
        cidade
            .HasMany(ci => ci.Clientes)
            .WithOne(cl => cl.Cidade)
            .HasForeignKey(cl => cl.CidadeId);

        cidade.Property(ci => ci.Nome)
            .IsRequired()
            .HasMaxLength(60);

        cidade.Property(ci => ci.Uf)
            .IsRequired()
            .HasMaxLength(2);

        cliente.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(60);
        cliente.Property(c => c.Endereco)
            .IsRequired()
            .HasMaxLength(100);
        cliente.Property(c => c.Telefone)
            .IsRequired()
            .HasMaxLength(18);
        
    }
}