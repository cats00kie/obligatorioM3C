using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/Pedidos")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private IGetPedidosDesc _getPedidosDesc;
        public PedidosController(IGetPedidosDesc getPedidosDesc)
        {
            _getPedidosDesc = getPedidosDesc;
        }


        // GET: api/<PedidosController>
        [HttpGet(Name = "GetAllPedidos")]
        public ActionResult<PedidoDTO> Get()
        {
            try
            {
                IEnumerable<PedidoDTO> pedidos = _getPedidosDesc.GetPedidosDesc();
                if (pedidos == null) return NoContent();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
