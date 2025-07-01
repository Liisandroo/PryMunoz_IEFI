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
using System.IO;

namespace PryMunoz_IEFI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        public frmPrincipal(string usuario)
        {
            InitializeComponent();
            tsslblUsuario.Text = "Bienvenido, " + usuario;
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEliminar eli = new frmEliminar();
            eli.ShowDialog();
            this.Close();

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
             TimeSpan tiempoUso = DateTime.Now - clsSesion.HoraInicio;

            string tiempoUsoString = $"{tiempoUso.Hours:D2}:{tiempoUso.Minutes:D2}:{tiempoUso.Seconds:D2}";
            // Ejemplo de resultado: "01:23:45"

            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Usuarios.mdb"))
            {
                conn.Open();
                string query = "INSERT INTO Sesiones (Usuario, FechaIngreso, TiempoUso) VALUES (?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", clsSesion.UsuarioActual); // string -> Texto corto
                    cmd.Parameters.AddWithValue("?", clsSesion.HoraInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("?", tiempoUsoString);         // string -> Texto corto 
                    cmd.ExecuteNonQuery();
                }
            }

        }

        private void auditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuditoria di = new frmAuditoria();
            di.ShowDialog();
            this.Close();
        }

        private void tareasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistrarTarea de = new frmRegistrarTarea();
            de.ShowDialog();
            this.Close();
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial a = new frmHistorial();
            a.ShowDialog();
            this.Close();
        }
    }
}
