using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto2_MVC_AaronVillalobosArguedas.Models;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Proyecto2_MVC_AaronVillalobosArguedas.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{

		public DbSet<Historial>? Historial { get; set; }
		public DbSet<Producto>? Productos { get; set; }
		public DbSet<Retiro>? Retiros { get; set; }
		public DbSet<Pedido>? Pedidos { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Producto>()
				.HasMany(e => e.Pedidos)
				.WithOne(e => e.Producto)
				.HasForeignKey(e => e.ProductoId)
				.IsRequired();

			builder.Entity<Producto>()
				.HasMany(e => e.Retiros)
				.WithOne(e => e.Producto)
				.HasForeignKey(e => e.ProductoId)
				.IsRequired();
		}
	}
}