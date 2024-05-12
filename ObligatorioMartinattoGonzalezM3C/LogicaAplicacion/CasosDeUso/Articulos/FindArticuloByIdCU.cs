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
    public class FindArticuloByIdCU : IEncontrarXIdArticulo
    {
        private IRepositorioArticulo _repositorioArticulo;
        public FindArticuloByIdCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public ArticuloDTO FindById(int id)
        {
            return ArticuloDTOMapper.ToDto(_repositorioArticulo.FindByID(id));
        }
    }
}
