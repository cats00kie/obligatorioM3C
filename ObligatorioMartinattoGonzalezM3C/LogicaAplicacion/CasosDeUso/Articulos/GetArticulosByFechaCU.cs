using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Articulos
{
    public class GetArticulosByFechaCU : IGetArticulosByFecha
    {
        private IRepositorioArticulo _repositorioArticulo;
        private IRepositorioConfig _repositorioConfig;
        public GetArticulosByFechaCU(IRepositorioArticulo repositorioArticulo, IRepositorioConfig repositorioConfig)
        {
            _repositorioArticulo = repositorioArticulo;
            this._repositorioConfig = repositorioConfig;
            _repositorioConfig = repositorioConfig;
        }
        public IEnumerable<ArticuloDTO> GetArticulosByFecha(DateTime startdate, DateTime enddate, int pag)
        {
            int size = this._repositorioConfig.FindByNombre("PageSize").Valor;
            return this._repositorioArticulo.GetMovidosByFecha(startdate, enddate, pag, size).Select(a => ArticuloDTOMapper.ToDto(a));
        }
    }
}
