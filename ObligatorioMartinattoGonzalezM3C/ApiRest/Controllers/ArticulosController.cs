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


        public ArticulosController(IEncontrarArticulosOrd encontrarArticulosOrd, IGetPedidosDesc getPedidosDesc)
        {
            _encontrarArticulosOrd = encontrarArticulosOrd;
        }

        // GET api/<ArticulosController>
        [HttpGet(Name = "GetAllArticulos")]
        public ActionResult<IEnumerable<ArticuloDTO>> Get()
        {
            try
            {
                return Ok(_encontrarArticulosOrd.GetArticulosOrd());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
