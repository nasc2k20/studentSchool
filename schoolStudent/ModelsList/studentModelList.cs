using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace schoolStudent.ModelsList
{
	public class studentModelList
	{
		public int Id { get; set; }
		public string StudentCode { get; set; }
		public string NameStudent { get; set; }
		public DateTime BirthDate { get; set; }
		public string Gender { get; set; }
		public int GradeId { get; set; }
		public string Comments { get; set; }

	}
}