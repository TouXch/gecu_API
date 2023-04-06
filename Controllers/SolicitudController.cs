using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        public readonly GecubdContext _dbcontext = new GecubdContext();

        public SolicitudController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA LISTAR TODAS LAS SOLICITUDES
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<Solicitud> solicitudes = new List<Solicitud>();

            try
            {
                solicitudes = _dbcontext.Solicituds.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = solicitudes });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER TODAS LA CANTIDAD DE SOLICITUDES PENDIENTES
        [HttpGet]
        [Route("pendientes")]
        public IActionResult pendientes()
        {
            int pendientes = 0;
            List<Solicitud> pendientesList = new List<Solicitud>();
            List<Solicitud> aux = new List<Solicitud>();
            try
            {
                aux = _dbcontext.Solicituds.ToList();
                aux = _dbcontext.Solicituds.ToList();
                foreach (var item in aux)
                {
                    if (item.EstadoSolicitud == 1 || item.EstadoSolicitud == 2 || item.EstadoSolicitud == 3)
                    {
                        pendientesList.Add(item);
                    }
                }
                pendientes = pendientesList.Count;
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = pendientes });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER TODAS LAS SOLICITUDES QUE ESTEN PENDIENTES
        [HttpGet]
        [Route("listPendientes")]
        public IActionResult listPendientes()
        {
            List<Solicitud> pendientesList = new List<Solicitud>();
            List<Solicitud> aux = new List<Solicitud>();

            try
            {
                aux = _dbcontext.Solicituds.ToList();
                foreach (var item in aux)
                {
                    if (item.EstadoSolicitud == 1 || item.EstadoSolicitud == 2 || item.EstadoSolicitud == 3)
                    {
                        pendientesList.Add(item);
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = pendientesList });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER LAS SOLICITUDES A PARTIR DEL NOMBRE
        [HttpGet]
        [Route("listByName/{nombre}")]
        public IActionResult listByName(String nombre)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            List<Solicitud> solicitudesName = new List<Solicitud>();

            try
            {
                solicitudes = _dbcontext.Solicituds.ToList();

                if (nombre == "")
                {
                    solicitudesName = solicitudes;
                }
                else
                {
                    foreach (var solicitud in solicitudes)
                    {
                        if (solicitud.Nombre.ToLower().Contains(nombre.ToLower()))
                        {
                            solicitudesName.Add(solicitud);
                        }
                    }
                }

                if (solicitudesName.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "No hay solicitudes para mostrar", response = solicitudesName });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = solicitudesName });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER LAS SOLICITUDES QUE ESTAN EN EL MISMO ESTADO
        [HttpGet]
        [Route("listByState/{idestado:int}")]
        public IActionResult lisByState(int idestado)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            List<Solicitud> solicitudesState = new List<Solicitud>();

            try
            {
                solicitudes = _dbcontext.Solicituds.ToList();

                if (idestado == 0)
                {
                    solicitudesState = solicitudes;
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = solicitudesState });
                }
                else
                {
                    foreach (var solicitud in solicitudes)
                    {
                        if (solicitud.EstadoSolicitud == idestado)
                        {
                            solicitudesState.Add(solicitud);
                        }
                    }
                }

                if (solicitudesState.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "No hay solicitudes en ese estado", response = solicitudesState });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = solicitudesState });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER LAS SOLICITUDES A PARTIR DE SU TIPO
        [HttpGet]
        [Route("listByType/{idtipo:int}")]
        public IActionResult listByType(int idtipo)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            List<Solicitud> solicitudesType = new List<Solicitud>();

            try
            {
                solicitudes = _dbcontext.Solicituds.ToList();

                if (idtipo == 0)
                {
                    solicitudesType = solicitudes;
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = solicitudesType });
                }
                else
                {
                    foreach (var solicitud in solicitudes)
                    {
                        if (solicitud.TipoSolicitud == idtipo)
                        {
                            solicitudesType.Add(solicitud);
                        }
                    }
                }

                if (solicitudesType.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "No hay solicitudes en ese estado", response = solicitudesType });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = solicitudesType });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

    }
}
