using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;

namespace Papeleria.ApiRest.Controllers
{
    [Route("api/TipoMovimientos")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        //TODO: Hacer los summaries de las apis
        private IGetAllTMov _getAllTMov;
        private ICrearTMov _crearTMov;
        private IFindTMovById _getTMovById;
        private IDeleteTMov _deleteTMov;
        private IUpdateTMov _updateTMov;

        public TipoMovimientoController(IGetAllTMov getAllTMov, ICrearTMov crearTMov, IFindTMovById getTMovById, IDeleteTMov deleteTMov, IUpdateTMov updateTMov)
        {
            _getAllTMov = getAllTMov;
            _crearTMov = crearTMov;
            _getTMovById = getTMovById;
            _deleteTMov = deleteTMov;
            _updateTMov = updateTMov;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TipoMovimientoDTO>> Get()
        {
            return Ok(this._getAllTMov.GetAllTMov());
        }

        [HttpGet("{id}")]
        public ActionResult<TipoMovimientoDTO> GetById(int id)
        {
            return Ok(this._getTMovById.FindById(id));
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> CreateMovimiento([FromBody] TipoMovimientoDTO tMovDTO)
        {
            try
            {
                this._crearTMov.CrearTMov(tMovDTO);
                return Created("api/TipoMovimientos", tMovDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> DeleteTeam(int id)
        {
            try
            {
                this._deleteTMov.DeleteTMov(id);
                return Ok("Tipo Movimiento " + id + " borrado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> UpdateTeam([FromBody] TipoMovimientoDTO tMovDTO)
        {
            try
            {
                this._updateTMov.UpdateTMov(tMovDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
