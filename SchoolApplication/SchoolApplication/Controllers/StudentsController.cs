using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
using SchoolApplication.Models;
using SchoolApplication.Services;
using SchoolApplication.Repository;

namespace SchoolApplication.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;
        private readonly ILogger<StudentsController> _logger;

        private readonly IStudentService _studentService;

        public StudentsController(StudentContext context, ILogger<StudentsController> logger)
        {
            _context = context;
            _logger = logger;
            _studentService = new StudentService(new StudentRepository<Student>(context));
        }

        public async Task<IActionResult> Index(int? studentClass, string searchString)
        {
            _logger.LogWarning("\n\nWorker running at: {time}", DateTimeOffset.UtcNow);

            //IQueryable<int> classQuery = from m in _context.Student
            //                                orderby m.Class
            //                                select m.Class;
            //var students = from m in _context.Student
            //             select m;

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    students = students.Where(s => s.Name!.Contains(searchString));
            //}

            //if (studentClass!=null)
            //{
            //    students = students.Where(x => x.Class == studentClass);
            //}
            var students = _studentService.filter(searchString, studentClass);
            var classQuery = _studentService.classQueryIndex();
            var classvm = new StudentClassViewModel
            {
                Classes = new SelectList(await classQuery.Distinct().ToListAsync()),
                Students = await students.ToListAsync()
            };
            return View(classvm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            _logger.LogDebug("Log Debug");
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Create()
        {
            _logger.LogCritical("Log Critical");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Class,DateOfBirth,Rating")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Class,DateOfBirth")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Student == null)
            {
                return Problem("Entity set 'StudentContext.Student'  is null.");
            }
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Student?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
