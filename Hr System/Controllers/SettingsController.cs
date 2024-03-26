using Hr_System.Dtos;
using Hr_System.Models;
using Hr_System.Repositories.AttendanceRepo;
using Hr_System.Repositories.SettingsRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hr_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsController( ISettingsRepository settingsRepo)
        {
            _settingsRepository = settingsRepo;
        }

        [HttpPost("CreateSettings/{id}")]
        public IActionResult CreateSettings( int id , SettingsDTO settingsDTO)
        {
            if (id == 0 || settingsDTO == null)
                return BadRequest();

            _settingsRepository.CreateSetting(id, settingsDTO);
            return Ok();

        }
        [HttpPut("EditSetting/{id}")]
        public ActionResult EditSetting(int id, SettingsDTO settingsDTO)
        {

            if (settingsDTO == null) return BadRequest();
            _settingsRepository.EditSettings(id,settingsDTO);

            return Ok();
        }
        [HttpGet("GetSettingByEmpId/{id}")]
        public SettingsDTO GetSettingByEmpId(int id)
        {

            GeneralSettings Gs = _settingsRepository.GeneralSettingsByEmpId(id);
            if (Gs == null)
            {
                return null;
            }
            SettingsDTO settingsDTO = new SettingsDTO
            {
                OvertimeHour = Gs.OvertimeHour,
                DiscountHour = Gs.DiscountHour,
                Weekend1 = Gs.Weekend1,
                Weekend2 = Gs.Weekend2,
            };

            return settingsDTO;
        }
    }
}
