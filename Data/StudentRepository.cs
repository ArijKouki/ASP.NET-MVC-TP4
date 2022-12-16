using WebApplication4.Models;

namespace WebApplication4.Data
{
	public class StudentRepository
	{
		public List<Student> all() {
			UniversityContext uc = UniversityContext.Instance;
			var students = uc.Student;
			if(students == null) { return new List<Student>(); }
			else return students.ToList();
		}

		public List<string> UniqueCourses()
		{
            UniversityContext uc = UniversityContext.Instance;
            var students = uc.Student;
			if(students == null) { return new List<string>();}
			else
			{
				List<string> c = new List<string>();
				foreach( Student s in students)
				{
					if(!c.Contains(s.course)) c.Add(s.course);
				}
				return c;
			}
        }

		public List <Student> StudentsByCourse(string course) {

            UniversityContext uc = UniversityContext.Instance;
            var students = uc.Student;

            if (students == null) { return new List<Student>(); }

            else
			{
				List <Student> c = new List<Student>();
				foreach( Student s in students)
				{
					if(s.course==course) c.Add(s);
				}
				return c;
			}
        }





	}
}
