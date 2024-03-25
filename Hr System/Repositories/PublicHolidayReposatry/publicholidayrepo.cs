using Hr_System.Data;
using Hr_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hr_System.Repositories.PublicHolidayReposatry
{
    public class Publicholidayrepo : Ipublicholidayrepo
    {
        private readonly HrDbContext _context;
        PublicHolidays? holidays;

        public Publicholidayrepo(HrDbContext context)
        {
            _context = context;
        }
        public List<PublicHolidays> GetAll()
        {
            return _context.PublicHolidays.ToList();
        }
        public bool AddNewHoliday(PublicHolidays publicHolidays)
        {

            _context.PublicHolidays.Add(publicHolidays);
            _context.SaveChanges();
            return true;
        }


        public bool Delete(int id)
        {
            holidays = _context.PublicHolidays.Find(id);
            if (holidays == null) return false;
            _context.PublicHolidays.Remove(holidays);
            _context.SaveChanges();
            return true;
        }


        public bool Update(int id, PublicHolidays updatedHoliday)
        {
            holidays = _context.PublicHolidays.Find(id);
            if (holidays == null)
                return false;


            holidays.Name = updatedHoliday.Name;
            holidays.Day = updatedHoliday.Day;


            _context.SaveChanges();

            return true;
        }

        public PublicHolidays getById(int id)
        {
           var holiday = _context.PublicHolidays.Find(id);
            return holiday;
            
        }
    }
}
