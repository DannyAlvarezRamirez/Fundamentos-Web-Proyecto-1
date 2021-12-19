using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_1.Controllers
{
    public class ClienteController : Controller
    {
        //atributos, instancias
        static public IMemoryCache _cache;

        //constructor con parametros
        public ClienteController(IMemoryCache cache)
        {
            _cache = cache;
        }//fin constructor con parametros

        /*
         * este metodo funciona para obtener una lista de clientes almacenada en la memoria cache
         */
        static public List<Models.Cliente> ObtenerLista()
        {
            List<Models.Cliente> resultado;//instancia de una lista tipo List
            //preguntamos si la lista de clientes esta vacia 
            if (_cache.Get("ListaDeClientes") is null)
            {
                //llenamos la lista con metodo set
                resultado = new List<Models.Cliente>();
                _cache.Set("ListaDeClientes", resultado);
            }//fin if lista de cliente vacia
            else
            {
                //llenamos la lista con los datos almacenados en la memoria cache
                resultado = (List<Models.Cliente>)_cache.Get("ListaDeClientes");
            }//fin else lista de clientes no vacia
            return resultado;
        }//fin ObtenerLista

        public Boolean BuscarCedula(int cedulaCliente)
        {
            Boolean respuesta = false;
            List<Models.Cliente> listaDeClientes;//instancia de una lista tipo List
            listaDeClientes = ObtenerLista();//llenamos la lista con datos de la memoria cache
            foreach (Models.Cliente clientes in listaDeClientes)
            {
                if (clientes.intCedulaCliente == cedulaCliente)
                {
                    respuesta = true;
                }//fin if
            }//fin foreach
            return respuesta;
        }//fin BuscarCedula

        // GET: ClienteController default
        public ActionResult Index()
        {
            List<Models.Cliente> listaDeClientes;//instancia de una lista tipo List
            listaDeClientes = ObtenerLista();//llenamos la lista con datos de la memoria cache
            return View(listaDeClientes);
        }

        // GET: ClienteController
        public ActionResult ListaClientes(int cedulaCliente)
        {
            List<Models.Cliente> listaDeClientes;//instancia de una lista tipo List
            listaDeClientes = ObtenerLista();//llenamos la lista con datos de la memoria cache
            
            if (!BuscarCedula(cedulaCliente))
            {
                //devolver mensaje que usuario no existe
                ViewBag.Mensaje = "El cliente no existe";
                //fin mensaje
                return View("Index", listaDeClientes);
            }
            else
            {
                List<Models.Cliente> listaDeClientesFiltrada;//lista para mostrar filtrada
                listaDeClientesFiltrada = listaDeClientes.Where(x => x.intCedulaCliente == cedulaCliente).ToList();
                return View("ListaClientes", listaDeClientesFiltrada);
            }
        }

        // GET: ClienteController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        /*
         * este metodo recibe por parametros un objeto tipo Cliente 
         */
        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Cliente cliente)
        {
            try
            {
                List<Models.Cliente> listaDeClientes;//instancia de una lista tipo List
                listaDeClientes = ObtenerLista();//llenamos la lista con la lista de clientes en la memoria cache
                //verificar que la cedula no se repita
                if (!BuscarCedula(cliente.intCedulaCliente)) {
                    listaDeClientes.Add(cliente);//agregamos un nuevo objeto Cliente a la lista de clientes
                }//fin if no existe
                else
                {
                    ViewBag.Mensaje = "La cedula digitada para el cliente ya existe, el cliente no se creo!";
                    //fin mensaje
                    return View("Index", listaDeClientes);
                    //mensaje de cliente ya existe
                }//fin else si existe
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /*
         * recibimos como parametro un identificador(cedula) del cliente
         * este metodo funciona para identificar o buscar un cliente en especifico y mostrarlo en la 
         * interfaz de usuario
         */
        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            List<Models.Cliente> listaDeClientes;//instancia de una lista tipo List
            Models.Cliente cliente;//creamos una intancia de un objeto Cliente
            listaDeClientes = ObtenerLista();//llenamos la lista con la lista de clientes en la memoria cache
            cliente = listaDeClientes.Find(x => x.intCedulaCliente == id);//llenamos el objeto Cliente con la misma informacion del Cliente que se encuentra almacenado en la lista de la memoria cache 
            return View(cliente);//retornamos la informacion del objeto Cliente
        }

        /*
         * recibimos por parametros un objeto Cliente
         * Este metodo funciona para modificar un cliente
         */
        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Cliente cliente)
        {
            try
            {
                List<Models.Cliente> listaDeClientes;//instancia de una lista tipo List
                Models.Cliente clienteAModificar;//creamos una intancia de un objeto Cliente que se va a modificar
                listaDeClientes = ObtenerLista();//llenamos la lista con la lista de clientes en la memoria cache
                clienteAModificar = listaDeClientes.Find(x => x.intCedulaCliente == cliente.intCedulaCliente);//llenamos el objeto Cliente con la misma informacion del Cliente que se encuentra almacenado en la lista de la memoria cache
                //se modifican la informacion del objeto Cliente identificado
                clienteAModificar.TelefonoCliente = cliente.TelefonoCliente;
                clienteAModificar.NombreCompletoCliente = cliente.NombreCompletoCliente;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
