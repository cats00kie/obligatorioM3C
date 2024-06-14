using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TMov
{
    public class DeleteTMovCU : IDeleteTMov
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public DeleteTMovCU(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            this._repositorioTipoMovimiento = repositorioTipoMovimiento;
        }

        public void DeleteTMov(int id)
        {
            try
            {
                this._repositorioTipoMovimiento.Remove(id);
            }
            catch (TMovException e) { throw; }
            catch (Exception e) { throw; }
        }
    }
}
