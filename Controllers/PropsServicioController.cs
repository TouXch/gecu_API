using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gecu_API.Models;
using Microsoft.AspNetCore.Cors;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PropsServicioController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;
        
        public PropsServicioController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<PropsServicio> list = new List<PropsServicio>();

            try
            {
                list = _dbcontext.PropsServicios.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("listByServId/{idservicio:int}")]
        public IActionResult listByServId(int idservicio)
        {
            List<PropsServicio> list = new List<PropsServicio>();
            List<PropsServicio> auxList = new List<PropsServicio>();

            try
            {
                list = _dbcontext.PropsServicios.ToList();
                foreach (var item in list)
                {
                    if (item.IdTipoServicio == idservicio)
                    {
                        auxList.Add(item);
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = auxList });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
