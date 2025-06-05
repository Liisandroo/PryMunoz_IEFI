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
    public partial class frmCrear : Form
    {
        public frmCrear()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string categoria = cmbCategoria.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            bool exito = clsUsuario.RegistrarUsuario(nombre, contraseña, categoria);

            if (exito)
            {
                MessageBox.Show("Cuenta creada exitosamente.");
                frmLogin login = new frmLogin();
                login.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo crear la cuenta.");
            }

        }
    }
}
