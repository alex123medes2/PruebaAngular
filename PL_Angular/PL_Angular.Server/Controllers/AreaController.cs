using Microsoft.AspNetCore.Mvc;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL_Angular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllArea")]
        public IActionResult GetAll()
        {
            var result = BL.Area.GetAllArea();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetByIdArea/{IdArea}")]
        public IActionResult GetByIdArea(int IdArea)
        {
            ML.Result result = BL.Area.GetByIdArea(IdArea);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddArea")]
        public IActionResult Add([FromBody] ML.Area area)
        {
            ML.Result result = BL.Area.AddArea(area);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateArea/{IdArea}")]
        public IActionResult Update(int IdArea, [FromBody] ML.Area area)
        {
            ML.Result result = BL.Area.UpdateArea(area);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteArea/{id}")]
        public IActionResult Delete(int id)
        {
            ML.Result result = BL.Area.DeleteArea(id);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
