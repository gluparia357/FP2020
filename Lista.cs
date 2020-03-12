using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2020
{
    class ListaSimple
    {
        public Nodo NodoInicial = null;

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
                NodoInicial = unNodo;
            else
            {
                Nodo aux = NodoInicial;
                NodoInicial = unNodo;
                NodoInicial.Siguiente = aux;
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

            Nodo NodoFinal = BuscarUltimoNodo(NodoInicial);
            NodoFinal.Siguiente = unNodo;

        }

        public void QuitarPrimerNodo()
        {
            if (NodoInicial != null)
            {
                NodoInicial = NodoInicial.Siguiente;
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

        // Borrar Nodo de una posición específica

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
                NodoInicial = unNodo;
                NodoInicial.Siguiente = aux;
            }
            else
            {
                if (NodoInicial == null)
                {
                    NodoInicial = unNodo;
                    unNodo.Siguiente = unNodoActual;
                }
                else
                {
                    Nodo unNodoAnterior = new Nodo();
                    unNodoAnterior = BuscarNodoAnterior(NodoInicial, unNodoActual.Numero);
                    unNodoAnterior.Siguiente = unNodo;
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
            }
            else
            {
                if (unNodoActual.Siguiente == null)
                {
                    // es el ultimo
                    unNodoActual.Siguiente = unNodo;
                }
                else
                {
                    unNodo.Siguiente = unNodoActual.Siguiente;
                    unNodoActual.Siguiente = unNodo;
                }
            }
        }


        // Funciones adicionales
        private int ProximoNumeroNodo()
        {
            if (NodoInicial == null)
            {
                return 1;
            }
            int NmeroMaximoNodo = BuscarNumeroMaximoNodo(NodoInicial, NodoInicial.Numero);

            return NmeroMaximoNodo + 1;
        }
        // Numero maximo de nodo, para saber cual fue el ultimo que agregue
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

        // BuscarUltimoNodo

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

        // BuscarAnteultimo nodo
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
