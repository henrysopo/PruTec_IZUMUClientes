using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using IZUMUClientes.WebApp2.Models;
using Newtonsoft.Json;

namespace IZUMUClientes.WebApp2.ServiceApi
{
    public class ServiceApi : IServiceApi
    {
        private HttpClient _httpClient;
        public ServiceApi()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7046/");
        }
        public async Task<List<ClienteModels>> ListClientes()
        {
            //ClientesModels clientes = new ClientesModels();
            List<ClienteModels> clientes = new List<ClienteModels>();
            HttpResponseMessage response = await _httpClient.GetAsync($"api/cliente/GetListCliente");

            response.EnsureSuccessStatusCode();
            if(response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                clientes = JsonConvert.DeserializeObject<List<ClienteModels>>(responseJson);
            }
            return clientes;
        }

        public async Task<ClienteModels> GetCliente(string tipoDoc, string numDoc)
        {
            ClienteModels cliente = new ClienteModels();
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format($"api/cliente/GetCliente?tipoDoc={tipoDoc}&numDoc={numDoc}"));

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                cliente = JsonConvert.DeserializeObject<ClienteModels>(responseJson);
            }
            return cliente;
        }

        public async Task<bool> SaveCliente(ClienteModels cliente)
        {
            bool respuesta = false;

            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("api/cliente/SaveCliente/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> EditCliente(ClienteModels cliente)
        {
            bool respuesta = false;

            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("api/cliente/UpdateCliente/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> DeleteCliente(string tipoDoc, string numDoc)
        {
            try
            {
                bool respuesta = false;
                HttpResponseMessage response = await _httpClient.DeleteAsync(string.Format($"api/cliente/DeleteCliente?tipoDoc={tipoDoc}&numDoc={numDoc}"));

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    respuesta = true;
                }

                return respuesta;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<List<TipoDocModels>> ListTipoDocs()
        {
            List<TipoDocModels> tiposDoc = new List<TipoDocModels>();
            HttpResponseMessage response = await _httpClient.GetAsync("api/cliente/GetTiposDoc");

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                tiposDoc = JsonConvert.DeserializeObject<List<TipoDocModels>>(responseJson);
            }
            return tiposDoc;
        }

        public async Task<List<PlanModels>> ListPlanes()
        {
            List<PlanModels> planes = new List<PlanModels>();
            HttpResponseMessage response = await _httpClient.GetAsync("api/cliente/GetListPlan");

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                planes = JsonConvert.DeserializeObject<List<PlanModels>>(responseJson);
            }
            return planes;
        }
    }
}



