using EmployeeAdminProtal.Data;
using EmployeeAdminProtal.Models;
using EmployeeAdminProtal.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminProtal.Controllers
{
    //localhost:xxxx/api/Department
    [Route("api/[controller]/[action]")]
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
            List<DepartmentDTO> result = dbContext.Departments.Select(x=> new DepartmentDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Prefix = x.Prefix,
                Description = x.Description
            }).ToList();
            return Ok();
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
            DepartmentViewModel departmentViewModel = new DepartmentViewModel()
            {
                Id = department.Id,
                Name = department.Name,
                Prefix = department.Prefix,
                DepartmentManagerId = department.DepartmentManagerId,
                Description = department.Description,
                CreateOrUpdatedBy = department.CreatedBy,
                CreateOrUpdatedOn = department.CreatedOn
            };
            return Ok(departmentViewModel);
        }

        [HttpPost]

        public IActionResult CreateDepartment([FromBody]DepartmentViewModel departmentViewModel)
        {
            if(ModelState.IsValid)
            {
                Department department = new Department()
                {
                    Name = departmentViewModel.Name,
                    Prefix = departmentViewModel.Prefix,
                    DepartmentManagerId = departmentViewModel.DepartmentManagerId,
                    Description = departmentViewModel.Description,
                    CreatedBy = departmentViewModel.CreateOrUpdatedBy,
                    CreatedOn = DateTime.UtcNow
                };
                dbContext.Departments.Add(department);
                dbContext.SaveChanges();
                return Ok(departmentViewModel);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:long}")]
        
        public IActionResult UpdateDepartment(long id, DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                var department = dbContext.Departments.Find(id);
                if (department == null)
                {
                    return NotFound();
                }
                department.Name = departmentViewModel.Name;
                department.Prefix = departmentViewModel.Prefix;
                department.DepartmentManagerId = departmentViewModel.DepartmentManagerId;
                department.Description = departmentViewModel.Description;
                department.UpdatedBy = departmentViewModel.CreateOrUpdatedBy;
                department.UpdatedOn = DateTime.UtcNow;
                dbContext.SaveChanges();
                return Ok(departmentViewModel);
            }
            else
            {
                return BadRequest(ModelState);
            }
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
