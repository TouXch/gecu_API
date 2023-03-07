using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public DireccionController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //FUNCION PARA OBTENER TODAS LAS DIRECCIONES ALMACENADAS EN LA BD
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<Direccion> direcciones = new List<Direccion>();

            try
            {
                direcciones = _dbcontext.Direccions.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = direcciones });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER LAS DIRECCIONES A PARTIR DE SU ID
        [HttpGet]
        [Route("listById/{iddireccion:int}")]
        public IActionResult listById(int iddireccion)
        {
            Direccion direccion = new Direccion();

            try
            {
                direccion = _dbcontext.Direccions.Find(iddireccion);

                if (direccion is null)
                {
                    return BadRequest("La direccion no existe");
                }

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = direccion });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
