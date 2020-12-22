using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practico.Models;

namespace Practico.Controllers
{
    public class PaginaRestringidaController : Controller
    {
        //
        // GET: /PaginaRestringida/

        public ActionResult Index()
        {
            return View();
        }
        /* [HttpPost]
        public ActionResult cambiarClave(string claveactual,string clavenueva)
        {
            var usuarioActual = Session["usuarioactual"] as UserModel;
            if (claveactual == usuarioActual.Clave)
            {
                usuarioActual.Clave = clavenueva;
            }
            else
            {
                return RedirectToAction("contraseñaErronea");
            }
            return RedirectToAction("Index");
        }*/
        [HttpPost]
        public ActionResult cambiarClave(string ClaveActual, string ClaveNueva)
        {
            var usuarioactual = Session["usuarioactual"] as UserModel;
            var dbContext = new dbUsuarioDataContext();
            var usuarios = dbContext.Usuarios.ToList();
            var models = new List<UserModel>();
            foreach (var usr in usuarios)
            { var model = new UserModel();
            model.ClaveAcceso = usr.ClaveAcceso;
            model.NombreUsuario = usr.NombreUsuario;
            models.Add(model);
            }
            foreach (var item in models)
            {
                if (item.NombreUsuario == usuarioactual.NombreUsuario)
                {
                    if (item.ClaveAcceso == ClaveActual)
                    {
                        item.ClaveAcceso = ClaveNueva;
                    }
                }
            }


            return View("ListaDeUsuarios","Usuarios");
        
        }

    }
}
