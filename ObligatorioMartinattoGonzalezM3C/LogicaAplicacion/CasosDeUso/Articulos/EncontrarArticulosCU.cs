using LogicaNegocio.Entidades;
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
    public class EncontrarArticulosCU : IEncontrarArticulos
    {
        private IRepositorioArticulo _repositorioArticulo;
        public EncontrarArticulosCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public IEnumerable<ArticuloDTO> EncontrarArticulos()
        {
            IEnumerable<Articulo> articulos = this._repositorioArticulo.FindAll();
            List<ArticuloDTO> articulosDTO = new List<ArticuloDTO>();
            foreach (Articulo articulo in articulos)
            {
                articulosDTO.Add(ArticuloDTOMapper.ToDto(articulo));
            }
            return articulosDTO;
        }
    }
}
