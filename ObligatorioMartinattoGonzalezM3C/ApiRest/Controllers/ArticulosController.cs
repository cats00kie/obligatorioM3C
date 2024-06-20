using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/Articulos")]
    [ApiController]
    [Authorize]
    public class ArticulosController : ControllerBase
    {
        private IEncontrarArticulosOrd _encontrarArticulosOrd;
        private IGetArticulosByFecha _getArticulosByFecha;


        public ArticulosController(IEncontrarArticulosOrd encontrarArticulosOrd, IGetArticulosByFecha getArticulosByFecha)
        {
            _encontrarArticulosOrd = encontrarArticulosOrd;
            _getArticulosByFecha = getArticulosByFecha;
        }
        /// <summary>
        /// Metodo para traer todos los articulos.
        /// </summary>
        /// <returns>Articulos ordenados por nombre ascendentemente</returns>
        // GET api/<ArticulosController>
        [HttpGet("")]
        public ActionResult<IEnumerable<ArticuloDTO>> Get()
        {
            try
            {
                IEnumerable<ArticuloDTO> articulos =  _encontrarArticulosOrd.GetArticulosOrd();
                if (articulos == null) return NoContent();
                return Ok(articulos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Metodo para filtrar articulos que fueron usados en al menos un movimiento entre dos fechas.
        /// </summary>
        /// <param name="startdate">Fecha de inicio</param>
        /// <param name="enddate">Fecha de fin</param>
        /// <param name="pageNumber">Numero de paginado</param>
        /// <returns>Articulos que fueron movidos entre las dos fechas.</returns>
        [HttpGet("GetByFechas/Page/{pageNumber}/startdate={startdate}/enddate={enddate}")]
        public ActionResult<IEnumerable<ArticuloDTO>> GetByFechas(DateTime startdate, DateTime enddate, int pageNumber) 
        {
            if (pageNumber < 1) { return BadRequest("Pagina invalida."); }
            IEnumerable<ArticuloDTO> arts = this._getArticulosByFecha.GetArticulosByFecha(startdate, enddate, pageNumber);
            if (arts.Count() == 0) { return NoContent(); }
            return Ok(arts);
        }
    }
}
