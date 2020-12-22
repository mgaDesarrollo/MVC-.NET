using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finalProg.Models;

namespace finalProg.Controllers
{
    public class AutomovilController : Controller
    {
        //
        // GET: /Automovil/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        { return View(); }


        [HttpPost]
        public ActionResult Registrar(AutoModel model)
        {

            var dbContext = new dbAutoDataContext();



            var x = new Automovil
            {
                Modelo = model.Modelo,
                Patente = model.Patente,
                Marca = model.Marca
            };


            dbContext.Automovils.InsertOnSubmit(x);
            dbContext.SubmitChanges();

            TempData["operacion"] = "registrar";
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Lista()
        {

            var dbContext = new dbAutoDataContext();
            var automovil = dbContext.Automovils.ToList();


            var models = new List<AutoModel>();

            foreach (var car in automovil)
            {
                var model = new AutoModel();
                model.Patente = car.Patente;
                model.Marca = car.Marca;
                model.Modelo = car.Modelo;


                models.Add(model);
            }

            return View(models);
        }

    }
}
