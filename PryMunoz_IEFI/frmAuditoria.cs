using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryMunoz_IEFI
{
    public partial class frmAuditoria : Form
    {
        public frmAuditoria()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Usuarios.mdb"))
            {
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT Usuario, FechaIngreso, TiempoUso FROM Sesiones ORDER BY FechaIngreso DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGrilla.DataSource = dt;
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal s = new frmPrincipal();
            s.ShowDialog();
            this.Hide();
        }
    }
}
