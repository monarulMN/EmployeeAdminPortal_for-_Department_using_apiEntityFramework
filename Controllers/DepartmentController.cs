using EmployeeAdminProtal.Data;
using EmployeeAdminProtal.Models;
using EmployeeAdminProtal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminProtal.Controllers
{
    //localhost:xxxx/api/Department
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public DepartmentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            return Ok(dbContext.Departments.ToList());
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult GetDepartmentById(long id)
        {
            var department = dbContext.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDTO addDepartmentDTo)
        {
            var newDepartment = new Department()
            {
                Name = addDepartmentDTo.Name,
                Prefix = addDepartmentDTo.Prefix,
                Description = addDepartmentDTo.Description,
                CreatedOn = DateTime.UtcNow
            };
            dbContext.Departments.Add(newDepartment);
            dbContext.SaveChanges();
            return Ok(newDepartment);
        }
        [HttpPut]
        [Route("{id:long}")]
        public IActionResult UpdateDepartment(long id, UpdateDepartmentDTO updateDepartmentDTO)
        {
            var department = dbContext.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            department.Name = updateDepartmentDTO.Name;
            department.Prefix = updateDepartmentDTO.Prefix;
            department.Description = updateDepartmentDTO.Description;
            department.UpdatedOn = DateTime.UtcNow;
            dbContext.SaveChanges();
            return Ok(department);
        }


        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult DeleteDepartment(long id)
        {
            var department = dbContext.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            dbContext.Departments.Remove(department);
            department.DeletedOn = DateTime.UtcNow;
            department.IsPermanentDeleted = true;
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
