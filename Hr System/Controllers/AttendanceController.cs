using Hr_System.Data;
using Hr_System.Dtos;
using Hr_System.Models;
using Hr_System.Repositories.AttendanceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hr_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepo attendanceRepo;

        public AttendanceController(IAttendanceRepo _attendanceRepo)
        {
            attendanceRepo = _attendanceRepo;
        }

        [HttpGet("GetAll")]
        public List<AttendanceDto> GetAll()
        {
            var attens = attendanceRepo.GetAll();
            List<AttendanceDto> attDtos = new List<AttendanceDto>();
            foreach (var att in attens)
            {
                var attDto = new AttendanceDto()
                {
                   
                    Id=att.Id,
                    Date = new DateOnly(att.Date.Year ,att.Date.Month ,att.Date.Day),
                    ArrivalTime = att.ArrivalTime,
                    LeaveTime = att.LeaveTime,
                    employeeId = att.Employee.Id,
                    EmployeeName = att.Employee.FirstName,
                    DepartmentName=att.Employee.Department.DeptName
                };
                attDtos.Add(attDto);
            }
            return attDtos;

        }
        [HttpGet("getbyId/{id}")]

        public AttendanceDto getbyId(int id)
        {

            var att = attendanceRepo.getbyId(id);
            var attdto = new AttendanceDto()
            {
                Id = att.Id,
                Date = new DateOnly(att.Date.Year, att.Date.Month, att.Date.Day),
                ArrivalTime = att.ArrivalTime,
                LeaveTime = att.LeaveTime,
                employeeId = att.Employee.Id,
                EmployeeName = att.Employee.FirstName ,
                DepartmentName=att.Employee.Department.DeptName
            };

            return attdto;


        }
        [HttpPost("AddEmployeeAttendance")]
        public ActionResult AddEmployeeAttendance(Attendance attendance)
        {
            if (attendance == null) return BadRequest();
            attendanceRepo.AddEmployeeAttendance(attendance);
            attendanceRepo.Save();
            return Ok();

        }

        [HttpPut("EditEmployeeAttendance/{id}")]
        public ActionResult EditEmployeeAttendance(int id,Attendance attendance)
        {

            attendance.Id = id;
            if (attendance == null) return BadRequest();
            attendanceRepo.EditEmployeeAttendance(attendance);
            attendanceRepo.Save();
           
            return Ok();
        }

        [HttpDelete("DeleteEmployeeAttendance/{id}")]
        public ActionResult DeleteEmployeeAttendance(int id)
        {
            var attendance = attendanceRepo.getbyId(id);
            if (attendance == null) return BadRequest();
            attendanceRepo.DeleteEmployeeAttendance(attendance);
            attendanceRepo.Save();
            return NoContent();
        }

        [HttpGet("GetEmployeeAttendanceByDate")]
        public List<AttendanceDto> GetEmployeeAttendanceByDate(DateTime startDate, DateTime endDate)
        {
            var attendances = attendanceRepo.GetEmployeeAttendanceByDate(startDate, endDate);
            List<AttendanceDto> attdtos = new List<AttendanceDto>();
            foreach (var item in attendances)
            {
                AttendanceDto attdto = new AttendanceDto()
                {
                    Id=item.Id,
                    Date = new DateOnly(item.Date.Year, item.Date.Month, item.Date.Day),
                    ArrivalTime = item.ArrivalTime,
                    LeaveTime=item.LeaveTime,
                    employeeId = item.Employee.Id,
                    EmployeeName=item.Employee.FirstName,
                    DepartmentName=item.Employee.Department.DeptName
                    
                };
                attdtos.Add(attdto);
            }

            return attdtos;
        }

        [HttpGet("getEmployeeByName")]
        public List<AttendanceDto> getEmployeeByName(string name)
        {
            var attendances = attendanceRepo.getEmployeeByName(name);
            List<AttendanceDto> attdtos = new List<AttendanceDto>();
            foreach (var item in attendances)
            {
                AttendanceDto attdto = new AttendanceDto()
                {
                    Id = item.Id,
                    Date = new DateOnly(item.Date.Year ,item.Date.Month ,item.Date.Day),
                    ArrivalTime = item.ArrivalTime,
                    LeaveTime = item.LeaveTime,
                    employeeId = item.Employee.Id,
                    EmployeeName = item.Employee.FirstName,
                    DepartmentName = item.Employee.Department.DeptName

                };
                attdtos.Add(attdto);
            }

            return attdtos;
        }
    }
}
