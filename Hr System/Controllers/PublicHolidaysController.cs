using Hr_System.Models;
using Hr_System.Reposatories.PublicHolidayReposatry;
using Microsoft.AspNetCore.Mvc;

namespace Hr_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicHolidaysController : ControllerBase
    {
       
        private readonly Ipublicholidayrepo repo;
        private bool result;

        public PublicHolidaysController(  Ipublicholidayrepo repo)
        {
            
            this.repo = repo;
        }

        //get all holidays
        [HttpGet("GetAll")]

        public List<PublicHolidays> GetAll()
        {
            List<PublicHolidays> publicHolidays = new List<PublicHolidays>();
            publicHolidays = repo.GetAll();
            return publicHolidays;
        }


        //insert new holiday
        [HttpPost("AddNewHoliday")]
        public ActionResult AddNewHoliday( PublicHolidays publicHolidays)
        {
            if (publicHolidays == null)
                return BadRequest("Holiday data is null");
            
            repo.AddNewHoliday(publicHolidays);
            return Created("done", publicHolidays);
            
        }

        //delete holiday
        [HttpDelete("Delete/{id}")]

        public ActionResult Delete(int id) {
            result = repo.Delete(id);
            if(result)
                return Ok();
            return NotFound();
        }


        // Update holiday
        [HttpPut("Update/{id}")]
        public ActionResult Update(int id, PublicHolidays updatedHoliday)
        {
            if (updatedHoliday == null)
                return NotFound();
            if (updatedHoliday.Id != id)
                return BadRequest("Mismatched IDs");
            result = repo.Update(id, updatedHoliday);
            if (result)
                return NoContent();
            return NotFound();
        }

      
    }
}
