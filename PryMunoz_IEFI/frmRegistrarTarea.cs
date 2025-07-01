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
using static PryMunoz_IEFI.clsTareas;
using System.Collections;

namespace PryMunoz_IEFI
{
    public partial class frmRegistrarTarea : Form
    {
        private List<Tarea> tareasCargadas = new List<Tarea>();
        public frmRegistrarTarea()
        {
            InitializeComponent();
        }
        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal w = new frmPrincipal();
            w.ShowDialog();
            this.Hide();
        }

        private void frmRegistrarTarea_Load(object sender, EventArgs e)
        {
            cmbTarea.Items.AddRange(new string[] { "Auditoría", "Consultas", "Inspección", "Reclamos", "Visita" });
            cmbLugar.Items.AddRange(new string[] { "Empresa", "Servicio", "Oficina" });
            cmbTarea.SelectedIndex = 0;
            cmbLugar.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbTarea.SelectedItem == null || cmbLugar.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccioná tipo de tarea y lugar.");
                return;
            }

            // Crear la tarea
            var tarea = new Tarea
            {
                Fecha = dtpTiempo.Value,
                Tipo = cmbTarea.SelectedItem.ToString(),
                Lugar = cmbLugar.SelectedItem.ToString(),
               
            };


            // Cadena de conexión a la base de datos Access
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tareas.mdb;";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(conexion))
                {
                    conn.Open();
                    string query = "INSERT INTO Tareas (Fecha, Tipo, Lugar) VALUES (?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", tarea.Fecha);
                        cmd.Parameters.AddWithValue("?", tarea.Tipo);
                        cmd.Parameters.AddWithValue("?", tarea.Lugar);
                        

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Tarea guardada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
            }
        }


    }
}


