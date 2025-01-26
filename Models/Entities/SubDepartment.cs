using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminProtal.Models.Entities
{
    public class SubDepartment
    {
        public long Id { get; set; }
        public long DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Prefix { get; set; }

        public string Description { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
