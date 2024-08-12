using IZUMUClientes.WebApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMUClientes.WebApp2.ServiceApi
{
    public interface IServiceApi
    {
        Task<List<ClienteModels>> ListClientes();
        Task<ClienteModels> GetCliente(string tipoDoc, string numDoc);
        Task<bool> SaveCliente(ClienteModels cliente);
        Task<bool> EditCliente(ClienteModels cliente);
        Task<bool> DeleteCliente(string tipoDoc, string numDoc);
        Task<List<TipoDocModels>> ListTipoDocs();
        Task<List<PlanModels>> ListPlanes();


    }
}
