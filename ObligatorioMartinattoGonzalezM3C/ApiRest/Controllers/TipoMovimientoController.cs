using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// Metodo para traer todos los tipos de movimiento
        /// </summary>
        /// <returns>Lista con tipos de movimiento</returns>
        [HttpGet("")]
        public ActionResult<IEnumerable<TipoMovimientoDTO>> Get()
        {
            return Ok(this._getAllTMov.GetAllTMov());
        }
        /// <summary>
        /// Metodo para traer un tipo de movimiento dado un id
        /// </summary>
        /// <param name="id">id de tipo de movimiento</param>
        /// <returns>Nombre y Valor del tipo de movimiento</returns>
        [HttpGet("{id}")]
        public ActionResult<TipoMovimientoDTO> GetById(int id)
        {
            return Ok(this._getTMovById.FindById(id));
        }
        /// <summary>
        /// Metodo para crear un tipo de movimiento
        /// </summary>
        /// <param name="tMovDTO">El tipo de movimiento, incluye nombre, y si es un ingreso o egreso</param>
        /// <returns>Codigo 201 Created si el tipo fue creado.</returns>
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
        /// <summary>
        /// Metodo para Borrar un tipo de movimiento del sistema
        /// </summary>
        /// <param name="id">id de un tipo de movimiento</param>
        /// <returns>200 OK si fue borrado</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> DeleteTipo(int id)
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
        /// <summary>
        /// Metodo para editar un tipo de movimiento ya existente
        /// </summary>
        /// <param name="tMovDTO">Un tipo de movimiento, con los datos que se haya enviado para editar.</param>
        /// <returns>200 OK si fue editado</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> UpdateTipo([FromBody] TipoMovimientoDTO tMovDTO)
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
