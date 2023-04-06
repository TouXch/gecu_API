using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public ContratoController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA OBTENER TODOS LOS TIPOS DE CONTRATOS DE LA BD
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<Contrato> contratos = new List<Contrato>();

            try
            {
                contratos = _dbcontext.Contratos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = contratos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }  

        //METODO PARA OBTENER UN CONTRATO A PARTIR DE SU ID
        [HttpGet]
        [Route("listById/{idcontrato:int}")]
        public IActionResult listById(int idcontrato)
        {
            Contrato contrato = new Contrato();
            try
            {
                contrato = _dbcontext.Contratos.Find(idcontrato);

                if (contrato == null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "No existe el contrato especificado" });
                }

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = contrato });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
