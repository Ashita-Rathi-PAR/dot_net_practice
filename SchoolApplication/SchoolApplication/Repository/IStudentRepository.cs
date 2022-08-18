using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
namespace SchoolApplication.Repository
{
    public interface IStudentRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();
        T SelectById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
    }

    public class StudentRepository<T> : IStudentRepository<T> where T : class
    {
        protected readonly StudentContext db;
        public StudentRepository(StudentContext _db)
        {
            db = _db;
        }
        public IEnumerable<T> SelectAll()
        {
            return db.Set<T>().ToList();
        }
        public T SelectById(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void Insert(T obj)
        {
            db.Set<T>().Add(obj);
        }
        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T obj = db.Set<T>().Find(id);
            db.Remove(obj);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
