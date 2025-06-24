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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        

        private bool ValidarLogin(string usuario, string contraseña)
        {

            using (OleDbConnection conexion = clsConexion.Conexion())
            {
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
                {
                    MessageBox.Show("Ingresá usuario y contraseña.");
                    return false;
                }
                string consulta = "SELECT COUNT(*) FROM Crear WHERE nombre = ? AND contraseña = ?";
                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", usuario);
                    comando.Parameters.AddWithValue("?", contraseña);

                    int count = (int)comando.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContra.Text;

            clsSesion.UsuarioActual = usuario;
            clsSesion.HoraInicio = DateTime.Now;


            if (ValidarLogin(usuario, contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso.");
                frmPrincipal form = new frmPrincipal(usuario);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void btnupa_Click(object sender, EventArgs e)
        {
            frmCrear cuak = new frmCrear();
            cuak.Show();

        }

        private void lblCrear_Click(object sender, EventArgs e)
        {
            frmCrear dou = new frmCrear();
            dou.Show();
        }

        private void lblOlvidar_Click(object sender, EventArgs e)
        {
            frmReestablecer olvi = new frmReestablecer();
            olvi.Show();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
