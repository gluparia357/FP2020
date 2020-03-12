using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Archivo
{
    class Promedio
    {
        public int Legajo;
        public string Nombre;
        public string Apellido;
        public float PromedioL;


        public string GenerarPromedio()
        {
            return $"{Legajo}, {Nombre}, {Apellido}, {PromedioL}";
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", Legajo, Nombre, Apellido, PromedioL);
        }
    }


}
