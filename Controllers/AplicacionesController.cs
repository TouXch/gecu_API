using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacionesController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public AplicacionesController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA OBTENER TODOS LOS TIPOS DE APLICACION EXISTENTES
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<TipoAplicacion> aplicaciones = new List<TipoAplicacion>();

            try
            {
                aplicaciones = _dbcontext.TipoAplicacions.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = aplicaciones });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER UNA APLICACION A PARTIR DE SU ID
        [HttpGet]
        [Route("getById/{idaplicacion:int}")]
        public IActionResult getById(int idaplicacion)
        {
            TipoAplicacion aplicacion = new TipoAplicacion();

            try
            {
                aplicacion = _dbcontext.TipoAplicacions.Find(idaplicacion);

                if (aplicacion is null)
                {
                    return BadRequest("La aplicación no existe");
                }

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = aplicacion });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA AGREGAR NUEVAS APLICACIONES A LA BD
        [HttpPost]
        [Route("add")]
        public IActionResult add([FromBody] TipoAplicacion aplicacion)
        {
            try
            {
                _dbcontext.TipoAplicacions.Add(aplicacion);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Aplicacion agregada" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA EDITAR UNA APLICACION DETERMINADA A PARTIR DEL ID
        [HttpPut]
        [Route("edit")]
        public IActionResult edit([FromBody] TipoAplicacion aplicacion)
        {
            TipoAplicacion objAplicacion = aplicacion;

            if (objAplicacion is null)
            {
                return BadRequest("Algo salio extremadamente mal");
            }

            try
            {
                objAplicacion.Descripcion = aplicacion.Descripcion is null ? objAplicacion.Descripcion : aplicacion.Descripcion;
                _dbcontext.Update(objAplicacion);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Aplicacion editada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA ELIMINAR UNA APLICACION A PARTIR DE SU ID
        [HttpDelete]
        [Route("delete/{idaplicacion:int}")]
        public IActionResult delete(int idaplicacion)
        {
            TipoAplicacion aplicacion = _dbcontext.TipoAplicacions.Find(idaplicacion);

            try
            {
                if (aplicacion is null)
                {
                    return BadRequest("Algo salio verdaderamente mal");
                }
                _dbcontext.Remove(aplicacion);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Aplicacion eliminada" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
