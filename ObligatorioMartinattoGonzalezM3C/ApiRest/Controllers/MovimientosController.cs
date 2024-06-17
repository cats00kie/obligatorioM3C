using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.ApiRest.Controllers
{
    [Route("api/Movimientos")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
      
        private ICrearMovimiento _crearMov;
        private IGetAllMovs _getMovs;
        
        public MovimientosController(ICrearMovimiento crearMov, IGetAllMovs getAllMovs)
        {
            this._crearMov = crearMov;
            this._getMovs = getAllMovs;
        }

        [HttpGet("Page/{pageNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<MovimientoDTO>> GetMovs(int pageNumber)
        {
            if(pageNumber < 1) { return BadRequest("Pagina invalida."); }
            IEnumerable<MovimientoDTO> movs = this._getMovs.GetAllMovs(pageNumber);
            if(movs.Count() == 0) { return NoContent(); }
            return Ok(movs);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MovimientoDTO> CreateMovimiento([FromBody] MovimientoDTO MovDTO)
        {
            try
            {
                this._crearMov.CrearMovimiento(MovDTO);
                return Created("api/Movimientos", MovDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
