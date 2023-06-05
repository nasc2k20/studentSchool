using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using schoolStudent.Models;
using schoolStudent.ModelsList;
using schoolStudent.ModelDataBase;
using Microsoft.EntityFrameworkCore;

namespace schoolStudent.Controllers
{
    public class StudentController : Controller
    {

        public List<Student> listarEstudiantes()
        {
			using (SchoolEntities cnn = new SchoolEntities())
			{
				//var dStudents = cnn.sp_StudentAllData().ToList();
				//return dStudents;

				return cnn.Student.ToList();
			}			
		}

		public Student listarUnEstudiante(int Id)
		{
			using (SchoolEntities cnn = new SchoolEntities())
			{
				var unEstudiante = cnn.sp_StudentOneData(Id).FirstOrDefault();
				return cnn.Student.Find(Id);
			}
		}


		// GET: Student
		public ActionResult Index()
        {
			try
			{
				var estudiantesList = listarEstudiantes();

				return View(estudiantesList);
			}
			catch (Exception)
			{
				throw;
			}
        }

		public ActionResult nuevoEstudiante()
		{
			return View();
		}

		[HttpPost]
		public ActionResult nuevoEstudiante(studentModel stModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using(SchoolEntities cnn = new SchoolEntities())
					{
						var addStudent = cnn.sp_StudentInsert(stModel.StudentCode, stModel.NameStudent,
															stModel.BirthDate, stModel.Gender,
															stModel.GradeId, stModel.Comments);
					}
					return Redirect("~/Student/");
				}
			}
			catch (Exception)
			{
				throw;
			}

			return View(stModel);
		}

		public ActionResult editarEstudiante(int Id)
		{
			studentModel model = new studentModel();

			using (SchoolEntities cnn = new SchoolEntities())
			{
				var objStudent = cnn.Student.Find(Id);
				model.Id= objStudent.Id;
				model.StudentCode = objStudent.StudentCode;
				model.NameStudent = objStudent.NameStudent;
				model.BirthDate = objStudent.BirthDate;
				model.Gender = objStudent.Gender;
				model.GradeId = objStudent.GradeId;
				model.Comments = objStudent.Comments;
			} 

				return View(model);
		}

		[HttpPost]
		public ActionResult editarEstudiante(studentModel stModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (SchoolEntities cnn = new SchoolEntities())
					{
						var dStudent = cnn.sp_StudentUpdate(stModel.Id, stModel.StudentCode, stModel.NameStudent, stModel.BirthDate, stModel.Gender, stModel.Comments);
					}

					return Redirect("~/Student/");
				}
			}
			catch (Exception)
			{

				throw;
			}

			return View(stModel);
		}

		[HttpGet]
		public ActionResult eliminarEstudiante(int Id) {
			using (SchoolEntities cnn = new SchoolEntities())
			{
				var dStudents = cnn.sp_StudentDelete(Id);
			}

			return Redirect("~/Student/");
		}
    }
}