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


        //METODO PARA OBTENER TODOS LOS PERMISOS DE LA BASE DE DATOS
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


        //METODO PARA OBTENER TODOS LOS PERMISOS A PARTIR DEL ID DE UN SERVICIO
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

        //METODO PARA OBTENER UN PERMISO A PARTIR DE UN ID
        [HttpGet]
        [Route("listByPropId/{idpermiso:int}")]
        public IActionResult listByPropId(int idpermiso)
        {
            PropsServicio permiso = new PropsServicio();

            try
            {
                permiso = _dbcontext.PropsServicios.Find(idpermiso);
                if (permiso == null)
                {
                    return BadRequest("No existe el permiso seleccionado");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = permiso });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA AGREGAR UN PERMISO A UN SERVICIO
        [HttpPost]
        [Route("addpermiso/{idservicio:int}/{permiso}")]
        public IActionResult addpermiso(int idservicio, string permiso)
        {
            PropsServicio propServ = new PropsServicio();

            try
            {
                propServ.Descripcion = permiso;
                propServ.IdTipoServicio = idservicio;
                _dbcontext.Add(propServ);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Permiso agregado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA ELIMINAR UNA RELACION ENTRE UN SERVICIO Y UN PERMISO
        [HttpDelete]
        [Route("delete/{idservicio:int}/{descripcion}")]
        public IActionResult delete(int idservicio, string descripcion)
        {
            List<PropsServicio> list = new List<PropsServicio>();
            PropsServicio relacion = new PropsServicio();

            try
            {
                list = _dbcontext.PropsServicios.Where(l => l.IdTipoServicio == idservicio).ToList();
                relacion = list.Find(l => l.Descripcion == descripcion);
                _dbcontext.Remove(relacion);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Permiso eliminado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA QUITAR TODOS LOS PERMISOS DE UN SERVICIO
        [HttpDelete]
        [Route("quitall/{idservicio:int}")]
        public IActionResult quitall(int idservicio)
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

                foreach (var item in auxList)
                {
                    if (item.IdTipoServicio == idservicio)
                    {
                        _dbcontext.Remove(item);
                        _dbcontext.SaveChanges();
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new { message = "permisos eliminados" });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
