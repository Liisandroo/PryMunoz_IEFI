using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryMunoz_IEFI
{
    internal class clsConexion
    {
        public static string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Inicio.mdb";

        public static OleDbConnection Conexion()
        {
            OleDbConnection conexion = new OleDbConnection(CadenaConexion);

            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }

            return conexion;
        }
    }
}
