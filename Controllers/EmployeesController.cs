using EmployeeDepartment.Data;
using EmployeeDepartment.DTO;
using EmployeeDepartment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [HttpGet("")]
        public IActionResult Index()
        {
            //mapping from database to DTO
            var employees = context.Employees.ToList();


            var employeesDTO = new List<EmployeesDTO>();
            foreach (var employee in employees)
            {
                employeesDTO.Add(new EmployeesDTO()
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    JobTitle = employee.JobTitle,
                    HireDate = employee.HireDate,
                    Salary = employee.Salary,
                });
            }
            return Ok(employeesDTO);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var employee = context.Employees.Find(id);
            return Ok(employee);
        }

        [HttpPost("add")]
        public IActionResult Create(CreateEmployeeDTO request)
        {

            //manual mapping from dto to domain model
            var employee = new Employee()
            {
              
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                JobTitle = request.JobTitle,
                HireDate = request.HireDate,
                Salary = request.Salary,
            };
            context.Employees.Add(employee);
            context.SaveChanges();

            return Ok();
        }

        [HttpPatch("edit")]
        public IActionResult Edit(Employee request, int id)
        {
            var product = context.Employees.Find(id);
            product.FullName = request.FullName;
            product.Email = request.Email;
            product.JobTitle = request.JobTitle;
            product.HireDate = request.HireDate;
            product.Salary = request.Salary;
            context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return Ok();
        }
    }


}
