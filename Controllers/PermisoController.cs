using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gecu_API.Models;
using Microsoft.AspNetCore.Cors;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public PermisoController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA OBTENER TODOS LOS PERMISOS DE LA BASE DE DATOS
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<Permiso> list = new List<Permiso>();

            try
            {
                list = _dbcontext.Permisos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
