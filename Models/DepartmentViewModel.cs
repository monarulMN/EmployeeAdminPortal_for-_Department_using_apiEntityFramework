using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminProtal.Models
{
    public class DepartmentViewModel
    {
        public long Id { get; set; }
        [Required]
        public  string Name { get; set; }
        [Required]
        public  string Prefix { get; set; }
        public  long DepartmentManagerId { get; set; }
        public  string Description { get; set; }
        public long CreateOrUpdatedBy { get; set; }
        public DateTime CreateOrUpdatedOn { get; set; }
    }
}
