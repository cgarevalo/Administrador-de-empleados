using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        Empleado empleado = new Empleado();
        List<Empleado> listaEmp = new List<Empleado>();

        public List<Empleado> ListarEmpleados()
        {   
            listaEmp = CargarDatos();
            return listaEmp;
        }

        private int AsignarID()
        {
            if (listaEmp.Count > 0)
            {
                // Obtiene el máximo ID existente y suma 1
                return listaEmp.Max(e => e.ID) + 1;
            }
            else
            {
                // Si la lista está vacía, retorna 1 como el primer ID
                return 1;
            }
        }

        public void GuardarDatos(Empleado empleado)
        {
            listaEmp = CargarDatos();
            empleado.ID = AsignarID();
            empleado.FechaRegistro = DateTime.Now;
            listaEmp.Add(empleado);
            datos.Serializar(listaEmp);
        }

        public List<Empleado> CargarDatos()
        {
            return datos.Deserializar();
        }
    }
}
