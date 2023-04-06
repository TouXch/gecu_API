using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSolicitudController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public TipoSolicitudController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA OBTENER TODOS LOS TIPOS DE SOLICITUD DE LA BD
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<TipoSolicitud> list = new List<TipoSolicitud>();

            try
            {
                list = _dbcontext.TipoSolicituds.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER EL TIPO DE SOLICITUD A PARTIR DE UN ID
        [HttpGet]
        [Route("listById/{idtipo:int}")]
        public IActionResult listById(int idtipo)
        {
            TipoSolicitud tipoSolicitud = new TipoSolicitud();

            try
            {
                tipoSolicitud = _dbcontext.TipoSolicituds.Find(idtipo);

                if (tipoSolicitud is null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "El tipo de solicitud no existe" });
                }

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = tipoSolicitud });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
