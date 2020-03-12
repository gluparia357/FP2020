using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDoble2020
{
    class ListaDoble
    {
        public Nodo NodoInicial = null;
        public Nodo NodoFinal = null;

        public void AgregarNodoalInicio(string detalle, string texto1, string texto2, String texto3, int entero1, int entero2, int entero3)
        {
            Nodo unNodo = new Nodo();
            unNodo.Numero = ProximoNumeroNodo();
            unNodo.Detalle = detalle;
            unNodo.Entero1 = entero1;
            unNodo.Entero2 = entero2;
            unNodo.Entero3 = entero3;
            unNodo.Texto1 = texto1;
            unNodo.Texto2 = texto2;
            unNodo.Texto3 = texto3;


            if (NodoInicial == null)
            {
                NodoInicial = unNodo;
                NodoFinal = unNodo;
            }
            else
            {
                Nodo aux = NodoInicial;
                NodoInicial = unNodo;
                NodoInicial.Siguiente = aux;
                NodoInicial.Siguiente.Anterior = unNodo;
            }
        }

        public void AgregarNodoalFinal(string detalle, string texto1, string texto2, String texto3, int entero1, int entero2, int entero3)
        {
            Nodo unNodo = new Nodo();
            unNodo.Numero = ProximoNumeroNodo();
            unNodo.Detalle = detalle;
            unNodo.Entero1 = entero1;
            unNodo.Entero2 = entero2;
            unNodo.Entero3 = entero3;
            unNodo.Texto1 = texto1;
            unNodo.Texto2 = texto2;
            unNodo.Texto3 = texto3;

            Nodo UltimoNodo = new Nodo();
            UltimoNodo = BuscarUltimoNodo(NodoInicial);
            Nodo NodoFinal = unNodo;
            UltimoNodo.Siguiente = unNodo;
            unNodo.Anterior = UltimoNodo;

        }

        public void QuitarPrimerNodo()
        {
            if (NodoInicial != null)
            {
                NodoInicial = NodoInicial.Siguiente;
                NodoInicial.Anterior = null; 
            }
        }

        public void QuitarUltimoNodo()
        {

            Nodo NodoAnteultimo = new Nodo();
            NodoAnteultimo = BuscarAnteultimoNodo(NodoInicial);

            if (NodoAnteultimo == null)
            {
                NodoInicial = null;
            }
            else
            {
                NodoAnteultimo.Siguiente = null;
            }

        }

        public void BorrarNodoEspecifico(int numero)
        {
            // Si es el inicial
            if (NodoInicial.Numero == numero)
            {
                QuitarPrimerNodo();
            }
            else
            {
                // Si es el ultimo
                Nodo NodoSiEsUltimo = new Nodo();
                NodoSiEsUltimo = BuscarUltimoNodo(NodoInicial);
                if (NodoSiEsUltimo.Numero == numero && NodoSiEsUltimo != null)
                {
                    QuitarUltimoNodo();
                }
                else
                {
                    // Si esta en el medio
                    Nodo NodoAnterior = new Nodo();
                    NodoAnterior = BuscarNodoAnterior(NodoInicial, numero);
                    if (NodoAnterior != null)
                    {
                        NodoAnterior.Siguiente = NodoAnterior.Siguiente.Siguiente;
                        NodoAnterior.Siguiente.Anterior = NodoAnterior;
                    }
                }
            }
        }

        public void AgregarAntesDelNodoSeleccionado(Nodo unNodoActual, string detalle, string texto1, string texto2, String texto3, int entero1, int entero2, int entero3)
        {
            Nodo unNodo = new Nodo();
            unNodo.Numero = ProximoNumeroNodo();
            unNodo.Detalle = detalle;
            unNodo.Entero1 = entero1;
            unNodo.Entero2 = entero2;
            unNodo.Entero3 = entero3;
            unNodo.Texto1 = texto1;
            unNodo.Texto2 = texto2;
            unNodo.Texto3 = texto3;

            if (unNodoActual == NodoInicial) // Es igual a agregar al inicio
            {
                Nodo aux = NodoInicial;
                NodoInicial.Anterior = unNodo;
                NodoInicial = unNodo;
                NodoInicial.Siguiente = aux;
            }
            else
            {
                if (NodoInicial == null)
                {
                    NodoInicial = unNodo;
                    NodoFinal = unNodo;
                }
                else
                {
                    Nodo unNodoAnterior = new Nodo();
                    //unNodoAnterior = BuscarNodoAnterior(NodoInicial, unNodoActual.Numero);
                    unNodoAnterior = unNodoActual.Anterior;
                    unNodoAnterior.Siguiente = unNodo;
                    unNodoActual.Anterior = unNodo;
                    unNodo.Anterior = unNodoAnterior;
                    unNodo.Siguiente = unNodoActual;
                }
            }

        }

        public void AgregarDespuesDelNodoSeleccionado(Nodo unNodoActual, string detalle, string texto1, string texto2, String texto3, int entero1, int entero2, int entero3)
        {
            Nodo unNodo = new Nodo();
            unNodo.Numero = ProximoNumeroNodo();
            unNodo.Detalle = detalle;
            unNodo.Entero1 = entero1;
            unNodo.Entero2 = entero2;
            unNodo.Entero3 = entero3;
            unNodo.Texto1 = texto1;
            unNodo.Texto2 = texto2;
            unNodo.Texto3 = texto3;

            if (NodoInicial == null)
            {
                NodoInicial = unNodo;
                NodoFinal = unNodo;
            }
            else
            {
                if (unNodoActual.Siguiente == null)
                {
                    // es el ultimo
                    unNodoActual.Siguiente = unNodo;
                    unNodo.Anterior = unNodoActual;
                }
                else
                {
                    unNodo.Siguiente = unNodoActual.Siguiente;
                    unNodo.Anterior = unNodoActual;
                    unNodo.Siguiente.Anterior = unNodo;
                    unNodoActual.Siguiente = unNodo;
                }
            }
        }

        // Funciones complementarias
        private int ProximoNumeroNodo()
        {
            if (NodoInicial == null)
            {
                return 1;
            }
            int NmeroMaximoNodo = BuscarNumeroMaximoNodo(NodoInicial, NodoInicial.Numero);

            return NmeroMaximoNodo + 1;
        }
        private int BuscarNumeroMaximoNodo(Nodo unNodo, int numero)
        {
            int NumeroMaximoNodo;
            if (unNodo.Numero > numero)
            {
                NumeroMaximoNodo = unNodo.Numero;
            }
            else
            {
                NumeroMaximoNodo = numero;
            }

            if (unNodo.Siguiente == null)
            {
                return NumeroMaximoNodo;
            }
            else
            {
                return BuscarNumeroMaximoNodo(unNodo.Siguiente, NumeroMaximoNodo);
            }

        }

        private Nodo BuscarUltimoNodo(Nodo unNodo)
        {
            if (unNodo == null)
            {
                return null;
            }
            if (unNodo.Siguiente == null)
            {
                return (unNodo);
            }
            else
            {
                return BuscarUltimoNodo(unNodo.Siguiente);
            }


        }
        private Nodo BuscarAnteultimoNodo(Nodo unNodo)
        {
            if (unNodo == null)
            {
                return null;
            }
            if (unNodo.Siguiente == null)
            {
                return null;
            }
            if (unNodo.Siguiente.Siguiente == null)
            {
                return unNodo;
            }
            else
            {
                return BuscarAnteultimoNodo(unNodo.Siguiente);
            }

        }

        private Nodo BuscarNodoAnterior(Nodo unNodo, int numero)
        {
            if (unNodo.Siguiente.Numero == numero)
            {
                return unNodo;
            }
            else
            {
                return BuscarNodoAnterior(unNodo, numero);
            }
        }
    }
}
