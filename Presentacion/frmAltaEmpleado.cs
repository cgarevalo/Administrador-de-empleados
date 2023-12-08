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
using System.IO;

namespace Presentacion
{
    public partial class frmAltaEmpleado : Form
    {
        EmpleadoNegocio negocio = new EmpleadoNegocio();
        Empleado empleado = new Empleado();
        OpenFileDialog archivo = null;

        string nombre, apellido, documento, cargo, urlImagen, rutaDestino;

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrlImagen.Text);
        }


        public frmAltaEmpleado()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            documento = txtDni.Text;
            
            cargo = txtCargo.Text;
            urlImagen = txtUrlImagen.Text;

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
            negocio.GuardarDatos(empleado);

            //Guarda imagen si la levantó localmente:
            if (archivo != null)
            {
                if (!File.Exists(rutaDestino))
                {
                    File.Copy(archivo.FileName, rutaDestino);
                } 
            }

            MessageBox.Show("Empleado agregado.");

            Close();
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

        private void btnCargarImagenLocal_Click(object sender, EventArgs e)
        {
            string carpetaDestino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Empleados");

            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg|png|*.png";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                rutaDestino = Path.Combine(carpetaDestino, archivo.SafeFileName);
                txtUrlImagen.Text = rutaDestino;
                CargarImagen(archivo.FileName);
            }
        }
    }
}
