using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Xml.Linq;

namespace Presentacion
{
    public partial class frmModificar : Form
    {
        EmpleadoNegocio negocio = new EmpleadoNegocio();
        Empleado empleado;

        public frmModificar(Empleado empleado)
        {
            InitializeComponent();
            Text = "Modificar";
            this.empleado = empleado;
        }

        private void frmModificar_Load(object sender, EventArgs e)
        {
            txtNombre.Text = empleado.Nombre;
            txtApellido.Text = empleado.Apellido;
            txtDni.Text = empleado.DNI.ToString();
            txtCargo.Text = empleado.Cargo;
            txtUrlImagen.Text = empleado.UrlImagen;

            CargarImagen(txtUrlImagen.Text);
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pboImagenEmpleadoMod.Load(imagen);
            }
            catch (Exception)
            {
                pboImagenEmpleadoMod.Load("https://image.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDni.Text;
            string cargo = txtCargo.Text;
            string urlImagen = txtUrlImagen.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(documento) || string.IsNullOrWhiteSpace(cargo) || string.IsNullOrWhiteSpace(urlImagen))
            {
                MessageBox.Show("Por favor, rellene los campos antes de agregar.");
                return;
            }

            if (!int.TryParse(documento, out int dni))
            {
                MessageBox.Show("DNI tiene que ser un número válido.");
                return;
            }

            empleado.Nombre = nombre;
            empleado.Apellido = apellido;
            empleado.DNI = dni;
            empleado.Cargo = cargo;
            empleado.UrlImagen = urlImagen;
            negocio.Modificar(empleado);
            MessageBox.Show("Empleado modificado.");

            Close();
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrlImagen.Text);
        }
    }
}
