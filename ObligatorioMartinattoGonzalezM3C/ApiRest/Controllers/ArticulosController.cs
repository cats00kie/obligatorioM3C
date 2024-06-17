using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/Articulos")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IEncontrarArticulosOrd _encontrarArticulosOrd;
        private IGetArticulosByFecha _getArticulosByFecha;


        public ArticulosController(IEncontrarArticulosOrd encontrarArticulosOrd, IGetArticulosByFecha getArticulosByFecha)
        {
            _encontrarArticulosOrd = encontrarArticulosOrd;
            _getArticulosByFecha = getArticulosByFecha;
        }

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

        [HttpGet("GetByFechas/Page/{pageNumber}")]
        public ActionResult<IEnumerable<ArticuloDTO>> GetByFechas(DateTime startdate, DateTime enddate, int pageNumber) 
        {
            if (pageNumber < 1) { return BadRequest("Pagina invalida."); }
            IEnumerable<ArticuloDTO> arts = this._getArticulosByFecha.GetArticulosByFecha(startdate, enddate, pageNumber);
            if (arts.Count() == 0) { return NoContent(); }
            return Ok(arts);
        }
    }
}
