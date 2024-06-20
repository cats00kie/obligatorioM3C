using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.ApiRest.Controllers
{
    [Route("api/Movimientos")]
    [ApiController]
    [Authorize]
    public class MovimientosController : ControllerBase
    {
      
        private ICrearMovimiento _crearMov;
        private IGetAllMovs _getMovs;
        private IGetByArtyTipo _getByArtyTipo;
        private IGetMovsXFecha _getMovsXFecha;
        
        public MovimientosController(ICrearMovimiento crearMov, IGetAllMovs getAllMovs, IGetByArtyTipo getByArtyTipo, IGetMovsXFecha getMovsXFecha)
        {
            this._crearMov = crearMov;
            this._getMovs = getAllMovs;
            this._getByArtyTipo = getByArtyTipo;
            this._getMovsXFecha = getMovsXFecha;
        }
        /// <summary>
        /// Metodo para traer todos los movimientos.
        /// </summary>
        /// <param name="pageNumber">Parametro para el numero de pagina.</param>
        /// <returns>Todos los movimientos, su articulo y su tipo de movimiento.</returns>

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
        /// <summary>
        /// Metodo para filtrar los movimientos por un articulo y un tipo de movimiento
        /// </summary>
        /// <param name="articuloId">ID del articulo</param>
        /// <param name="tipoId">ID del tipo de movimiento</param>
        /// <param name="pageNumber">numero de pagina</param>
        /// <returns>Todos los movimientos del mismo tipo y mismo articulo.</returns>
        [HttpGet("GetByArtyTipo/Page/{pageNumber}/Articulo={articuloId}/Tipo={tipoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<MovimientoDTO>> GetByArtyTipo(int articuloId, int tipoId, int pageNumber)
        {
            if (pageNumber < 1) { return BadRequest("Pagina invalida."); }
            IEnumerable<MovimientoDTO> movs = this._getByArtyTipo.GetByArtyTipo(articuloId, tipoId, pageNumber);
            if (movs.Count() == 0) { return NoContent(); }
            return Ok(movs);
        }
        /// <summary>
        /// Metodo para traer las cantidades movidas agrupadas por año, y dentro de año por tipo de movimiento.
        /// </summary>
        /// <returns>Cantidades movidas agrupadas por año, y dentro de año por tipo de movimiento.</returns>
        [HttpGet("GetMovsXFecha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<FechaDTO>> GetMovsXFecha()
        {
            IEnumerable<FechaDTO> movs = this._getMovsXFecha.GetMovsXFecha();
            if (movs.Count() == 0) { return NoContent(); }
            return Ok(movs);
        }
        /// <summary>
        /// Metodo para registrar un movimiento en la base de datos.
        /// </summary>
        /// <param name="MovDTO">El articulo que se mueve, el tipo de movimiento, y la cantidad de unidades movidas.</param>
        /// <returns></returns>
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
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
