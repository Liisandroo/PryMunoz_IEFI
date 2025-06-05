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
    }
}
