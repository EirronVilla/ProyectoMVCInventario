using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_MVC_AaronVillalobosArguedas.Models
{
	public class Pedido
	{
		/// <summary>
		/// Llave primaria.
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[DisplayName("Código")]
		public int Id { get; set; }

		/// <summary>
		/// Llave foranea al producto pedido.
		/// </summary>
		[DisplayName("ID del Producto")]
		public string ProductoId { get; set; }

		/// <summary>
		/// Producto solicitado.
		/// </summary> 

		public Producto Producto { get; set; }

		/// <summary>
		/// Cantidad de Producto solicitado en el pedido por unidad de medida
		/// </summary> 
		[DisplayName("Cantidad")]
		public int CantidadDePedido { get; set; }

		/// <summary>
		/// Precio del producto solicitado por unidad de medida
		/// </summary>
		[DisplayName("Precio por Unidad")]
		[Column(TypeName = "decimal(18,4)")]
		public decimal PrecioPorUnidadDeMedida { get; set; }


		/// <summary>
		/// Fecha de entrega del pedido.
		/// </summary>
		[DisplayName("Fecha de Entrega")]
		public DateTime FechaEntrega { get; set; }


		/// <summary>
		/// Persona que realiza la entrega del pedido.
		/// </summary>
		[DisplayName("Entrega")]
		public string PersonaQueEntrega { get; set; }
		
		/// <summary>
		/// Persona que recibe el pedido.
		/// </summary>
		[DisplayName("Recibe")]
		public string PersonaQueRecibe { get; set; }

		/// <summary>
		/// Nombre de la empresa que recibe el pedido.
		/// </summary>
		[DisplayName("Empresa")]
		public string EmpresaQueRecibe { get; set; }

		/// <summary>
		/// Numero de factura del pedido.
		/// </summary>
		[DisplayName("No. de Factura")]
		public int NumeroFactura { get; set; }

		/// <summary>
		/// Determina si el pedido fue entregado al inventario.
		/// </summary>
		public bool Entregado { get; set; } = false;

		public Pedido()
		{
			Producto = new Producto();
			CantidadDePedido = 0;
			PrecioPorUnidadDeMedida = 0;
			FechaEntrega = new DateTime();
			PersonaQueEntrega = "";
			PersonaQueRecibe = "";
			EmpresaQueRecibe = "";
			NumeroFactura = -1;
		}



		/// <summary>
		/// Constructor con parametros de la clase pedido.
		/// </summary>
		/// <param name="productoPedido"></param>
		/// <param name="cantidadDePedido"></param>
		/// <param name="precioPorUnidadDeMedida"></param>
		/// <param name="fechaEntrega"></param>
		/// <param name="personaQueEntrega"></param>
		/// <param name="personaQueRecibe"></param>
		/// <param name="empresaQueRecibe"></param>
		/// <param name="numeroFactura"></param>
		public Pedido(
			string poductoPedidoId,
			Producto productoPedido, 
			int cantidadDePedido, 
			decimal precioPorUnidadDeMedida, 
			DateTime fechaEntrega, 
			string personaQueEntrega, 
			string personaQueRecibe, 
			string empresaQueRecibe, 
			int numeroFactura)
		{
			ProductoId	= poductoPedidoId;
			Producto = productoPedido;
			CantidadDePedido = cantidadDePedido;
			PrecioPorUnidadDeMedida = precioPorUnidadDeMedida;
			FechaEntrega = fechaEntrega;
			PersonaQueEntrega = personaQueEntrega;
			PersonaQueRecibe = personaQueRecibe;
			EmpresaQueRecibe = empresaQueRecibe;
			NumeroFactura = numeroFactura;
		}
	}
}
