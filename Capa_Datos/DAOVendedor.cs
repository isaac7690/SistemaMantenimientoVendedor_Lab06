using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//librerías
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class DAOVendedor
    {
        SqlConnection cn;
        Conexion objCon = new Conexion();

        //1. Listado de vendedores
        public DataTable listadoVendedores()
        {
            cn = objCon.getConecta();
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTADOVENDEDORES", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable listadoDistritos()
        {
            cn = objCon.getConecta();
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTADODISTRITOS", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int generaCodigo()
        {
            cn = objCon.getConecta();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_NUEVOCODIGO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            int n = int.Parse(cmd.ExecuteScalar().ToString());
            cn.Close();
            return n;
        }

        //2. registro del nuevo vendedor
        public int nuevoVendedor(Vendedor objV)
        {
            cn = objCon.getConecta();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_NUEVOVENDEDOR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", objV.nom_ven);
            cmd.Parameters.AddWithValue("@ape", objV.ape_ven);
            cmd.Parameters.AddWithValue("@sue", objV.sue_ven);
            cmd.Parameters.AddWithValue("@fec", objV.fec_ing);
            cmd.Parameters.AddWithValue("@dis", objV.ide_dis);

            try
            {
                int n = cmd.ExecuteNonQuery();
                return n;
            }
            catch (Exception)
            {
            }

            cn.Close();
            return 0;
        }
        //@NOM VARCHAR(20),@APE VARCHAR(20),@SUE MONEY,@FEC DATE, @DIS INT

        //3. buscar vendedor
        public DataTable buscaVendedor(int ide)
        {
            cn = objCon.getConecta();
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_BUSQUEDAVENDEDOR", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //da.SelectCommand.Parameters.Add("@ide",SqlDbType.Int).Value=ide;
            da.SelectCommand.Parameters.AddWithValue("@ide", ide);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }
        //4. actualiza datos del vendedor

        public int actualizaVendedor(Vendedor objV)
        {
            cn = objCon.getConecta();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAVENDEDOR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ide", objV.ide_ven);
            cmd.Parameters.AddWithValue("@nom", objV.nom_ven);
            cmd.Parameters.AddWithValue("@ape", objV.ape_ven);
            cmd.Parameters.AddWithValue("@sue", objV.sue_ven);
            cmd.Parameters.AddWithValue("@fec", objV.fec_ing);
            cmd.Parameters.AddWithValue("@dis", objV.ide_dis);

            try
            {
                int n = cmd.ExecuteNonQuery();
                return n;
            }
            catch (Exception)
            {
            }

            cn.Close();
            return 0;
        }
        //5. elimina registro de vendedor
        public int eliminaVendedor(Vendedor objV)
        {
            cn = objCon.getConecta();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_ELIMINAVENDEDOR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ide", objV.ide_ven);
            try
            {
                int n = cmd.ExecuteNonQuery();
                return n;
            }
            catch (Exception)
            {
            }

            cn.Close();
            return 0;
        }
    }
}
