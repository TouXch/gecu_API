using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gecu_API.Models;
using Microsoft.AspNetCore.Cors;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PropserviciomMtiposervicioController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public PropserviciomMtiposervicioController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO QUE OBTIENE TODAS LAS RELACIONES DE SERVICIOS Y PERMISOS EXISTENTES
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<PropserviciomMtiposervicio> list = new List<PropserviciomMtiposervicio>();

            try
            {
                list = _dbcontext.PropserviciomMtiposervicios.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO QUE OBTIENE TODOS LOS PERMISOS A PARTIR DEL ID DE UN SERVICIO
        [HttpGet]
        [Route("listByIdservicio/{idservicio:int}")]
        public IActionResult listByIdservicio(int idservicio)
        {
            List<PropserviciomMtiposervicio> list = new List<PropserviciomMtiposervicio>();
            List<PropserviciomMtiposervicio> aux = new List<PropserviciomMtiposervicio>();

            try
            {
                list = _dbcontext.PropserviciomMtiposervicios.ToList();
                foreach (var item in list)
                {
                    if (item.IdTipoServicio == idservicio)
                    {
                        aux.Add(item);
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = aux });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
