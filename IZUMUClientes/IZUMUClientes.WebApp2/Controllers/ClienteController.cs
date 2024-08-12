using IZUMUClientes.WebApp2.Models;
using IZUMUClientes.WebApp2.ServiceApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IZUMUClientes.WebApp2.Controllers
{
    public class ClienteController : Controller
    {

        private HttpClient _httpClient;
        private readonly IServiceApi _serviceApi;

        public ClienteController(IServiceApi serviceApi)
        {
            _httpClient = new HttpClient();
            _serviceApi = serviceApi;
        }


        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            List<ClienteModels> list = await _serviceApi.ListClientes();

            return View(list);
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(string tipoDoc, string numDoc)
        {
            ClienteModels detCliente = await _serviceApi.GetCliente(tipoDoc, numDoc);
            return View(detCliente);
        }

        // GET: Cliente/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(ClienteModels cliente)
        {
            try
            {
                var reponse = await _serviceApi.SaveCliente(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        [HttpGet]
        public ActionResult Edit(string tipoDoc, string numDoc)
        {
            return View();
        }

        // PUT: Cliente/Edit/5
        [HttpPut]
        public async  Task<ActionResult> Edit(ClienteModels cliente)
        {
            var reponse = await _serviceApi.EditCliente(cliente);
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(string tipoDoc, string numDoc, ClienteModels cliente)
        {
            var reponse = await _serviceApi.DeleteCliente(tipoDoc, numDoc);
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string tipoDoc, string numDoc)
        {
            var reponse = await _serviceApi.DeleteCliente(tipoDoc, numDoc);
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente
        public async Task<ActionResult> TiposDoc()
        {
            List<TipoDocModels> list = await _serviceApi.ListTipoDocs();

            return View(list);
        }

        // GET: Cliente
        public async Task<ActionResult> Planes()
        {
            List<PlanModels> list = await _serviceApi.ListPlanes();

            return View(list);
        }
    }
}
