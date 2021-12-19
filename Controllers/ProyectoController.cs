using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_1.Controllers
{
    public class ProyectoController : Controller
    {
        //atributos, instancias
        private readonly IMemoryCache _cache;

        //constructor con parametros
        public ProyectoController(IMemoryCache cache)
        {
            _cache = cache;
        }//fin constructor con parametros

        /*
         * este metodo funciona para obtener una lista de proyectos almacenada en la memoria cache
         */
        public List<Models.Proyecto> ObtenerLista()
        {
            List<Models.Proyecto> resultado;//instancia de una lista tipo List
            //preguntamos si la lista de proyectos esta vacia 
            if (_cache.Get("ListaDeProyectos") is null)
            {
                //llenamos la lista con metodo set
                resultado = new List<Models.Proyecto>();
                _cache.Set("ListaDeProyectos", resultado);
            }//fin if lista de cliente vacia
            else
            {
                //llenamos la lista con los datos almacenados en la memoria cache
                resultado = (List<Models.Proyecto>)_cache.Get("ListaDeProyectos");

            }//fin else lista de proyectos no vacia
            return resultado;
        }//fin ObtenerLista

        /*
         * recibimos para filtrar por cedula de cliente
         */
        // GET: ProyectoController
        public ActionResult Index()
        {
            //para llenar la cedula del cliente dueno de proyecto
            //ClienteController clienteController = new ClienteController(ClienteController._cache);
            //List<Models.Cliente> listaDeClientes = new List<Models.Cliente>();
            //listaDeClientes = clienteController.ObtenerLista();
            //listaDeClientes = ClienteController.ObtenerLista();

            //colocar lista de cedulas para identificador de cliente dueno de proyecto
            //List<int> listaDeCedulas = new List<int>();
            ////llenamos la lista
            //foreach (Models.Cliente cliente in listaDeClientes)
            //{
            //    if (cliente is not null)
            //    {
            //        listaDeCedulas.Add(cliente.CedulaCliente);
            //    }
            //}//fin foreach
            //ViewBag.ListaDeCedulas = new SelectList(listaDeCedulas);
            //fin llenar la cedula del cliente dueno de proyecto

            //prueba
            //List<SelectListItem> mySkills = new List<SelectListItem>() {
            //    new SelectListItem {
            //        Text = "ASP.NET MVC", Value = "1"
            //    },
            //};
            //ViewData["My Skills"] = mySkills;
            //fin prueba

            //autogenerar IDProyecto
            //Random random = new Random();
            //int idRandom;
            //idRandom = random.Next(1, 10001);
            //ViewBag.IDProyecto = idRandom;
            //fin autogenerar IDProyecto

            List<Models.Proyecto> listaDeProyectos = ObtenerLista();//lista de proyectos
            return View(listaDeProyectos);//devuelve la lista de proyectos
        }

        // GET: ProyectoController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: ProyectoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProyectoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Proyecto proyecto)
        {
            try
            {
                List<Models.Proyecto> listaDeProyectos;//instancia de una lista tipo List
                listaDeProyectos = ObtenerLista();//llenamos la lista con la lista de proyectos en la memoria cache
                listaDeProyectos.Add(proyecto);//agregamos un nuevo objeto Proyecto a la lista de proyectos
                ////verificar si lista de clientes esta vacia
                //if (cliente is null)
                //{
                //    ViewBag.Mensaje = "No hay clientes registrados, no puede crear proyectos.";
                //    return View("Index", listaDeProyectos);
                //}//fin if no hay datos en la lista de clientes
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProyectoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProyectoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ProyectoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProyectoController/Delete/5
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
