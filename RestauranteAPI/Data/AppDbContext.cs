using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Models;

namespace RestauranteAPI.Data
{
    public class AppDbContext : DbContext 
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=restaurante.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, name = "Funcionario", email = "funcionario@rest.com", senha = "123456", perfil = "Funcionario" },
                new Usuario { Id = 2, name = "Cozinha", email = "cozinha@rest.com", senha = "123456", perfil = "Cozinha" },
                new Usuario { Id = 3, name = "Copa", email = "copa@rest.com", senha = "123456", perfil = "Copa" }
            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, NomeProduto = "Frango Grelhado", TipoProduto = "Prato", ValorProduto = 28.00 },
                new Produto { Id = 2, NomeProduto = "Filé ao Molho Madeira", TipoProduto = "Prato", ValorProduto = 45.00 },
                new Produto { Id = 3, NomeProduto = "Suco de Laranja", TipoProduto = "Bebida", ValorProduto = 8.00 },
                new Produto { Id = 4, NomeProduto = "Refrigerante Cola", TipoProduto = "Bebida", ValorProduto = 6.00 },
                new Produto { Id = 5, NomeProduto = "Salada Caesar", TipoProduto = "Prato", ValorProduto = 22.00 },
                   new Produto { Id = 6, NomeProduto = "Água Mineral", TipoProduto = "Bebida", ValorProduto = 4.00 }
            );
        }
        

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
      
        public DbSet<ItemPedido> ItemPedidos { get; set; }
    }
}
