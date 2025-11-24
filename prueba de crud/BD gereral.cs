using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace prueba_de_crud
{
     public class BD_gereral
    {
        public static SqlConnection obtenerConexion()
        {
            //SqlConnection conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Productos;Data Source=Darwin");
            //conexion.Open();
            // return conexion;


            SqlConnection conexion = new SqlConnection(@"Server=DARWIN; Database=personas; User Id=sa; Password=1234;");
            {
                conexion.Open();
                //MessageBox.Show("rejjre");
                // Código para realizar la consulta...
                return conexion ;
            }


            
        }


    }

}
