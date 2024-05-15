using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Papeleria.LogicaAplicacion.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Articulos
{
    public class EncontrarArticulosOrdCU : IEncontrarArticulosOrd
    {
        private IRepositorioArticulo _repositorioArticulo;
        public EncontrarArticulosOrdCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public IEnumerable<ArticuloDTO> GetArticulosOrd()
        {
            return this._repositorioArticulo.FindAll().OrderBy(articulo => articulo.Nombre).Select(articulo => ArticuloDTOMapper.ToDto(articulo));
        }
    }
}
