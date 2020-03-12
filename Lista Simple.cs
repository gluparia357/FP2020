using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaNodo;


namespace ClaseListas
{
    class ListaSimple
    {
        public NodoSimple NodoInicial = null;
        //public NodoSimple NodoPosicion = null;

        public void AgregarNodoAlInicio(string detalle, string dato2, string dato3, string dato4)
        {
            NodoSimple unNodo = new NodoSimple();
            unNodo.Numero = ProximoNumeroNodo();
            unNodo.Detalle = detalle;
            unNodo.Dato2 = dato2;
            unNodo.Dato3 = dato3;
            unNodo.Dato4 = dato4;
            if (NodoInicial == null)
                NodoInicial = unNodo;
            else
            {
                //si hay elementos en la lista, tenemos que agregarlo entre el inicial y el siguiente

                NodoSimple aux = NodoInicial;
                NodoInicial = unNodo;
                NodoInicial.Siguiente = aux;

            }
        }

        public void AgregarNodoAlFinal(string detalle, string dato2, string dato3, string dato4)
        {
            NodoSimple unNodo = new NodoSimple();
            unNodo.Numero = ProximoNumeroNodo();
            unNodo.Detalle = detalle;
            unNodo.Dato2 = dato2;
            unNodo.Dato3 = dato3;
            unNodo.Dato4 = dato4;

            NodoSimple nodoUltimo = BuscarNodoUltimo(NodoInicial);
            nodoUltimo.Siguiente = unNodo;
        }

   
        public void QuitarPrimerNodo()
        {
            if(NodoInicial != null)
            {
                NodoInicial = NodoInicial.Siguiente;
            }
        }

        public void QuitarUltimoNodo()
        {
            NodoSimple nodoAnteultimo = new NodoSimple();
            nodoAnteultimo = BuscarNodoAnteultimo(NodoInicial);

            if(nodoAnteultimo == null)
            {
                NodoInicial = null;
            }
            else
            {
                nodoAnteultimo.Siguiente = null;
            }
        }

        public void QuitarNodoPosicion(int numero)
        {
            if(NodoInicial != null)
            {
                if(NodoInicial.Numero == numero) //Si es el numero del primero
                {
                    QuitarPrimerNodo();
                }
                else
                {
                    NodoSimple unNodoUltimo = new NodoSimple();
                    unNodoUltimo = BuscarNodoUltimo(NodoInicial);
                    if(unNodoUltimo != null && unNodoUltimo.Numero == numero) //Si resulta ser el Id del ultimo
                    {
                        QuitarUltimoNodo();
                    }
                    else // Se quiere borrar un nodo intermedio
                    {
                        NodoSimple unNodoAnteriorAlElegido = new NodoSimple();
                        unNodoAnteriorAlElegido = BuscarAnteriorNodo(NodoInicial, numero);
                        if(unNodoAnteriorAlElegido != null)
                        {
                            unNodoAnteriorAlElegido.Siguiente = unNodoAnteriorAlElegido.Siguiente.Siguiente;
                        }
                    }
                }
            }
        }

        public void AgregarAntesDelSeleccionado(NodoSimple unNodo, string detalle, string dato2, string dato3, string dato4)
        {
            NodoSimple nodoAnterior = BuscarAnteriorNodo(NodoInicial, unNodo.Numero);
            NodoSimple unNodoNuevo = new NodoSimple();
            unNodoNuevo.Numero = ProximoNumeroNodo();
            unNodoNuevo.Detalle = detalle;
            unNodoNuevo.Dato2 = dato2;
            unNodoNuevo.Dato3 = dato3;
            unNodoNuevo.Dato4 = dato4;
            unNodoNuevo.Siguiente = unNodo;
            if (NodoInicial == null)
                NodoInicial = unNodoNuevo;
            else
             
            {
                //si hay elementos en la lista, tenemos que agregarlo entre el inicial y el siguiente

               // NodoSimple nodoAnterior = BuscarAnteriorNodo(NodoInicial, ); //BuscarNodoUltimo(NodoInicial);
                nodoAnterior.Siguiente = unNodoNuevo;
                                           
            }
        }

        public void AgregarDespuesDelSeleccionado(NodoSimple unNodo, string detalle, string dato2, string dato3, string dato4)
        {
            NodoSimple unNodoPosterior = unNodo.Siguiente;
            NodoSimple unNodoNuevo = new NodoSimple();
            unNodoNuevo.Numero = ProximoNumeroNodo();
            unNodoNuevo.Detalle = detalle;
            unNodoNuevo.Dato2 = dato2;
            unNodoNuevo.Dato3 = dato3;
            unNodoNuevo.Dato4 = dato4;
            unNodo.Siguiente = unNodoNuevo;
            if (NodoInicial == null)
                NodoInicial = unNodoNuevo;
            else

            {
                //si hay elementos en la lista, tenemos que agregarlo entre el inicial y el siguiente

                // NodoSimple nodoAnterior = BuscarAnteriorNodo(NodoInicial, ); //BuscarNodoUltimo(NodoInicial);
                unNodoNuevo.Siguiente = unNodoPosterior;
                ;

            }
        }
        //-----------------------------------------------------

        private int ProximoNumeroNodo()
        {
            if(NodoInicial == null)
            {
                return 1;
            }
            int numIdMaximoNodo = BuscarIdMaximoNodo(NodoInicial, NodoInicial.Numero);

            return numIdMaximoNodo + 1;
        }

        private int BuscarIdMaximoNodo(NodoSimple unNodo, int numero)
        {
            int numIdMaximoNodo;
            if(unNodo.Numero > numero)
            {
                numIdMaximoNodo = unNodo.Numero;
            }
            else
            {
                numIdMaximoNodo = numero;
            }

            if(unNodo.Siguiente == null)
            {
                return numIdMaximoNodo;

            }
            else
            {
                return BuscarIdMaximoNodo(unNodo.Siguiente, numIdMaximoNodo);
            }
        }

        private NodoSimple BuscarNodoUltimo (NodoSimple unNodo)
        {
            if(unNodo == null)
            {
                return null;
            }

            if(unNodo.Siguiente == null)
            {
                return (unNodo);
            }
            else
            {
                return BuscarNodoUltimo(unNodo.Siguiente);
            }
        }

        private NodoSimple BuscarNodoAnteultimo(NodoSimple unNodo)
        {
            if(unNodo == null)
            {
                return null;
            }

            if(unNodo.Siguiente == null)
            {
                return null;
            }

            if(unNodo.Siguiente.Siguiente == null)
            {
                return unNodo;
            }
            else
            {
                return BuscarNodoAnteultimo(unNodo.Siguiente);
            }
        } 

        private NodoSimple BuscarAnteriorNodo(NodoSimple unNodo, int numero)
        {
            if(unNodo.Siguiente != null && unNodo.Siguiente.Numero == numero)
            {
                return unNodo;
            }
            else
            {
                if(unNodo.Siguiente != null)
                {
                    return BuscarAnteriorNodo(unNodo.Siguiente, numero);
                }
                else
                {
                    return null;
                }
            }
        }

       
    }
}
