using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        public readonly GecubdContext _dbcontext = new GecubdContext();

        public EstadoController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA LISTAR TODOS LOS ESTADOS QUE EXISTEN
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<EstadoSolicitud> estados = new List<EstadoSolicitud>();

            try
            {
                estados = _dbcontext.EstadoSolicituds.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = estados });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER UN ESTADO A PARTIR DEL ID
        [HttpGet]
        [Route("listById/{idestado:int}")]
        public IActionResult listById(int idestado)
        {
            EstadoSolicitud estado = _dbcontext.EstadoSolicituds.Find(idestado);

            if (estado == null)
            {
                return BadRequest("No existe ese estado");
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = estado });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }

        }
    }
}
