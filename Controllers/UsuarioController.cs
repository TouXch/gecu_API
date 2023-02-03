using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public UsuarioController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA OBTENER TODOS LOS USUARIOS DE LA BD
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<Usuario> list = new List<Usuario>();

            try
            {
                list = _dbcontext.Usuarios.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER LOS USUARIOS DE ACUERDO A UN ROL DETERMINADO
        [HttpGet]
        [Route("getByRol/{idrol:int}")]
        public IActionResult getByRol(int idrol)
        {
            List<Usuario> usuarios = new List<Usuario>();
            List<Usuario> usuarioRoles = new List<Usuario>();

            try
            {
                usuarios = _dbcontext.Usuarios.ToList();

                if (idrol == 0)
                {
                    usuarioRoles = usuarios;
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = usuarioRoles });

                }
                else
                {
                    foreach (var usuario in usuarios)
                    {
                        if (usuario.IdRol == idrol)
                        {
                            usuarioRoles.Add(usuario);
                        }
                    }
                }                

                if (usuarioRoles.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "Ningun usuario tiene asignado el rol seleccionado" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = usuarioRoles });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
