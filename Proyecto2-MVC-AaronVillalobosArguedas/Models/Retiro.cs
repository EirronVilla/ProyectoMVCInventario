using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_MVC_AaronVillalobosArguedas.Models
{
	public class Retiro
	{
		/// <summary>
		/// Llave primaria.
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		/// <summary>
		/// Llave foranea al producto con solicitud de retiro.
		/// </summary>
		public string ProductoId { get; set; }

		/// <summary>
		/// Referencia al producto con solicitud de retiro.
		/// </summary>
		public Producto Producto { get; set; }

		/// <summary>
		/// Fecha en la que se realiza el retiro.
		/// </summary>
		[DisplayName("Fecha de Entrega")]
		public DateTime FechaEntrega { get; set; }

		/// <summary>
		/// Cantidad de producto a retirar por unidad de medida.
		/// </summary>
		[DisplayName("Cantidad")]
		public int CantidadARetirar { get; set; }

		/// <summary>
		/// Constructor por defecto.
		/// </summary>
		public Retiro()
		{
			ProductoId = "";
			Producto = new Producto();
			FechaEntrega = new DateTime();
			CantidadARetirar = -1;
		}

		/// <summary>
		/// Constructor con parametros.
		/// </summary>
		/// <param name="productoId"></param>
		/// <param name="producto"></param>
		/// <param name="fechaEntrega"></param>
		/// <param name="cantidadARetirar"></param>
		public Retiro(string productoId, Producto producto, DateTime fechaEntrega, int cantidadARetirar)
		{
			ProductoId = productoId;
			Producto = producto;
			FechaEntrega = fechaEntrega;
			CantidadARetirar = cantidadARetirar;
		}
	}
}
