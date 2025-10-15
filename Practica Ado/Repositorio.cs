using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Ado
{
    public class RepositorioSocios
    {
        private List<Socios> listasocios;
        private string conexion = "Data Source=LAPTOP-IQ1OBU3N\\SQLEXPRESS;Initial Catalog=club;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False;";

        public RepositorioSocios()
        {
            listasocios = new List<Socios>();
        }

        public string Agregar(Socios socios)
        {
            string query = "INSERT INTO Socios(nombre, apellido, DNI, fecha_nacimiento, NumeroSocio, cuota_al_dia) VALUES (@nombre, @apellido, @DNI, @fecha_nacimiento, @NumeroSocio, @cuota_al_dia)";
            try
            {
                var SocioRepetido = listasocios.FirstOrDefault(s => s.DNI == socios.DNI);
                if (SocioRepetido == null)
                {
                    using (SqlConnection conn = new SqlConnection(conexion))
                    {
                        conn.Open();
                        SqlCommand comando = new SqlCommand(query, conn);
                        comando.Parameters.AddWithValue("@nombre", socios.nombre);
                        comando.Parameters.AddWithValue("@apellido", socios.apellido);
                        comando.Parameters.AddWithValue("@DNI", socios.DNI);
                        comando.Parameters.AddWithValue("@fecha_nacimiento", socios.fecha_nacimiento);
                        comando.Parameters.AddWithValue("@NumeroSocio", socios.NumeroSocio);
                        comando.Parameters.AddWithValue("@cuota_al_dia", socios.cuota_al_dia);
                        comando.ExecuteNonQuery();
                        conn.Close();
                    }
                    return "Socio agregado correctamente";
                }
                else
                {
                    return "El socio ya existe";
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error: " + ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }

        public List<Socios> Listar()
        {
            string query = "SELECT * FROM Socios";
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    SqlCommand comando = new SqlCommand(query, conn);
                    SqlDataReader reader = comando.ExecuteReader();


                    while (reader.Read())
                    {
                        Socios socios = new Socios();
                        socios.id = Convert.ToInt32(reader["id"]);
                        socios.nombre = reader["nombre"].ToString();
                        socios.apellido = reader["apellido"].ToString();
                        socios.DNI = reader["dni"].ToString();
                        socios.fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]);
                        socios.NumeroSocio = Convert.ToInt32(reader["numero_socio"]);
                        socios.cuota_al_dia = Convert.ToBoolean(reader["cuota_al_dia"]);
                        listasocios.Add(socios);
                    }
                    conn.Close();
                    return listasocios;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error: " + ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }

        public string Eliminar(int id)
        {
            string query = "DELETE FROM Socios WHERE id = @id";
            try
            {
                var socio = listasocios.FirstOrDefault(s => s.id == id);
                if (socio != null)
                {
                    using (SqlConnection conn = new SqlConnection(conexion))
                    {
                        conn.Open();
                        SqlCommand comando = new SqlCommand(query, conn);
                        comando.Parameters.AddWithValue("@id", id);
                        comando.ExecuteNonQuery();
                        conn.Close();
                    }
                    listasocios.Remove(socio);
                    return "Socio eliminado correctamente";
                }
                else
                {
                    return "El socio no existe";
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error: " + ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }

        public string Modificar(Socios socios)
        {
            string query = "UPDATE Socios SET nombre = @nombre, apellido = @apellido, DNI = @DNI, fecha_nacimiento = @fecha_nacimiento, NumeroSocio = @NumeroSocio, cuota_al_dia = @cuota_al_dia WHERE id = @id";
            try
            {
                var socio = listasocios.FirstOrDefault(s => s.id == socios.id);
                if (socio != null)
                {
                    using (SqlConnection conn = new SqlConnection(conexion))
                    {
                        conn.Open();
                        SqlCommand comando = new SqlCommand(query, conn);
                        comando.Parameters.AddWithValue("@id", socios.id);
                        comando.Parameters.AddWithValue("@nombre", socios.nombre);
                        comando.Parameters.AddWithValue("@apellido", socios.apellido);
                        comando.Parameters.AddWithValue("@DNI   ", socios.DNI);
                        comando.Parameters.AddWithValue("@fecha_nacimiento", socios.fecha_nacimiento);
                        comando.Parameters.AddWithValue("@NumeroSocio", socios.NumeroSocio);
                        comando.Parameters.AddWithValue("@cuota_al_dia", socios.cuota_al_dia);
                        comando.ExecuteNonQuery();
                        conn.Close();
                    }
                    return "Socio modificado correctamente";
                }
                else
                {
                    return "El socio no existe";
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error: " + ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }


        }
    }
}
