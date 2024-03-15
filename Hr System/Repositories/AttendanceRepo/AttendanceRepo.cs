using Hr_System.Data;
using Hr_System.Dtos;
using Hr_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Hr_System.Repositories.AttendanceRepo
{
    public class AttendanceRepo :IAttendanceRepo
    {
        private readonly HrDbContext db;

        public AttendanceRepo(HrDbContext _db)
        {
            db = _db;
        }
        public List<Attendance> GetAll()
        {
            return db.Attendances.Include(x => x.Employee).ThenInclude(x => x.Department).ToList();
        }

        public Attendance getbyId(int id)
        {
            return db.Attendances.Include(x => x.Employee).ThenInclude(x => x.Department).FirstOrDefault(x => x.Id == id);
        }
        public void AddEmployeeAttendance(Attendance attendance)
        {
            db.Attendances.Add(attendance);
        }

        public void EditEmployeeAttendance(Attendance attendance)
        {
            db.Update(attendance);
        }
        public void DeleteEmployeeAttendance(Attendance attendance)
        {
            
            db.Attendances.Remove(attendance);
        }

        public List<Attendance> GetEmployeeAttendanceByDate(DateTime startDate, DateTime endDate)
        {
            return db.Attendances.Include(x => x.Employee).ThenInclude(x => x.Department).Where(x => x.Date.Date <= endDate.Date && x.Date.Date >= startDate.Date).ToList();
        }

        public List<Attendance> getEmployeeByName(string name)
        {
            return db.Attendances.Include(c => c.Employee).ThenInclude(x => x.Department).Where(x => x.Employee.FirstName.Contains(name)).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }

}
