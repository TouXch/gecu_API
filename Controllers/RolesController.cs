using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public RolesController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO QUE OBTIENE TODOS LOS ROLES EXISTENTES EN LA BD
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<Role> roles = new List<Role>();

            try
            {
                roles = _dbcontext.Roles.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = roles });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO QUE OBTIENE CADA ROL A PARTIR DEL ID PASADO COMO PARAMETRO
        [HttpGet]
        [Route("getById/{idrol:int}")]
        public IActionResult getById(int idrol)
        {
            Role rol = new Role();
            try
            {
                rol = _dbcontext.Roles.Find(idrol);
                if (rol is null)
                {
                    return BadRequest("Rol no encontrado");
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = rol });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message});
            }
        }

        //METODO PARA OBTENER LA DESCRIPCION DE UN ROL ESPECIFICO A PARTIR DE SU ID
        [HttpGet]
        [Route("getDescripcion/{idrol:int}")]
        public IActionResult getDescripcion(int idrol)
        {
            string descripcion = "";
            Role rol = new Role();

            try
            {
                rol = _dbcontext.Roles.Find(idrol);

                if (rol == null)
                {
                    return BadRequest("El rol seleccionado no existe");
                }

                descripcion = rol.Descripcion;
                return StatusCode(StatusCodes.Status200OK, new { message = descripcion });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO QUE PERMITE AGREGAR UN NUEVO ROL A LA BASE DE DATOS
        [HttpPost]
        [Route("add")]
        public IActionResult add([FromBody] Role role)
        {
            try
            {
                _dbcontext.Roles.Add(role);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Rol añadido" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message});
            }
        }

        //METODO QUE PERMITE MODIFICAR UN ROL EXISTENTE EN LA BD
        [HttpPut]
        [Route("edit")]
        public IActionResult edit([FromBody] Role role)
        {
            Role objRol = _dbcontext.Roles.Find(role.IdRol);

            if (objRol == null)
            {
                return BadRequest("El rol seleccionado no existe");
            }

            try
            {
                objRol.Descripcion = role.Descripcion is null ? objRol.Descripcion : role.Descripcion;

                _dbcontext.Update(objRol);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "Rol modificado con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message});
            }
        }

        //METODO QUE PERMITE LA ELIMINACION DE UN ROL DE LA BASE DE DATOS
        [HttpDelete]
        [Route("delete/{idrol:int}")]
        public IActionResult delete(int idrol)
        {
            Role role = _dbcontext.Roles.Find(idrol);

            if (role == null)
            {
                return BadRequest("El rol no existe en la base de datos");
            }

            try
            {
                _dbcontext.Remove(role);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Rol eliminado con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
