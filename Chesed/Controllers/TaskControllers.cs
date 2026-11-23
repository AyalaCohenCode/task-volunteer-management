using Microsoft.AspNetCore.Mvc;
using Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chesed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskControllers : ControllerBase
    {
        TaskService service = new TaskService();
        // GET: api/<TaskControllers>
        [HttpGet]
        public IEnumerable<TaskToShow> Get(string?sortBy)
        {
            return service.GetAllTaskFromService(sortBy);
        }

        // GET api/<TaskControllers>/5
        [HttpGet("{id}")]
        public TaskToShow Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<TaskControllers>
        [HttpPost]
        public ActionResult Post([FromBody] TaskToAdd value)
        {
            try
            {
                service.Add(value);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<TaskControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TaskToUpdate value)
        {
            service.UpdateTask(id, value);
        }

        // DELETE api/<TaskControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("filterTaskOpened")]
        public IEnumerable<TaskToShow> GetOpenedTasks()
        {
            return service.GetOpenedTaskFromService();
        }
        [HttpPut("{id}/status")]
        public void UpdateStatus(int id, [FromBody] string status)
        {
            service.UpdateStatus(id, status);
        }
        [HttpGet("filters")]
        public IEnumerable<TaskToShow> GetFiteredTasks([FromQuery] string? skill, [FromQuery] string? dateTask, [FromQuery] string? location)
        {
            return service.FilterTasks(skill, dateTask, location);
        }
    }
}
