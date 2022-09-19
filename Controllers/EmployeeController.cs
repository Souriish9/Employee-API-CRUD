using EmployeeAPI_CRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EmployeeAPI_CRUD.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class EmployeeController : Controller
    {
        public static List<Employee> employees = new List<Employee>();

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            Employee emp = new Employee();
            emp.Id = 1;
            emp.Name = "Prashant";
            emp.PhoneNumber = "9876543210";
            emp.Department = "Admin";

            employees.Add(emp);
            return Ok(employees);
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        [HttpGet("{Id}")]
        public Employee Get(int Id)
        {
            var res = employees.FirstOrDefault(x => x.Id == Id);
            return res;
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id)
        {
            if(Id<=0)
            {
                return BadRequest("Invalid employee id");
            }

            Employee emp = employees.FirstOrDefault(x => x.Id == Id);
            if(emp==null)
            {
                return NotFound("Invalid employee id");
            }
            emp.Name = "Tanmay";
            emp.Department = "DM";
            return Ok(emp);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            Employee emp = employees.FirstOrDefault(x => x.Id == Id);
            if (emp == null)
            {
                return NotFound();
            }
            employees.RemoveAll(x => x.Id == Id);
            return Ok(emp);
        }
    }
}
