using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;
using WebApplication4.Data;

namespace WebApplication4.Controllers
{
	public class StudentController : Controller
	{
		private readonly ILogger<StudentController> _logger;

		public StudentController(ILogger<StudentController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			
			/*Debug.WriteLine("Here" + UniversityContext.Instance);
			Debug.WriteLine("Here" + UniversityContext.Instance);

			List<Student> s = UniversityContext.Instance.Student.ToList();
			Debug.WriteLine(s.Count);*/

			StudentRepository studentRepository = new StudentRepository();
			List<Student> l = studentRepository.all();
			ViewData["studentsList"] = l;

			return View();
		}

		public IActionResult Courses()
		{
            StudentRepository studentRepository = new StudentRepository();
			List<string> l = studentRepository.UniqueCourses();
            ViewData["CoursesList"] = l;
			return View();
		}

        public IActionResult ByCourse(string course)
        {
            StudentRepository studentRepository = new StudentRepository();
            List<Student> l = studentRepository.StudentsByCourse(course);
			ViewData["course"] = course;
            ViewData["StudentsList"] = l;
            return View();
        }

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}