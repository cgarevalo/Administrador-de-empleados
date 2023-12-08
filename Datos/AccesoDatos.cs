using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Dominio;
using System.IO;

namespace Datos
{
    public class AccesoDatos
    {
        string carpetaAppDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string RutaArchivo;
        string nombreArchivo = "empleados.json";

        public void Serializar(List<Empleado> empleado)
        {
            RutaArchivo = Path.Combine(carpetaAppDataLocal, nombreArchivo);

            try
            {
                VerificarDirectorio();

                if (File.Exists(RutaArchivo))
                {
                    string archivoJson = JsonConvert.SerializeObject(empleado, Formatting.Indented);

                    File.WriteAllText(RutaArchivo, archivoJson);
                }
            }
            catch (Exception ex)
            {
                throw new Exception ("Error al serializar: " + ex.Message, ex);
            }
        }

        public List<Empleado> Deserializar()
        {
            RutaArchivo = Path.Combine(carpetaAppDataLocal, nombreArchivo);

            try
            {
                VerificarDirectorio();

                if (File.Exists(RutaArchivo))
                {
                    string archivoJson = File.ReadAllText(RutaArchivo);
                    List<Empleado> lista = JsonConvert.DeserializeObject<List<Empleado>>(archivoJson);

                    // La expresión return lista ?? new List<Empleado>(); es un operador de fusión nula (null-coalescing operator en inglés). En C#, se utiliza para simplificar la lógica de manejo de nulos.
                    return lista ?? new List<Empleado>();
                }
                else
                {
                    return new List<Empleado>();
                }              
            }
            catch (Exception ex)
            {
                throw new Exception ("Error al deserializar: " + ex.Message, ex);
            }
        }

        private void VerificarDirectorio()
        {
            if (!Directory.Exists(carpetaAppDataLocal))
            {
                Directory.CreateDirectory(carpetaAppDataLocal);
            }
        }
    }
}
