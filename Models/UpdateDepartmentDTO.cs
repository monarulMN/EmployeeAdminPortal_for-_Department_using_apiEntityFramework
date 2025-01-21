namespace EmployeeAdminProtal.Models
{
    public class UpdateDepartmentDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Prefix { get; set; }
        public required string DepartmentManager { get; set; }
        public required string Description { get; set; }
    }
}
