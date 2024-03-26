using Hr_System.Data;
using Hr_System.Dtos;
using Hr_System.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hr_System.Repositories.SettingsRepository
{
    public interface ISettingsRepository
    {
         void CreateSetting(int id , SettingsDTO  settingsDTO);
         void EditSettings(int empId,SettingsDTO settingsDTO);

        GeneralSettings GeneralSettingsByEmpId(int empId);

    }
}
