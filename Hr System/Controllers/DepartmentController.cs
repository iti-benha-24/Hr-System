
using Hr_System.Models;
using Hr_System.Repositories.DepartmentRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hr_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        
        private readonly IDeparmentRepository deptRepo;

        public DepartmentController(IDeparmentRepository deptRepo)
        {
            this.deptRepo = deptRepo;
        }
        [HttpGet("getAll")]
        public List<Department> getAll()
        {
            return deptRepo.GetAll();
        }
        
        [HttpGet("getById/{id}")] 
        public Department getById(int id)
        {
            return deptRepo.getById(id);
        } 
        [HttpPost("Add")] 
        public ActionResult Add(Department dept)
        {
            if (dept == null) return BadRequest();
            deptRepo.Add(dept);
            return Ok();
        }
        [HttpPut("edit/{id}")] 
        public ActionResult edit(int id,Department dept)
        {
            dept.Id = id;
            if (dept == null) return BadRequest();
            deptRepo.Update(dept);
            return Ok();
        }  
        [HttpDelete("delete/{id}")] 
        public ActionResult delete(int id)
        {
            var dept = deptRepo.getById(id);
            if (dept == null) return BadRequest();
            deptRepo.Delete(dept);
            return Ok();
        }

    }
}
