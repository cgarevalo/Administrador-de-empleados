using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class Aplicacion : Form
    {
        Empleado empleado = new Empleado();
        EmpleadoNegocio negocio = new EmpleadoNegocio();
        List<Empleado> listaEmpleados = new List<Empleado>();

        public Aplicacion()
        {
            InitializeComponent();
        }

        private void Aplicacion_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void Refrescar()
        {
            listaEmpleados = negocio.ListarEmpleados();

            try
            {
                dgvEmpleados.DataSource = null;
                dgvEmpleados.DataSource = listaEmpleados;
                dgvEmpleados.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtCargo.Text != "")
            {
                empleado.Nombre = txtNombre.Text;
                empleado.Cargo = txtCargo.Text;
                negocio.GuardarDatos(empleado);
                MessageBox.Show("Empleado agregado.");
                txtNombre.Text = "";
                txtCargo.Text = "";

                Refrescar();
            }
            else
            {
                MessageBox.Show("Por favor, rellene los campos antes de agregar.");
            }
        }
    }
}
