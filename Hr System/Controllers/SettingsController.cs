using Hr_System.Dtos;
using Hr_System.Models;
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
    }
}
