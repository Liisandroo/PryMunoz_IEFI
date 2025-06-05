using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryMunoz_IEFI
{
    public partial class frmReestablecer : Form
    {
        public frmReestablecer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string nueva = txtNuevaContraseña.Text;
            string confirmar = txtConfirmar.Text;

            if (usuario == "" || nueva == "" || confirmar == "")
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (nueva != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            if (clsUsuario.UsuarioExiste(usuario))
            {
                clsUsuario.ActualizarContrasena(usuario, nueva);
            }
            else
            {
                MessageBox.Show("El usuario no existe.");
            }

            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

    }
}

