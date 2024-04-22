using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;

namespace Papeleria.Web.Controllers
{
    public class AdminController : Controller
    {
        private IRepositorioAdministrador _repositorioAdmins;
        private ICrearAdmin _crearAdmin;
        private IEditarAdmin _editarAdmin;
        public AdminController(IRepositorioAdministrador repositorioAdmins, ICrearAdmin crearAdmin, IEditarAdmin editarAdmin)
        {
            this._repositorioAdmins = repositorioAdmins;
            this._crearAdmin = crearAdmin;
            this._editarAdmin = editarAdmin;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            return View(_repositorioAdmins.FindAll());
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdministradorDTO adminDto)
        {
            try
            {
                this._crearAdmin.CrearAdmin(adminDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            Administrador admin = this._repositorioAdmins.FindByID(id);
            return View(admin);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdministradorDTO adminDto)
        {
            this._editarAdmin.EditarAdmin(adminDto);
            return View(adminDto);
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
