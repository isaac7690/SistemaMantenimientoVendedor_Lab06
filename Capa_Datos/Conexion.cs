using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//librerias
using System.Data.SqlClient;
using System.Configuration;

namespace Capa_Datos
{
    public class Conexion
    {
        //Metodo de conexion 
        public SqlConnection getConecta()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            return cn;
        }
    }
}
