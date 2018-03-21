using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intento2.Models;

namespace Intento2.Controllers
{
    public class CargoController : Controller
    {
        EstudianteEntities baseDt = new EstudianteEntities();
        public ActionResult Index()
        {
            // carga la variable con los que retorna la tabla cargos
            var listaCargos = baseDt.Cargos;
            // lo que va a retornar es una lista para eso el Tolist()
            return View(listaCargos.ToList());
        }

        //Lista las categorias como enlaces  
        public ActionResult listadoMaestroCargos()
        {
            var listaCargos = baseDt.Cargos;
            return View(listaCargos.ToList());
        }
        //Metodo que lista los usuario que pertenecen a deteminado cargo

        public ActionResult usuarioXCargo(string cargo)
        {
            // modelo recibe una consulta Linq
            var modelo = from p in baseDt.UsuarioPro where p.Cargos.nomCargo == cargo select p;
            return View(modelo.ToList());
        }

        // Lista los usuarios y la descripción

        public ActionResult ListUsurioDescripCargo()
        {
            //Query linq 
            var modelo = from p in baseDt.UsuarioPro
                         join car in baseDt.Cargos on p.fkIdCargo equals car.IdCargo
                         select new Usuario
                         {
                             idUsuario = p.idUsuario,
                             nomUsuario = p.nomUsuario,
                             nomCargo = car.nomCargo

                         };
            return View(modelo.ToList());
        }
    }
}