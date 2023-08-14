using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_MVC_AaronVillalobosArguedas.Models
{
	public class Historial
	{
		/// <summary>
		/// Llave primaria del registro.
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }


		/// <summary>
		/// Tipo de movimiento.
		/// </summary>
		public string Tipo { get; set; }


		/// <summary>
		/// Mensaje del tipo.
		/// </summary>
		public string Mensaje { get; set; }

		/// <summary>
		/// Fecha en la que se realiza el registro.
		/// </summary>
		public DateTime FechaRegistro { get; set; }


		/// <summary>
		/// Constructor por defecto.
		/// </summary>
		public Historial()
		{
			Tipo = "";
			Mensaje = "";
			FechaRegistro = DateTime.Now;
		}

		/// <summary>
		/// Constructor con parametros.
		/// </summary>
		/// <param name="tipo"></param>
		/// <param name="mensaje"></param>
		/// <param name="fechaRegistro"></param>
		public Historial(string tipo, string mensaje, DateTime fechaRegistro)
		{
			Tipo = tipo;
			Mensaje = mensaje;
			FechaRegistro = fechaRegistro;
		}
	}
}
