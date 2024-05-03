using LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class ArticuloDTOMapper
    {
        public static ArticuloDTO ToDto(Articulo articulo)
        {
            return new ArticuloDTO(articulo);
        }

        public static Articulo FromDto(ArticuloDTO articuloDTO)
        {
            if (articuloDTO == null)
            {
                throw new NotImplementedException();
            }
            return new Articulo(articuloDTO.Id, articuloDTO.Nombre, articuloDTO.Codigo, articuloDTO.Descripcion, articuloDTO.Precio, articuloDTO.Stock);
        }
    }
}
