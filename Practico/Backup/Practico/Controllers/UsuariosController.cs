using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practico.Models;

namespace Practico.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(UserModel user)
        {
            var dbContext = new dbUsuarioDataContext();
            var usuario = new Usuario
            {
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Email = user.Email,
                NombreUsuario = user.NombreUsuario,
                ClaveAcceso = user.ClaveAcceso,
                RolUsuario = user.RolUsuario.ToString()
            };
            dbContext.Usuarios.InsertOnSubmit(usuario);
            dbContext.SubmitChanges();
            TempData["operacion"] = "registrar";

            return RedirectToAction("ListaDeUsuarios");
        }
        public ActionResult ListaDeUsuarios()
        {
            var dbContext = new dbUsuarioDataContext();
            var lista = dbContext.Usuarios.ToList();
            var listaUsuarios = lista.Select(um => new UserModel
            {
                Nombre = um.Nombre,
                Apellido = um.Apellido,
                NombreUsuario = um.NombreUsuario,
                ClaveAcceso = um.ClaveAcceso,
                Email = um.Email,
                RolUsuario = (RolEnum) Enum.Parse(typeof(RolEnum), um.RolUsuario),
                Id = um.Id
            });
            return View(listaUsuarios.ToList());
        }

    }
}
