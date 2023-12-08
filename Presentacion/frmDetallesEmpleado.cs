using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDetallesEmpleado : Form
    {
        private Empleado empleado;

        public frmDetallesEmpleado(Empleado empleado)
        {
            InitializeComponent();

            this.empleado = empleado;
        }

        private void frmDetallesEmpleado_Load(object sender, EventArgs e)
        {
            dgvDetallesEmpleado.Rows.Add("ID", empleado.ID);
            dgvDetallesEmpleado.Rows.Add("Nombre", empleado.Nombre);
            dgvDetallesEmpleado.Rows.Add("Apellido", empleado.Apellido);
            dgvDetallesEmpleado.Rows.Add("DNI", empleado.DNI);
            dgvDetallesEmpleado.Rows.Add("Cargo", empleado.Cargo);
            dgvDetallesEmpleado.Rows.Add("Url imagen", empleado.UrlImagen);
            dgvDetallesEmpleado.Rows.Add("Fecha de ingreso", empleado.FechaRegistro);

            CargarImagen(empleado.UrlImagen);
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pboImagenEmpleado.Load(imagen);
            }
            catch (Exception)
            {
                pboImagenEmpleado.Load("https://image.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
