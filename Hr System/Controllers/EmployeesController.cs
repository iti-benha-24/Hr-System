using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hr_System.Data;
using Hr_System.Models;
using Hr_System.Dtos;
using Hr_System.Repositories.EmployeeRepository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hr_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public IEmployeeRepository Employee_Repo;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            Employee_Repo = employeeRepository;
        }


        [HttpGet("GetEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await Employee_Repo.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("GetAllDepartments")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await Employee_Repo.GetDepartments();
            return Ok(departments);
        }

        [HttpGet("GetEmployee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await Employee_Repo.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPut("PutEmployee/{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            employee.Id = id;
            if(employee == null)
            {
                return BadRequest();
            }
            await Employee_Repo.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpPost("PostEmployee")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await Employee_Repo.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await Employee_Repo.DeleteEmployee(id);
            return NoContent();
        }

        [HttpGet]
        [Route("ByDept/{deptId}")]
        public async Task<IActionResult> GetEmployeesByDepartment(int deptId)
        {
            var employees = await Employee_Repo.GetEmployeesByDepartment(deptId);
            return Ok(employees);
        }

    }
}
