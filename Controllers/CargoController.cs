using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using gecu_API.Models;

namespace gecu_API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        public readonly GecubdContext _dbcontext;

        public CargoController(GecubdContext _context)
        {
            _dbcontext = _context;
        }

        //METODO PARA OBTENER TODOS LOS CARGOS DE LA BD
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            List<Cargo> cargoList = new List<Cargo>();

            try
            {
                cargoList = _dbcontext.Cargos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = cargoList });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        //METODO PARA OBTENER UN CARGO A PARTIR DEL ID
        [HttpGet]
        [Route("listById/{idcargo:int}")]
        public IActionResult listById(int idcargo)
        {
            Cargo cargo = new Cargo();

            try
            {
                cargo = _dbcontext.Cargos.Find(idcargo);

                if (cargo is null)
                {
                    return BadRequest("El cargo no existe");
                }

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = cargo });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
