using Hr_System.Data;
using Hr_System.Dtos;
using Hr_System.Models;

namespace Hr_System.Repositories.SettingsRepository
{
   
    public class SettingsRepository : ISettingsRepository
    {
        private readonly HrDbContext _Context;

        public SettingsRepository( HrDbContext context) {
            _Context = context;
        }

        public void CreateSetting(int id , SettingsDTO settingsDTO)
        {
            var Employee = _Context.Employees.Where( X => X.Id == id).FirstOrDefault();
            if (Employee != null)
            {
                GeneralSettings GS = new GeneralSettings()
                {
                    EmployeeId = id,
                    OvertimeHour = settingsDTO.OvertimeHour,
                    DiscountHour = settingsDTO.DiscountHour, 
                    Weekends = settingsDTO.WeekendDays.Select( w => new Weekend
                    {
                        Name = w.Day
                    }).ToList(),
                };
                _Context.GeneralSettings.Add(GS);
                _Context.SaveChanges();
            }
        }

        public void EditSettings(SettingsDTO settingsDTO)
        {
            GeneralSettings GS  = _Context.GeneralSettings.Where( X =>X.Id == settingsDTO.Id).FirstOrDefault();
            if(GS != null)
            {
                GS.OvertimeHour = settingsDTO.OvertimeHour;
                GS.DiscountHour = settingsDTO.DiscountHour;
                GS.Weekends = settingsDTO.WeekendDays.Select(w => new Weekend
                {
                    Name = w.Day
                }).ToList();



                _Context.GeneralSettings.Update(GS);
                _Context.SaveChanges();
            }

           

        }
    }
}
