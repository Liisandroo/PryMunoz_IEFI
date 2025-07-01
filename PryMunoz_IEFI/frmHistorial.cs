using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PryMunoz_IEFI
{
    public partial class frmHistorial : Form
    {
        public frmHistorial()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal a = new frmPrincipal();
            a.ShowDialog();
            this.Close();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tareas.mdb;";

            using (OleDbConnection conn = new OleDbConnection(conexion))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Fecha, Tipo, Lugar FROM Tareas";
                    OleDbDataAdapter adaptador = new OleDbDataAdapter(query, conn);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvHistorial.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar tareas: " + ex.Message);
                }
            }

        }
    }
}
