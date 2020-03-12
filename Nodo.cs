using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista2020
{
    public class Nodo
    {

        public int Numero;
        public string Detalle;
        public string Texto1, Texto2, Texto3;
        public int Entero1, Entero2, Entero3;
        public Nodo Siguiente;
        public Nodo Anterior;

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", Numero, Detalle, Texto1, Texto2, Entero1, Entero2, Entero3);
        }
    }
}
