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
                OcultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OcultarColumnas()
        {
            dgvEmpleados.Columns["DNI"].Visible = false;
            dgvEmpleados.Columns["UrlImagen"].Visible = false;
            dgvEmpleados.Columns["FechaRegistro"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaEmpleado alta = new frmAltaEmpleado();
            alta.ShowDialog();
            Refrescar();

            
        }

        private void btnVerEmpleado_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0 && dgvEmpleados.SelectedRows != null)
            {
                Empleado seleccionado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
                frmDetallesEmpleado detalles = new frmDetallesEmpleado(seleccionado);
                detalles.ShowDialog();
                Refrescar();
            }
            else
            {
                MessageBox.Show("Seleccione un empleado.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0 && dgvEmpleados.SelectedRows != null)
            {
                Empleado seleccionado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
                frmModificar modificar = new frmModificar(seleccionado);
                modificar.ShowDialog();
                Refrescar();
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para modificar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                Empleado empleadoSeleccionado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

                DialogResult pregunta = MessageBox.Show("¿Desea eliminar este registro?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (pregunta == DialogResult.Yes)
                {
                    negocio.Eliminar(empleadoSeleccionado);
                    Refrescar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para eliminar.");
            }
        }
    }
}
