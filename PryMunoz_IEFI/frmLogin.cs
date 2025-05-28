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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Inicio.mdb";
        private bool ValidarLogin(string usuario, string contraseña)
        {

            using (OleDbConnection conexion = new OleDbConnection(CadenaConexion))
            //Crea una conexión nueva y la usa dentro de un bloque using, lo que asegura que se cierre automáticamente al salir del bloque.
            {
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
                {
                    MessageBox.Show("Ingresá usuario y contraseña.");
                    return false;
                }
                conexion.Open();
                string consulta = "SELECT COUNT(*) FROM Inicio WHERE nombre = ? AND contraseña = ?";
                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", usuario);
                    comando.Parameters.AddWithValue("?", contraseña);

                    int count = (int)comando.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContra.Text;

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
    }
}
