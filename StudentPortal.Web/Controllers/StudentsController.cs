using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entiites;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbcontext;

        public StudentsController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,
            };
            await dbcontext.Students.AddAsync(student);
            await dbcontext.SaveChangesAsync();
            return View();
        }
    }
}
