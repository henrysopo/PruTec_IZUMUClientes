using IZUMUClientes.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace IZUMUClientes.WebApi.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("GetListCliente")]
        public List<ClienteModels> GetListCliente()
        {
            var lista = new List<ClienteModels>();
            using (var conn = new SqlConnection(UI.CadenaSQL))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GET_IZUMU_CLIENTES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var cliente = new ClienteModels();
                        cliente.TipoDoc = rdr.GetString(0);
                        cliente.NumeroDocumento = rdr.GetString(1);
                        cliente.FechaNacimiento = rdr.GetDateTime(2);
                        cliente.PrimerNombre = rdr.GetString(3);
                        cliente.SegundoNombre = rdr.GetString(4);
                        cliente.PrimerApellido = rdr.GetString(5);
                        cliente.SegundoApellido = rdr.GetString(6);
                        cliente.Direccion = rdr.GetString(7);
                        cliente.NumeroCelular = rdr.GetString(8);
                        cliente.Email = rdr.GetString(9);
                        cliente.IdPlan = rdr.GetInt32(10);
                        cliente.NombrePlan = rdr.GetString(11);

                        lista.Add(cliente);
                    }
                }
            }
            return lista;
        }

        [HttpGet("GetCliente")]
        public ClienteModels GetCliente(string tipoDoc, string numDoc)
        {
            var cliente = new ClienteModels();
            using (var conn = new SqlConnection(UI.CadenaSQL))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GET_IZUMU_CLIENTESXDOC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TipoDoc", tipoDoc));
                cmd.Parameters.Add(new SqlParameter("@NumDoc", numDoc));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.Read())
                    {
                        cliente.TipoDoc = rdr.GetString(0);
                        cliente.NumeroDocumento = rdr.GetString(1);
                        cliente.FechaNacimiento = rdr.GetDateTime(2);
                        cliente.PrimerNombre = rdr.GetString(3);
                        cliente.SegundoNombre = rdr.GetString(4);
                        cliente.PrimerApellido = rdr.GetString(5);
                        cliente.SegundoApellido = rdr.GetString(6);
                        cliente.Direccion = rdr.GetString(7);
                        cliente.NumeroCelular = rdr.GetString(8);
                        cliente.Email = rdr.GetString(9);
                        cliente.IdPlan = rdr.GetInt32(10);
                        cliente.NombrePlan = rdr.GetString(11);
                    }
                }
            }
            return cliente;
        }

        [HttpPost("SaveCliente")]
        public bool SaveCliente(ClienteModels cliente)
        {
            //var lista = new List<ClienteModels>();
            using (var conn = new SqlConnection(UI.CadenaSQL))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_INSERT_IZUMUCLIENTES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TipoDoc", cliente.TipoDoc));
                cmd.Parameters.Add(new SqlParameter("@NumDoc", cliente.NumeroDocumento));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", cliente.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@PrimerNombre", cliente.PrimerNombre));
                cmd.Parameters.Add(new SqlParameter("@SegundoNombre", cliente.SegundoNombre));
                cmd.Parameters.Add(new SqlParameter("@PrimerApellido", cliente.PrimerApellido));
                cmd.Parameters.Add(new SqlParameter("@SegundoApellido", cliente.SegundoApellido));
                cmd.Parameters.Add(new SqlParameter("@Direccion", cliente.Direccion));
                cmd.Parameters.Add(new SqlParameter("@NumeroCelular", cliente.NumeroCelular));
                cmd.Parameters.Add(new SqlParameter("@Email", cliente.Email));
                cmd.Parameters.Add(new SqlParameter("@IdPlan", cliente.IdPlan));
                cmd.Parameters.Add(new SqlParameter("@NombrePlan", cliente.NombrePlan));

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                        return true;
                    else
                        return false;
                }
            }
        }


        [HttpPut("UpdateCliente")]
        public bool UpdateCliente(ClienteModels cliente)
        {
            //var lista = new List<ClienteModels>();
            using (var conn = new SqlConnection(UI.CadenaSQL))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_UPDATE_IZUMU_CLIENTES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TipoDoc", cliente.TipoDoc));
                cmd.Parameters.Add(new SqlParameter("@NumDoc", cliente.NumeroDocumento));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", cliente.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@PrimerNombre", cliente.PrimerNombre));
                cmd.Parameters.Add(new SqlParameter("@SegundoNombre", cliente.SegundoNombre));
                cmd.Parameters.Add(new SqlParameter("@PrimerApellido", cliente.PrimerApellido));
                cmd.Parameters.Add(new SqlParameter("@SegundoApellido", cliente.SegundoApellido));
                cmd.Parameters.Add(new SqlParameter("@Direccion", cliente.Direccion));
                cmd.Parameters.Add(new SqlParameter("@NumeroCelular", cliente.NumeroCelular));
                cmd.Parameters.Add(new SqlParameter("@Email", cliente.Email));
                cmd.Parameters.Add(new SqlParameter("@IdPlan", cliente.IdPlan));
                cmd.Parameters.Add(new SqlParameter("@NombrePlan", cliente.NombrePlan));

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                        return false;
                    else
                        return true;
                }
            }
        }

        [HttpDelete("DeleteCliente")]
        public bool DeleteCliente(string tipoDoc, string numDoc)
        {
            using (var conn = new SqlConnection(UI.CadenaSQL))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_DELETE_IZUMUCLIENTES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TipoDoc", tipoDoc));
                cmd.Parameters.Add(new SqlParameter("@NumDoc", numDoc));
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                        return false;
                    else
                        return true;
                }
            }
        }

        [HttpGet("GetTiposDoc")]
        public List<TipoDocModels> GetTiposDoc()
        {
            var lista = new List<TipoDocModels>();
            using (var conn = new SqlConnection(UI.CadenaSQL))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GET_IZUMU_TIPODOC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var tipoDoc = new TipoDocModels();
                        tipoDoc.TipoDoc = rdr[0].ToString();
                        tipoDoc.Descripcion = rdr.GetString(1);

                        lista.Add(tipoDoc);
                    }
                }
            }
            return lista;
        }

        [HttpGet("GetListPlan")]
        public List<PlanModels> GetListPlan()
        {
            var lista = new List<PlanModels>();
            using (var conn = new SqlConnection(UI.CadenaSQL))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GET_IZUMU_PLAN", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var plan = new PlanModels();
                        plan.IdPlan = rdr.GetInt32(0);
                        plan.NombrePlan = rdr.GetString(1);

                        lista.Add(plan);
                    }
                }
            }
            return lista;
        }
    }

    public static class UI
    {
        public static string? CadenaSQL { get; set; } = string.Empty;
    }
}
