using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminProtal.Models
{
    public class SubDepartmentViewModel
    {
        public long Id { get; set; }
        [ForeignKey("DepartmentId")]
        public long DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Prefix { get; set; }
        public string Description { get; set; }
        public long CreateOrUpdatedBy { get; set; }
        public DateTime CreateOrUpdatedOn { get; set; }
    }
}
