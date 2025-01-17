using Microsoft.AspNetCore.Mvc;
using CrudOperation.DataAccess;
using CrudOperation.Models;

namespace CrudOperation.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repository;

        public StudentController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is missing.");
            }
            _repository = new StudentRepository(connectionString);
        }

        public IActionResult Index()
        {
            IEnumerable<Student> students = _repository.GetAllStudents();
            return View(students);
        }

        // Create - GET
        [HttpGet]
        public IActionResult Create()
        {
            // Ensure that the model is initialized properly
            return View(new Student());
        }

        // Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student); // Return the student object back to view in case of validation failure
        }

        // Edit - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Details - GET
        public IActionResult Details(int id)
        {
            Student student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // Delete - GET
        public IActionResult Delete(int id)
        {
            Student student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
