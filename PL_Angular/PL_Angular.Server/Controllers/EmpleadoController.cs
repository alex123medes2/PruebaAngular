using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL_Angular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllEmpleado")]
        public IActionResult GetAllEmpleado()
        {
            var result = BL.Empleado.GetAllEmpleado();
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
        [Route("GetByIdEmpleado/{IdEmpleado}")]
        public IActionResult GetByIdEmpleado(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetByIdEmpleado(IdEmpleado);
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
        [Route("AddEmpleado")]
        public IActionResult AddEmpleado([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.AddEmpleado(empleado);
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
        [Route("UpdateEmpleado")]
        public IActionResult Update([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.UpdateEmpleado(empleado);
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
        [Route("DeleteEmpleado/{id}")]
        public IActionResult DeleteEmpleado(int id)
        {
            ML.Result result = BL.Empleado.DeleteEmpleado(id);
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
