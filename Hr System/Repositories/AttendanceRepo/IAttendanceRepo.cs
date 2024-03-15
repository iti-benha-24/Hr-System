using Hr_System.Models;

namespace Hr_System.Repositories.AttendanceRepo
{
    public interface IAttendanceRepo
    {
        List<Attendance> GetAll();
        Attendance getbyId(int id);
        void AddEmployeeAttendance(Attendance attendance);
        void EditEmployeeAttendance(Attendance attendance);
        void DeleteEmployeeAttendance(Attendance attendance);
        List<Attendance> GetEmployeeAttendanceByDate(DateTime startDate, DateTime endDate);
        List<Attendance> getEmployeeByName(string name);
        void Save();
    }
}
