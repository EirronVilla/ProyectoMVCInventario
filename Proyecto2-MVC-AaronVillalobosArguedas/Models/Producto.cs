using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto2_MVC_AaronVillalobosArguedas.Models
{
	public class Producto
	{
		/// <summary>
		/// Codigo del producto. Llave primaria.
		/// </summary>
		[Key]
		[StringLength(4)]
		[DisplayName("Código del Producto")]
		public string CodigoProducto { get; set; }

		/// <summary>
		/// Nombre del producto.
		/// </summary>
		[Required]
        [DisplayName("Nombre del Producto")]
        public string NombreProducto { get; set; }

		/// <summary>
		/// Unidad de Medida (g, l, m, u)
		/// </summary>
		[Required]
        [DisplayName("Unidad de Medida")]
        public char UnidadDeMedida { get; set; }

		/// <summary>
		/// Cantidad minima permitida en inventario.
		/// </summary>
		[DisplayName("Cantidad Mínima")]
        public int CantidadMinima { get; set; }

		/// <summary>
		/// Cantidad maxima permitida en inventario.
		/// </summary>
		[DisplayName("Cantidad Máxima")]
        public int CantidadMaxima { get; set; }

		/// <summary>
		/// Cantidad actual en el inventario.
		/// </summary>
		[DisplayName("Cantidad Actual")]

        public int CantidadActual { get; set; }

		/// <summary>
		/// Referencia a los pedidos donde se encuentra el producto.
		/// </summary>

        public ICollection<Pedido> Pedidos { get; } = new List<Pedido>();

		/// <summary>
		/// Referencia a los retiros donde se encuentra el producto.
		/// </summary>
		public ICollection<Retiro> Retiros { get; } = new List<Retiro>();

		/// <summary>
		/// Constructor sin parametros
		/// </summary>
		public Producto()
		{
			CodigoProducto = "";
			NombreProducto = "";
			CantidadMinima = 0;
			CantidadMaxima = 0;
			CantidadActual = 0;
		}

		/// <summary>
		/// Constructor con parametros del producto.
		/// </summary>
		/// <param name="codigoProducto"></param>
		/// <param name="nombreProducto"></param>
		/// <param name="unidadDeMedida"></param>
		/// <param name="cantidadMinima"></param>
		/// <param name="cantidadMaxima"></param>
		/// <param name="cantidadActual"></param>
		/// <param name="pedidos"></param>
		/// <param name="retiros"></param>
		public Producto(
			string codigoProducto, 
			string nombreProducto, 
			char unidadDeMedida, 
			int cantidadMinima, 
			int cantidadMaxima, 
			int cantidadActual, 
			ICollection<Pedido> pedidos, 
			ICollection<Retiro> retiros)
		{
			CodigoProducto = codigoProducto;
			NombreProducto = nombreProducto;
			UnidadDeMedida = unidadDeMedida;
			CantidadMinima = cantidadMinima;
			CantidadMaxima = cantidadMaxima;
			CantidadActual = cantidadActual;
			Pedidos = pedidos;
			Retiros = retiros;
		}
	}
}
