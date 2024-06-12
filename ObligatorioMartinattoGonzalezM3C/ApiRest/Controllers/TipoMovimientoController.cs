using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;

namespace Papeleria.ApiRest.Controllers
{
    [Route("api/TipoMovimientos")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {

        private IGetAllTMov _getAllTMov;
        private ICrearTMov _crearTMov;
        //private IFindTMovById _getTMovById;
        //private IDeleteTMov _deleteTMov;
        //private IUpdateTMov _updateTMov;

        public TipoMovimientoController(IGetAllTMov getAllTMov, ICrearTMov crearTMov/*, IFindTMovById getTMovById, IDeleteTMov deleteTMov, IUpdateTMov updateTMov*/)
        {
            _getAllTMov = getAllTMov;
            _crearTMov = crearTMov;
            //_getTMovById = getTMovById;
            //_deleteTMov = deleteTMov;
            //_updateTMov = updateTMov;
        }

        [HttpGet(Name = "GetAllTMov")]
        public ActionResult<IEnumerable<TipoMovimientoDTO>> Get()
        {
            return Ok(this._getAllTMov.GetAllTMov());
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> CreateTeam([FromBody] TipoMovimientoDTO tMovDTO)
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

        //[HttpDelete("{teamId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult<TipoMovimientoDTO> DeleteTeam(int id)
        //{
        //    try
        //    {
        //        this._deleteTMov.BorrarTMov(id);
        //        return Ok("Tipo Movimiento " + id + " borrado correctamente");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut("{teamId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult<TipoMovimientoDTO> UpdateTeam([FromBody] TipoMovimientoDTO tMovDTO)
        //{
        //    try
        //    {
        //        this._updateTMov.UpdateTMov(tMovDTO);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
