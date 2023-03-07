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

        //METODO PARA OBTENER UN USUARIO A PARTIR DE SU ID
        [HttpGet]
        [Route("listById/{idusuario:int}")]
        public IActionResult listById(int idusuario)
        {
            Usuario usuario = _dbcontext.Usuarios.Find(idusuario);

            if (usuario == null)
            {
                return BadRequest("No existe el usuario");
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = usuario });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER TODOS LOS USUARIOS A PARTIR DE LA DIRECCION A LA QUE PERTENECEN
        [HttpGet]
        [Route("listByDir/{idDir:int}")]
        public IActionResult listByDir(int idDir)
        {
            List<Usuario> usuarios = new List<Usuario>();
            List<Usuario> usuariosDir = new List<Usuario>();

            try
            {
                usuarios = _dbcontext.Usuarios.ToList();

                if (idDir == 0)
                {
                    usuariosDir = usuarios;
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = usuariosDir });
                }
                else
                {
                    foreach (var usuario in usuarios)
                    {
                        if (usuario.IdDireccion == idDir)
                        {
                            usuariosDir.Add(usuario);
                        }
                    }
                }

                if (usuariosDir.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "No hay usuarios en esa dirección", response = usuariosDir });
                }

                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = usuariosDir });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER TODOS LOS USUARIOS A PARTIR DEL CARGO QUE OCUPAN
        [HttpGet]
        [Route("listByCargo/{idCargo:int}")]
        public IActionResult listByCargo(int idCargo)
        {
            List<Usuario> usuarios = new List<Usuario>();
            List<Usuario> usuariosCargo = new List<Usuario>();

            try
            {
                usuarios = _dbcontext.Usuarios.ToList();

                if (idCargo == 0)
                {
                    usuariosCargo = usuarios;
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = usuarios });
                }
                else
                {
                    foreach (var usuario in usuarios)
                    {
                        if (usuario.IdCargo == idCargo)
                        {
                            usuariosCargo.Add(usuario);
                        }
                    }
                }

                if (usuariosCargo.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "No hay usuarios en el cargo seleccionado", response = usuariosCargo });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = usuariosCargo });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA FILTRAR LOS USUARIOS POR NOMBRE
        [HttpGet]
        [Route("listByName/{nombre}")]
        public IActionResult listByName(String nombre)
        {
            List<Usuario> usuaios = new List<Usuario>();
            List<Usuario> usuariosName = new List<Usuario>();

            try
            {
                usuaios = _dbcontext.Usuarios.ToList();

                if (nombre == "")
                {
                    usuariosName = usuaios;
                }
                else
                {
                    foreach (var usuario in usuaios)
                    {
                        if (usuario.Nombre.ToLower().Contains(nombre.ToLower()))
                        {
                            usuariosName.Add(usuario);
                        }
                    }
                }

                if (usuariosName.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "No hay usuarios para mostrar", response = usuariosName });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = usuariosName });
                }
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

        //METODO PARA OBTENER SOLO LOS USUARIOS QUE TIENEN UN ROL ASIGNADO EN LA BD
        [HttpGet]
        [Route("listWithRole")]
        public IActionResult listWithRole()
        {
            List<Usuario> list = new List<Usuario>();

            try
            {
                list = _dbcontext.Usuarios.Where(u => u.IdRol != null).ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA ASIGNAR UN ROL A UN USUARIO DETERMINADO
        [HttpPut]
        [Route("asignar/{idusuario:int}/{idrol:int}")]
        public IActionResult asignar(int idusuario, int idrol)
        {
            Usuario usuario = _dbcontext.Usuarios.Find(idusuario);

            if (usuario is null)
            {
                return BadRequest("El usuario no existe");
            }

            try
            {
                usuario.IdRol = idrol;
                _dbcontext.Update(usuario);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "El rol ha sido asignado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA QUITARLE UN ROL A UN USUARIO
        [HttpPut]
        [Route("quitRole/{idusuario:int}")]
        public IActionResult quitRole(int idusuario)
        {
            Usuario usuario = _dbcontext.Usuarios.Find(idusuario);

            if (usuario == null)
            {
                return BadRequest("No se encuentra el usuario especificado");
            }

            try
            {
                usuario.IdRol = null;
                _dbcontext.Update(usuario);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "El usuario ya no cuenta con ningun rol" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
