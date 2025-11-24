using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;

namespace prueba_de_crud
{
    public class Almacenar
    {
        public static int AgregarDatos(Personas1 persona1)
        {
            int retorna = 0;

            using (SqlConnection conexion = BD_gereral.obtenerConexion())
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    string query = "insert into Productos (Nombre,Descripcion,Marca,Precio,Stock) values( @Nombre, @Descripcion, @Marca, @Precio, @Stock)";
                    SqlCommand comando = new SqlCommand(query, conexion);

                   // comando.Parameters.AddWithValue("@Id", persona1.Id);
                    comando.Parameters.AddWithValue("@Nombre", persona1.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", persona1.Descripcion);
                    comando.Parameters.AddWithValue("@Marca", persona1.Marca);
                    comando.Parameters.AddWithValue("@Precio", persona1.Precio);  // Asegúrate que Precio sea del tipo adecuado
                    comando.Parameters.AddWithValue("@Stock", persona1.Stock);

                    retorna = comando.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("No esta abierta");
                }
                return retorna;
            }

        }

        public static List<Personas1> MostrarRegistro()
        {
            List<Personas1> Lista = new List<Personas1>();

            using (SqlConnection conexion = BD_gereral.obtenerConexion())
            {
                string query = "select * from Productos";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Personas1 personas1 = new Personas1();
                    personas1.id = reader.GetInt32(0);
                    personas1.Nombre = reader.GetString(1);
                    personas1.Descripcion = reader.GetString(2);
                    personas1.Marca = reader.GetString(3);
                    personas1.Precio = reader.GetInt32(4);
                    personas1.Stock = reader.GetInt32(5);
                    Lista.Add(personas1);

                }

                conexion.Close();
                return Lista;


            }


        }

        public static int ModificarData (Personas1 personas1)
        {
            
            int result = 0;
            using (SqlConnection conexion = BD_gereral.obtenerConexion())
            {
                string query = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Marca = @Marca, Precio = @Precio, Stock = @Stock WHERE Id = @Id";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Id", personas1.id);
                comando.Parameters.AddWithValue("@Nombre", personas1.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", personas1.Descripcion);
                comando.Parameters.AddWithValue("@Marca", personas1.Marca);
                comando.Parameters.AddWithValue("@Precio", personas1.Precio);  // Asegúrate que Precio sea del tipo adecuado
                comando.Parameters.AddWithValue("@Stock", personas1.Stock);
                //comando.Parameters.AddWithValue("@Id", personas1.id);
                //string query = "update Productos set nombre='"+personas1.Nombre+"',                             

                //conexion.Open();
              
                //return result;
                result = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return result;

        }
        public static int EliminarTodo(int id)
        {
            int retorna = 0;

            using (SqlConnection conexion = BD_gereral.obtenerConexion())
            {
                string query = "delete from Productos where id =" + id + " ";
                SqlCommand comando = new SqlCommand(query, conexion);

                retorna = comando.ExecuteNonQuery();
            }
                return retorna;
            }

        }
}
