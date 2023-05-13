using PruebaBestfacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PruebaBestfacar.Permisos;

namespace PruebaBestfacar.Controllers
{
    [Authorize]
    //[PermisosRolAttribute(Models.Rol.Usuario)]
    public class HomeController : Controller
    {
        private PruebaBFC db = new PruebaBFC();
        public ActionResult Index()
        {
            return View(db.Carrosel.ToList());
        }

        public ActionResult NoAutorizado()
        {
            ViewBag.Message = "NO TIENES PERMISOS DE ADMINISTRADOR";
            return View();
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session["Usuarios"] = null;
            return RedirectToAction("Index", "Access");
        }

        public ActionResult VehiculosPresentacion()
        {
            return View(db.Vehiculo.ToList());
        }

        public ActionResult VisualizarVehiculos()
        {
            return View(db.Vehiculo.ToList());
        }
    }
}