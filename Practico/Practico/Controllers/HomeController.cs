using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practico.Models;
using System.Web.Security;

namespace Practico.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            var usuarioactual = Session["usuarioactual"] as UserModel;
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

            foreach (var item in listaUsuarios)
            {
                if (item.NombreUsuario == model.NombreUsuario)
                {
                    if (item.ClaveAcceso == model.ClaveAcceso)
                    {
                        usuarioactual = item;
                        Session["usuarioactual"] = usuarioactual;
                    }
                }
            }


            return RedirectToAction("ListaDeUsuarios", "Usuarios");
        }


        public ActionResult logOut()
        {
           

            Session.Abandon();

            FormsAuthentication.SignOut();

            return View();
        }


    }
}
