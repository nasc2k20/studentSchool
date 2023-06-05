using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace schoolStudent.Models
{
	public class studentModel
	{
		public int Id { get; set; }
		[Required]
		[Display(Name = "Codigo de Estudiante")]
		public string StudentCode { get; set; }
		[Required]
		[Display(Name = "Nombre del Estudiante")]
		public string NameStudent { get; set; }
		[Required]
		[Display(Name = "Fecha de Nacimiento del Estudiante")]
		public DateTime BirthDate { get; set; }
		[Required]
		[Display(Name = "Genero del Estudiante")]
		public string Gender { get; set;}
		[Display(Name = "Id Grado")]
		public int GradeId { get; set;}

		[Display(Name = "Comentarios")]
		public string Comments { get; set;}

	}
}