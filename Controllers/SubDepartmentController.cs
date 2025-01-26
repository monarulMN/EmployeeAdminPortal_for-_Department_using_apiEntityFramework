using EmployeeAdminProtal.Data;
using EmployeeAdminProtal.Models;
using EmployeeAdminProtal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SubDepartmentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllSubDepartments()
        {
            List<SubDepartmentDTO> result = dbContext.SubDepartments.Select(x => new SubDepartmentDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
            return Ok();
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult GetSubDepartmentById(long id)
        {
            var subDepartment = dbContext.SubDepartments.Find(id);
            if (subDepartment == null)
            {
                return NotFound();
            }
            SubDepartmentViewModel subDepartmentViewModel = new SubDepartmentViewModel()
            {
                Id = subDepartment.Id,
                Name = subDepartment.Name,
                Description = subDepartment.Description,
                CreateOrUpdatedBy = subDepartment.CreatedBy,
                CreateOrUpdatedOn = subDepartment.CreatedOn
            };
            return Ok(subDepartmentViewModel);
        }

        [HttpPost]
        public IActionResult CreateSubDepartment([FromBody] SubDepartmentViewModel subDepartmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                SubDepartment subDepartment = new SubDepartment()
                {
                    Name = subDepartmentViewModel.Name,
                    Description = subDepartmentViewModel.Description,
                    CreatedBy = subDepartmentViewModel.CreateOrUpdatedBy,
                    CreatedOn = DateTime.Now
                };
                dbContext.SubDepartments.Add(subDepartment);
                dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
