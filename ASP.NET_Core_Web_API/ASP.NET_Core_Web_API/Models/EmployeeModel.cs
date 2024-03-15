namespace ASP.NET_Core_Web_API.Models
{
    
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public required string EmployeeName { get; set; }
        public required string EmployeePhone { get; set; }
        public required string EmployeeEmail { get; set; }
    }
}
