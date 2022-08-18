using SchoolApplication.Models;
using SchoolApplication.Repository;
using SchoolApplication.Data;

namespace SchoolApplication.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> filter(string searchString,int? studentClass);
        IEnumerable<int> classQueryIndex();
    }

    public class StudentService : IStudentService
    {

        private IStudentRepository<Student> _studentRepo;
        public StudentService(StudentContext context)
        {
            _studentRepo = new StudentRepository<Student>(context);
        }
        public StudentService(IStudentRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }
        
        public IEnumerable<Student> filter(string searchString, int? studentClass)
        {
            var students = (from m in _studentRepo.SelectAll()
                           select m);

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name!.Contains(searchString));
            }

            if (studentClass != null)
            {
                students = students.Where(x => x.Class == studentClass);
            }

            return students;
        }

        public IEnumerable<int> classQueryIndex()
        {
            IEnumerable<int> classQuery = from m in _studentRepo.SelectAll()
                                         orderby m.Class
                                         select m.Class;
            return classQuery;
        }
    }
}
