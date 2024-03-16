using Hr_System.Dtos;
using Hr_System.Models;

namespace Hr_System.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Department>> GetDepartments();
        Task<Employee> GetEmployeeById(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task<IEnumerable<EmployeeDTO>> GetEmployeesByDepartment(int deptId);
    }
}