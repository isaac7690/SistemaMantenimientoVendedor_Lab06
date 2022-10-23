using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{  
    public class CNVendedor
    {
        public class DAOVendedor
        {

            DAOVendedor objDAO = new DAOVendedor();
            //1. Listado de vendedores
            public DataTable listadoVendedores()
            {
           
                return objDAO.listadoVendedores();
            }
            public DataTable listadoDistritos()
            {

                return objDAO.listadoDistritos();
            }

            public int generaCodigo()
            {

                return objDAO.generaCodigo();
            }

            //2. registro del nuevo vendedor
            public int nuevoVendedor(Vendedor objV)
            {
                
                    return objDAO.nuevoVendedor(objV);

            }
            
            //3. buscar vendedor
            public DataTable buscaVendedor(int ide)
            {
    
                return objDAO.buscaVendedor(ide);
            }
            //4. actualiza datos del vendedor

            public int actualizaVendedor(Vendedor objV)
            {

                    return objDAO.actualizaVendedor(objV);
            }
            //5. elimina registro de vendedor
            public int eliminaVendedor(Vendedor objV)
            {
                    return objDAO.eliminaVendedor(objV);
                }

            }
        }
}
