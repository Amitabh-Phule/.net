using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Exp08.Models;

namespace Exp08.Controllers
{
    // Controller for handling Student CRUD operations
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor to inject the database context
        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Students
        // Reads all students from the database and passes them to the view
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // GET: Students/Create
        // Displays the form to create a new student
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // Saves the new student to the database
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Edit/5
        // Displays the form to edit an existing student
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // Updates the existing student in the database
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        // Displays the confirmation page to delete a student
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        // Deletes the student from the database
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
