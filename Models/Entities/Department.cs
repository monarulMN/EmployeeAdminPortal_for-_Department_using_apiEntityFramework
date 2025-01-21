namespace EmployeeAdminProtal.Models.Entities
{
    public class Department
    {
        public long Id { get; set; }
        public long QissLocationId { get; set; }
        public long DepartmentManagerId { get; set; }
        public required string Name { get; set; }
        public required string Prefix { get; set; }
        public required string Description { get; set; }

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
