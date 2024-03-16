using Hr_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hr_System.Repositories.PublicHolidayReposatry
{
    public interface Ipublicholidayrepo
    {
        List<PublicHolidays> GetAll();
        bool AddNewHoliday(PublicHolidays publicHolidays);
        bool Delete(int id);
        bool Update(int id, PublicHolidays updatedHoliday);
    }
}
