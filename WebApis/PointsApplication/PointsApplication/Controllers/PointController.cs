using Microsoft.AspNetCore.Mvc;
using PointsApplication.Entities;
using PointsApplication.Services;
using System.Threading.Tasks;

namespace PointsApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointController : ControllerBase
    {
        private readonly PointService pointService;

        public PointController(PointService pointService)
        {
            this.pointService = pointService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var data = await pointService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var point = await pointService.GetByIdAsync(id);
            return Ok(point);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomPoint point)
        {
            await pointService.AddAsync(point);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await pointService.DeleteAsync(id);

            return NoContent();
        }


    }
}
