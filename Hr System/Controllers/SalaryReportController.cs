using Hr_System.Data;
using Hr_System.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Hr_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryReportController : ControllerBase
    {
        private readonly HrDbContext db;

        public SalaryReportController(HrDbContext _db)
        {
            db = _db;
        }
        [HttpGet("GetSalaryReport")]
        public List<SalaryReportDto> GetSalaryReport()
        {
            var emps = db.Employees.Include(x => x.Department).Include(x=>x.Attendance).Include(x=>x.GeneralSettings).ToList();
            var empsDtos = new List<SalaryReportDto>();
      
            foreach (var item in emps)
            {
                int additionalHours = 0;
                int discountHours = 0;
                foreach (var item2 in item.Attendance)
                {
                    if (item2.LeaveTime == null)
                    {
                        additionalHours += 0;
                        discountHours += 0;
                    }
                    else
                    {
                        additionalHours += (int)item2.LeaveTime.Value.TotalHours - (int)item.LeaveTime.TotalHours;
                        discountHours += (int)item2.ArrivalTime.TotalHours - (int)item.ArrivalTime.TotalHours;
                    }
                }
                var absent = 22 - item.Attendance.Count();
                var totalAditionalHours = Math.Round((additionalHours * item.GeneralSettings.OvertimeHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);
                var totalDiscountHours  = Math.Round((discountHours * item.GeneralSettings.DiscountHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);

                var salaryDto = new SalaryReportDto()
                {
                    EmployeeName = item.FirstName + " " + item.LastName,
                    DepatmentName = item.Department.DeptName,
                    Salary = item.Salary,
                    Attend = item.Attendance.Count(),//Where(x => x.Date.Month == 2).Count();
                    Absent= absent,
                    Additional_hours= additionalHours,
                    Discount_hours=discountHours,
                    TotalAditionalHours =totalAditionalHours,
                    TotalDiscountHours=totalDiscountHours,
                    TotalNetSalary= Math.Round((((item.Salary / 22) * item.Attendance.Count()) + totalAditionalHours) - totalDiscountHours,2)

                };

                empsDtos.Add(salaryDto);
            }
            

            return empsDtos;
        } 

        [HttpGet("FilterSalaryReport")]
        public List<SalaryReportDto> FilterSalaryReport(int month, int year)
        {
            var emps = db.Attendances.Include(x => x.Employee).Include(x=>x.Employee.Department).Include(x=>x.Employee.GeneralSettings).Where(x=>x.Date.Month == month && x.Date.Year == year).ToList();
            
            var empsDtos = new List<SalaryReportDto>();
      
            foreach (var item in emps.Select(x=>x.Employee))
            {
                int additionalHours = 0;
                int discountHours = 0;
                foreach (var item2 in item.Attendance)
                {
                    if (item2.LeaveTime == null)
                    {
                        additionalHours += 0;
                        discountHours += 0;
                    }
                    else
                    {
                        additionalHours += (int)item2.LeaveTime.Value.TotalHours - (int)item.LeaveTime.TotalHours;
                        discountHours += (int)item2.ArrivalTime.TotalHours - (int)item.ArrivalTime.TotalHours;
                    }
                }
                var absent = 22 - item.Attendance.Count();
                var totalAditionalHours = Math.Round((additionalHours * item.GeneralSettings.OvertimeHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);
                var totalDiscountHours  = Math.Round((discountHours * item.GeneralSettings.DiscountHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);

                var salaryDto = new SalaryReportDto()
                {
                    EmployeeName = item.FirstName + " " + item.LastName,
                    DepatmentName = item.Department.DeptName,
                    Salary = item.Salary,
                    Attend = item.Attendance.Count(),//Where(x => x.Date.Month == 2).Count();
                    Absent= absent,
                    Additional_hours= additionalHours,
                    Discount_hours=discountHours,
                    TotalAditionalHours =totalAditionalHours,
                    TotalDiscountHours=totalDiscountHours,
                    TotalNetSalary= Math.Round((((item.Salary / 22) * item.Attendance.Count()) + totalAditionalHours) - totalDiscountHours,2)
                };

                empsDtos.Add(salaryDto);
            }
            

            return empsDtos;
        }
        [HttpGet("FilterSalaryReportByName")]
        public List<SalaryReportDto> FilterSalaryReportByName(string name)
        {

            var emps = db.Attendances.Include(x => x.Employee).Include(x=>x.Employee.Department).Include(x=>x.Employee.GeneralSettings).Where(x=>x.Employee.FirstName.Contains(name)).ToList();
            
            var empsDtos = new List<SalaryReportDto>();
      
            foreach (var item in emps.Select(x=>x.Employee).Distinct())
            {
                int additionalHours = 0;
                int discountHours = 0;
                foreach (var item2 in item.Attendance)
                {
                    if(item2.LeaveTime == null)
                    {
                        additionalHours += 0;
                        discountHours += 0;
                    }
                    else
                    {
                    additionalHours += (int)item2.LeaveTime.Value.TotalHours - (int)item.LeaveTime.TotalHours;
                    discountHours += (int)item2.ArrivalTime.TotalHours - (int)item.ArrivalTime.TotalHours;
                    } 
                }
                var absent = 22 - item.Attendance.Count();
                var totalAditionalHours = Math.Round((additionalHours * item.GeneralSettings.OvertimeHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);
                var totalDiscountHours  = Math.Round((discountHours * item.GeneralSettings.DiscountHour) * ((item.Salary / 22) / (item.LeaveTime.Hours - item.ArrivalTime.Hours)), 2);

                var salaryDto = new SalaryReportDto()
                {
                    EmployeeName = item.FirstName + " " + item.LastName,
                    DepatmentName = item.Department.DeptName,
                    Salary = item.Salary,
                    Attend = item.Attendance.Count(),
                    Absent= absent,
                    Additional_hours= additionalHours,
                    Discount_hours=discountHours,
                    TotalAditionalHours =totalAditionalHours,
                    TotalDiscountHours=totalDiscountHours,
                    TotalNetSalary= Math.Round((((item.Salary / 22) * item.Attendance.Count()) + totalAditionalHours) - totalDiscountHours,2)
                };

                empsDtos.Add(salaryDto);
            }
            

            return empsDtos;
        }
    }
}
