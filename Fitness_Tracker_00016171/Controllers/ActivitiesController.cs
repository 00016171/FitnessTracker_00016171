using Fitness_Tracker_00016171.Models;
using Fitness_Tracker_00016171.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fitness_Tracker_00016171.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IRepository<Activity> _activityRepository;

        public ActivityController(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActivities()
        {
            var activities = await _activityRepository.GetAllAsync();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activity = await _activityRepository.GetByIDAsync(id);
            if (activity == null)
                return NotFound();
            return Ok(activity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _activityRepository.AddAsync(activity);
            return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] Activity activity)
        {
            if (id != activity.Id || !ModelState.IsValid)
                return BadRequest();

            await _activityRepository.UpdateAsync(activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _activityRepository.GetByIDAsync(id);
            if (activity == null)
                return NotFound();

            await _activityRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
