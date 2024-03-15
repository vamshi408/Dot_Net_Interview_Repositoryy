
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.DAL
{

    public class EmployeeRepository : IRepository<EmployeeModel>
    {
        public static List<EmployeeModel> employeeList;

        public EmployeeRepository()
        {
            employeeList = new List<EmployeeModel>
    {
        new EmployeeModel()
        {
            EmployeeID=1001,
            EmployeeName="Bandi",
            EmployeePhone="+91 9999999999",
            EmployeeEmail="Bandi@gmail.com"
        },
        new EmployeeModel()
        {
            EmployeeID=1002,
            EmployeeName="Vamshi",
            EmployeePhone="+91 888888888",
            EmployeeEmail="Vamshi@gmail.com"
        },
        new EmployeeModel()
        {
            EmployeeID=1003,
            EmployeeName="Krishna",
            EmployeePhone="+91 7777777777",
            EmployeeEmail="Krishna@gmail.com"
        }
    };

        }


        public List<EmployeeModel> Add(EmployeeModel entity)
        {
            employeeList.Add(entity);
            return employeeList;
        }

        public List<EmployeeModel> DeleteEntity(EmployeeModel entity)
        {
            employeeList.Remove(entity);
            return employeeList;
        }

        public List<EmployeeModel> DeleteEntityByID(int ID)
        {
            EmployeeModel entity = employeeList.FirstOrDefault(emp => emp.EmployeeID == ID);
            employeeList.Remove(entity);
            return employeeList;
        }

        public List<EmployeeModel> GetAll()
        {
            return employeeList;
        }

        public EmployeeModel GetSingleEntity(EmployeeModel entity)
        {
            return employeeList.FirstOrDefault(emp => emp.EmployeeID == entity.EmployeeID);
        }

        public EmployeeModel GetSingleEntityByID(int ID)
        {
            return employeeList.FirstOrDefault(emp => emp.EmployeeID == ID);
        }

        public List<EmployeeModel> UpdateEntity(EmployeeModel entity)
        {
            EmployeeModel entityUpdate = employeeList.FirstOrDefault(emp => emp.EmployeeID == entity.EmployeeID);
            entityUpdate.EmployeeName= entity.EmployeeName;
            entityUpdate.EmployeePhone= entity.EmployeePhone;
            entityUpdate.EmployeeEmail= entity.EmployeeEmail;
            return employeeList;
        }
    }
}
