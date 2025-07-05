using EmployeeDepartment.Data;
using EmployeeDepartment.DTO;
using EmployeeDepartment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet("")]
        public IActionResult Index()
        {
            // manual mapping from database to DTO
            // way1 : for each
            //var categories = context.Categories.ToList();
            //var categoriesDTO = new List<CategoriesDTO>();
            //foreach (var cat in categories)
            //{
            //    categoriesDTO.Add(new CategoriesDTO()
            //    {
            //        Id = cat.Id,
            //        Name = cat.Name
            //    });
            //}

            //way 2 : using select
            var departmentsDTO = context.Departments.Select(department => new DepartmentsDTO
            {
                Id = department.Id,
                Name = department.Name
            });
            return Ok(departmentsDTO);
        }

        //  localhost/api/departments/{id}
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var department = context.Departments.Find(id);
            return Ok(department);
        }

        [HttpPost("add")]
        public IActionResult Create(CreateDepartmentDTO request)
        {

            //manual mapping from dto to domain model
            var category = new Department()
            {
                Name = request.Name
            };
            context.Departments.Add(category);
            context.SaveChanges();

            return Ok();
        }

        [HttpPatch("edit")]
        public IActionResult Edit(Department request, int id)
        {
            var department = context.Departments.Find(id);
            department.Name = request.Name;

            context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return Ok();
        }
    }


}

