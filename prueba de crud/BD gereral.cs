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


            //Conexion local a la base de datos con Sql Server  con credenciales previamente creadas
            SqlConnection conexion = new SqlConnection(@"Server=DARWIN; Database=personas; User Id=sa; Password=1234;");
            {
                conexion.Open();
            
                // 
                return conexion ;
            }


            
        }


    }

}
