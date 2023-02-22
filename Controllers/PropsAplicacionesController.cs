using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gecu_API.Models;
using Microsoft.AspNetCore.Cors;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PropsAplicacionesController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public PropsAplicacionesController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA OBTENER TODOS LOS PERMISOS DE LA BASE DE DATOS
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<PropsAplicacione> aplicaciones = new List<PropsAplicacione>();

            try
            {
                aplicaciones = _dbcontext.PropsAplicaciones.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = aplicaciones });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER TODOS LOS PERMISOS A PARTIR DEL ID DE UNA APLICACION
        [HttpGet]
        [Route("listByAppId/{idaplicacion:int}")]
        public IActionResult listByAppId(int idaplicacion)
        {
            List<PropsAplicacione> list = new List<PropsAplicacione>();
            List<PropsAplicacione> auxList = new List<PropsAplicacione>();

            try
            {
                list = _dbcontext.PropsAplicaciones.ToList();
                foreach (var item in list)
                {
                    if (item.IdTipoAplicacion == idaplicacion)
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
            PropsAplicacione permiso = new PropsAplicacione();

            try
            {
                permiso = _dbcontext.PropsAplicaciones.Find(idpermiso);
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

        //METODO PARA AGREGAR UN PERMISO A UNA APLICACION
        [HttpPost]
        [Route("addpermiso/{idaplicacion:int}/{permiso}")]
        public IActionResult addpermiso(int idaplicacion, string permiso)
        {
            PropsAplicacione propApp = new PropsAplicacione();

            try
            {
                propApp.Descripcion = permiso;
                propApp.IdTipoAplicacion = idaplicacion;
                _dbcontext.Add(propApp);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Permiso agregado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA ELIMINAR UNA RELACION ENTRE UNA APLICACION Y UN PERMISO
        [HttpDelete]
        [Route("delete/{idaplicacion:int}/{descripcion}")]
        public IActionResult delete(int idaplicacion, string descripcion)
        {
            List<PropsAplicacione> list = new List<PropsAplicacione>();
            PropsAplicacione relacion = new PropsAplicacione();

            try
            {
                list = _dbcontext.PropsAplicaciones.Where(l => l.IdTipoAplicacion == idaplicacion).ToList();
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

        //METODO PARA QUITAR TODOS LOS PERMISOS A UNA APLICACION
        [HttpDelete]
        [Route("quitall/{idaplicacion}")]
        public IActionResult quitall(int idaplicacion)
        {
            List<PropsAplicacione> list = new List<PropsAplicacione>();
            List<PropsAplicacione> auxlist = new List<PropsAplicacione>();

            try
            {
                list = _dbcontext.PropsAplicaciones.ToList();
                foreach (var item in list)
                {
                    if (item.IdTipoAplicacion == idaplicacion)
                    {
                        auxlist.Add(item);
                    }
                }

                foreach (var item in auxlist)
                {
                    if (item.IdTipoAplicacion == idaplicacion)
                    {
                        _dbcontext.Remove(item);
                        _dbcontext.SaveChanges();
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new { message = "Permisos eliminados" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
