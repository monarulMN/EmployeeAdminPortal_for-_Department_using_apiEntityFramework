using EmployeeAdminProtal.Data;
using EmployeeAdminProtal.Models;
using EmployeeAdminProtal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public JobTitleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllJobTitles()
        {
            List<JobTitleDTO> result = dbContext.JobTitles.Select(x => new JobTitleDTO()
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
        public IActionResult GetJobTitleById(long id)
        {
            var jobTitle = dbContext.JobTitles.Find(id);
            if (jobTitle == null)
            {
                return NotFound();
            }
            JobTitleViewModel jobTitleViewModel = new JobTitleViewModel()
            {
                Id = jobTitle.Id,
                Name = jobTitle.Name,
                Prefix = jobTitle.Prefix,
                Description = jobTitle.Description,
                CreateOrUpdatedBy = jobTitle.CreatedBy,
                CreateOrUpdatedOn = jobTitle.CreatedOn
            };
            return Ok(jobTitleViewModel);

        }

        [HttpPost]
        public IActionResult CreateJobTitle([FromBody] JobTitleViewModel jobTitleViewModel)
        {
            if (!ModelState.IsValid)
            {
                JobTitle jobTitle = new JobTitle()
                {
                    Name = jobTitleViewModel.Name,
                    Prefix = jobTitleViewModel.Prefix,
                    Description = jobTitleViewModel.Description,
                    CreatedBy = jobTitleViewModel.CreateOrUpdatedBy,
                    CreatedOn = DateTime.Now
                };
                dbContext.JobTitles.Add(jobTitle);
                dbContext.SaveChanges();
                return Ok(jobTitleViewModel);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        [Route("{id:long}")]
        public IActionResult UpdateJobTitle(long id, [FromBody] JobTitleViewModel jobTitleViewModel)
        {
            if(ModelState.IsValid)
            {
                var jobTitle = dbContext.JobTitles.Find(id);
                if (jobTitle == null)
                {
                    return NotFound();
                }
                jobTitle.Name = jobTitleViewModel.Name;
                jobTitle.Prefix = jobTitleViewModel.Prefix;
                jobTitle.Description = jobTitleViewModel.Description;
                jobTitle.UpdatedBy = jobTitleViewModel.CreateOrUpdatedBy;
                jobTitle.UpdatedOn = DateTime.Now;
                dbContext.SaveChanges();
                return Ok(jobTitleViewModel);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult DeleteJobTitle(long id)
        {
            var jobTitle = dbContext.JobTitles.Find(id);
            if (jobTitle == null)
            {
                return NotFound();
            }
            dbContext.JobTitles.Remove(jobTitle);
            jobTitle.DeletedOn = DateTime.Now;
            jobTitle.IsPermanentDeleted = true;
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
