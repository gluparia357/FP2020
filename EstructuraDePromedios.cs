using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Archivo
{
    class EstructuraDePromedios
    {
        List<Promedio> ListaPromedio = new List<Promedio>();
        public void AgregarPromedio(int Legajo, string Nombre, string Apellido, float PromedioL)
        {
            Promedio Promedio = new Promedio();
            Promedio.Legajo = Legajo;
            Promedio.Nombre = Nombre;
            Promedio.Apellido = Apellido;
            Promedio.PromedioL = PromedioL;
            ListaPromedio.Add(Promedio);

        }

        public List<Promedio> RetornarPromedios()
        {
            return ListaPromedio;
        }

    }
}
