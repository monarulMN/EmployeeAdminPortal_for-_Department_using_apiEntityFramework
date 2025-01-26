using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminProtal.Models
{
    public class SubDepartmentDTO
    {
        public long Id { get; set; }
        public string Department_Name { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Prefix { get; set; }
        public string Description { get; set; }
    }
}
