using ASP.NET_Core_Web_API.DAL;
using ASP.NET_Core_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmloyeeController : ControllerBase
    {

        private readonly IRepository<EmployeeModel> _employeeRepository;

        public EmloyeeController(IRepository<EmployeeModel> employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        [HttpGet("GetAllEmployees")]
        public List<EmployeeModel> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        [HttpGet("GetEmployeeByID")]
        public EmployeeModel GetEmployeeByID(int id)
        {
            return _employeeRepository.GetSingleEntityByID(id);
        }


        [HttpPost("GetEmployee")]
        public EmployeeModel GetEmployee(EmployeeModel employeeModel)
        {
            return _employeeRepository.GetSingleEntity(employeeModel);
        }

        [HttpPost("AddEmployee")]
        public List<EmployeeModel> AddEmployee(EmployeeModel employeeModel)
        {
            return _employeeRepository.Add(employeeModel);
        }

        [HttpGet("DeleteEmployee")]
        public List<EmployeeModel> DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEntityByID(id);
        }

        [HttpPut("UpdateEmployee")]
        public List<EmployeeModel> UpdateEmployee(EmployeeModel employeeModel)
        {
            return _employeeRepository.UpdateEntity(employeeModel);
        }

    }
}
