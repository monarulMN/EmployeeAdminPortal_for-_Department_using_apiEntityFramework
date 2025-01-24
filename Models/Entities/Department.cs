using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminProtal.Models.Entities
{
    public class Department
    {
        public long Id { get; set; }
        public long QissLocationId { get; set; }
        public long DepartmentManagerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Prefix { get; set; }
        [Required]
        public string Description { get; set; }

        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public long? RemovedBy { get; set; }
        public DateTime? RemovedOn { get; set; }

        public bool IsRemoved { get; set; }

        public long? DeletedBY { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsPermanentDeleted { get; set; }
    }
}
