using Hr_System.Data;
using Hr_System.Dtos;
using Hr_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hr_System.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HrDbContext Con;

        public EmployeeRepository(HrDbContext context)
        {
            Con = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await Con.Employees.Include(x=>x.Department).ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await Con.Departments.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await Con.Employees.FindAsync(id);
        }

        public async Task AddEmployee(Employee employee)
        {
            var general = new GeneralSettings()
            {
                DiscountHour = 1,
                OvertimeHour = 1,
                Weekend1 = "Friday",
                Weekend2 = "Saturday"
            };
            employee.GeneralSettings = general;
           
            Con.Employees.Add(employee);
            await Con.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            Con.Entry(employee).State = EntityState.Modified;
            await Con.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await Con.Employees.FindAsync(id);
            if (employee != null)
            {
                Con.Employees.Remove(employee);
                await Con.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByDepartment(int deptId)
        {
            var employees = await Con.Employees
                .Include(e => e.Department)
                .Where(e => e.DepartmentId == deptId)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Country = e.Country,
                    City = e.City,
                    Gender = e.Gender,
                    BirthDate = e.BirthDate,
                    Nationality = e.Nationality,
                    NationalId = e.NationalId,
                    HireDate = e.HireDate,
                    Salary = e.Salary,
                    ArrivalTime = e.ArrivalTime,
                    LeaveTime = e.LeaveTime,
                    UserId = e.UserId,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.DeptName
                })
                .ToListAsync();

            return employees;
        }

    }
}
