using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public ServicioController(GecubdContext _context)
        {
            _dbcontext = _context;
        }


        //METODO PARA OBTENER TODOS LOS TIPOS DE SERVICIOS EXISTENTES EN LA BD
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<TipoServicio> servicios = new List<TipoServicio>();

            try
            {
                servicios = _dbcontext.TipoServicios.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = servicios });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER UN SERVICIO A PARTIR DE SU ID
        [HttpGet]
        [Route("getById/{idservicio:int}")]
        public IActionResult getById(int idservicio)
        {
            TipoServicio servicio = new TipoServicio();

            try
            {
                servicio = _dbcontext.TipoServicios.Find(idservicio);

                if (servicio is null)
                {
                    return BadRequest("El servicio no existe");
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = servicio });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA INSERTAR NUEVOS SERVICIOS A LA BD
        [HttpPost]
        [Route("add")]
        public IActionResult add([FromBody] TipoServicio servicio)
        {
            try
            {
                _dbcontext.Add(servicio);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Servicio agregado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA EDITAR UN ROL SELECCCIONADO EN LA BD
        [HttpPut]
        [Route("edit")]
        public IActionResult edit([FromBody] TipoServicio servicio)
        {
            TipoServicio objServicio = servicio;

            if (objServicio is null)
            {
                return BadRequest("El servicio seleccionado no existe");
            }

            try
            {
                objServicio.Descripcion = servicio.Descripcion is null ? objServicio.Descripcion : servicio.Descripcion;
                _dbcontext.Update(objServicio);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Servicio modificado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO QUE PERMITE LA ELIMINACION DE UN SERVICIO DE LA BD
        [HttpDelete]
        [Route("delete/{idservicio:int}")]
        public IActionResult delete(int idservicio)
        {
            TipoServicio servicio = _dbcontext.TipoServicios.Find(idservicio);

            if (servicio is null)
            {
                return BadRequest("El servicio seleccionado no existe");
            }

            try
            {
                _dbcontext.Remove(servicio);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Servicio eliminado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
