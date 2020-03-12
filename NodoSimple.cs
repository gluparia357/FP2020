using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaNodo
{
    public class NodoSimple
    {
        public int Numero;
        public string Detalle;
        public string Dato2;
        public string Dato3;
        public string Dato4;
        public NodoSimple Siguiente;
        
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}", Numero, Detalle, Dato2, Dato3, Dato4);
        }
        
    }
}
