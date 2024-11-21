using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_2_DS_IV_API_REST.Models.DB
{
    public class CalculosData
    {
        private string connectionString;

        public CalculosData()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        }

        public bool InsertCalculo(Calculos oCalculos)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertarCalculo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Operacion", oCalculos.Operacion);
                cmd.Parameters.AddWithValue("@Resultado", oCalculos.Resultado);
                cmd.Parameters.AddWithValue("@Operador", oCalculos.Operador);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool UpdateCalculo(Calculos oCalculos)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateCalculo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCalculo", oCalculos.ID);
                cmd.Parameters.AddWithValue("@Operacion", oCalculos.Operacion);
                cmd.Parameters.AddWithValue("@Resultado", oCalculos.Resultado);
                cmd.Parameters.AddWithValue("@Operador", oCalculos.Operador);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<Calculos> ListarCalculos()
        {
            List<Calculos> obListar = new List<Calculos>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCalculos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            obListar.Add(new Calculos()
                            {
                                ID = Convert.ToInt32(rdr["ID"]),
                                Operacion = rdr["Operacion"].ToString(),
                                Resultado = rdr["Resultado"].ToString(),
                                Operador = rdr["Operador"].ToString(),
                                Fecha = Convert.ToDateTime(rdr["Fecha"].ToString())
                            });
                        }
                    }

                    return obListar;
                }
                catch (Exception ex)
                {
                    return obListar;
                }
            }
        }
        public List<Calculos> ListarCalculosDESC()
        {
            List<Calculos> obListar = new List<Calculos>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("MostrarCalculos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            obListar.Add(new Calculos()
                            {
                                ID = Convert.ToInt32(rdr["ID"]),
                                Operacion = rdr["Operacion"].ToString(),
                                Resultado = rdr["Resultado"].ToString(),
                                Operador = rdr["Operador"].ToString(),
                                Fecha = Convert.ToDateTime(rdr["Fecha"].ToString())
                            });
                        }
                    }

                    return obListar;
                }
                catch (Exception ex)
                {
                    return obListar;
                }
            }
        }

        public Calculos ObtenerCalculo(int idCalculo)
        {
            Calculos calculos = new Calculos();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCalculosUnico", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCalculo", idCalculo);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            calculos = new Calculos()
                            {
                                ID = Convert.ToInt32(rdr["ID"]),
                                Operacion = rdr["Operacion"].ToString(),
                                Resultado = rdr["Resultado"].ToString(),
                                Operador = rdr["Operador"].ToString(),
                                Fecha = Convert.ToDateTime(rdr["Fecha"].ToString())
                            };
                        }
                    }
                    return calculos;
                }
                catch (Exception ex)
                {
                    return calculos;
                }
            }
        }

        public List<Calculos> ObtenerCalculo(string operador)
        {
            List<Calculos> calculosList = new List<Calculos>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCalculosOperador", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Operador", operador);

                try
                {
                    conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Calculos calculo = new Calculos()
                            {
                                ID = Convert.ToInt32(rdr["ID"]),
                                Operacion = rdr["Operacion"].ToString(),
                                Resultado = rdr["Resultado"].ToString(),
                                Operador = rdr["Operador"].ToString(),
                                Fecha = Convert.ToDateTime(rdr["Fecha"].ToString())
                            };
                            calculosList.Add(calculo);
                        }
                    }
                    return calculosList;
                }
                catch (Exception ex)
                {
                    // Log el error (opcional)
                    return new List<Calculos>();  // Retornar una lista vacía en caso de error
                }
            }
        }

        public bool DeleteCalculo(int idCalculo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteCalculo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCalculo", idCalculo);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}