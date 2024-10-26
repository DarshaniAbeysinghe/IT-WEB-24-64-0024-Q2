using Microsoft.AspNetCore.Mvc;
using Manage_Student_Info.Data;
using System.Linq;

namespace Manage_Student_Info.Model
{
    public class StudentController : Controller
    {
        private readonly Manage_Student_InfoContext _context;


        public StudentController(Manage_Student_InfoContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            var students = _context.Add_New_Student_Info.ToList();

            return View(students);
        }
    }
}
