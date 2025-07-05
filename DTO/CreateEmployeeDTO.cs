namespace EmployeeDepartment.DTO
{
    public class CreateEmployeeDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}
