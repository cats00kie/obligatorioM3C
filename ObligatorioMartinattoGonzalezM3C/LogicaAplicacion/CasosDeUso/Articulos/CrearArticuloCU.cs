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
    public class CrearArticuloCU : ICrearArticulo
    {
        private IRepositorioArticulo _repositorioArticulo;
        public CrearArticuloCU(IRepositorioArticulo repositorioArticulo) {
            _repositorioArticulo = repositorioArticulo;
        }
        public void CrearArticulo(ArticuloDTO aCrear)
        {
            try
            {
                Articulo articulo = ArticuloDTOMapper.FromDto(aCrear);
                articulo.IsValid();
                _repositorioArticulo.Add(articulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
