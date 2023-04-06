using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoUsuarioController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public EstadoUsuarioController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA OBTENER TODOS LOS ESTADOS DE LOS USUARIOS
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<EstadoUsuario> estados = new List<EstadoUsuario>();

            try
            {
                estados = _dbcontext.EstadoUsuarios.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = estados });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

    }
}
