using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;

namespace Papeleria.Web.Controllers
{
    public class AdminController : Controller
    {
        private ICrearAdmin _crearAdmin;
        private IEditarAdmin _editarAdmin;
        private IEncontrarAdmins _encontrarAdmins;
        private IFindAdminById _findAdminById;
        private IBorrarAdmin _borrarAdmin;
        public AdminController(ICrearAdmin crearAdmin, IEditarAdmin editarAdmin, 
            IEncontrarAdmins encontrarAdmins, IFindAdminById findAdminById, IBorrarAdmin borrarAdmin)
        {
            this._encontrarAdmins = encontrarAdmins;
            this._crearAdmin = crearAdmin;
            this._editarAdmin = editarAdmin;
            this._findAdminById = findAdminById;
            this._borrarAdmin = borrarAdmin;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            return View(_encontrarAdmins.FindAllAdmins());
        }

        // GET: AdminController/Create
        public ActionResult Create(string mensaje)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            ViewBag.mensaje = mensaje;
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO adminDto)
        {
            try
            {
                this._crearAdmin.CrearAdmin(adminDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Create", new {mensaje = ex.Message});
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            UsuarioDTO admin = this._findAdminById.FindAdminById(id);
            return View(admin);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioDTO adminDto)
        {
            this._editarAdmin.EditarAdmin(adminDto);
            return View(adminDto);
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            UsuarioDTO admin = this._findAdminById.FindAdminById(id);
            return View(admin);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioDTO admin, int id)
        {
            this._borrarAdmin.BorrarAdmin(id);
            return RedirectToAction("Index");
        }
    }
}
