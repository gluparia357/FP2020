using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Archivo
{
    class ListaNota
    {
        EstructuraDePromedios ListaDePromedios = new EstructuraDePromedios();
        EstructuraDeAlumno EstructuraDeAlumnos = new EstructuraDeAlumno();
        
        
        public List<Nota> GenerarListaNota()
        {
            List<Nota> ListaDeNotas = new List<Nota>();
            Nota Nota = new Nota();

            ListaDeNotas.Add(new Nota { Legajo = 1, NombreMateria = "Lengua", Calificacion = 5, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 1, NombreMateria = "Matematica", Calificacion = 9, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 4 , NombreMateria = "Lengua", Calificacion = 3, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 4, NombreMateria = "Matematica", Calificacion = 7, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 3, NombreMateria = "Matematica", Calificacion = 10, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 3, NombreMateria = "Ingles", Calificacion = 2, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 2, NombreMateria = "Matematica", Calificacion = 4, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 2, NombreMateria = "Ingles", Calificacion = 6, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 2, NombreMateria = "Lengua", Calificacion = 5, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 1, NombreMateria = "Ingles", Calificacion =1, Fecha = Convert.ToDateTime("01/01/2020") });
            ListaDeNotas.Add(new Nota { Legajo = 1, NombreMateria = "Programacion", Calificacion = 8, Fecha = Convert.ToDateTime("01/01/2020") });

            return ListaDeNotas;

        }

        public List<Alumno> ListaOrdenadaAlumnos()
        {
            List<Alumno> ListaAlumnosOrdenada = new List<Alumno>();
            ListaAlumnosOrdenada = EstructuraDeAlumnos.GenerarListaAlumno();
            if(ListaAlumnosOrdenada != null)
            {
                int a, b = 1;
                Alumno AuxAlumno = new Alumno();
                for(a =1; a < ListaAlumnosOrdenada.Count(); a++)
                {
                    for (b = 1; b < ListaAlumnosOrdenada.Count - a; b++)
                    {
                        if (ListaAlumnosOrdenada[b].Legajo > ListaAlumnosOrdenada[b + 1].Legajo)
                        {
                            AuxAlumno = ListaAlumnosOrdenada[b];
                            ListaAlumnosOrdenada[b] = ListaAlumnosOrdenada[b + 1];
                            ListaAlumnosOrdenada[b + 1] = AuxAlumno;

                        }
                    }
                }
            }


            return ListaAlumnosOrdenada;
        }
        
        public List<Nota> ListaOrdenada()
        {
            List<Nota> ListaNotaOrdenada = new List<Nota>();

            ListaNotaOrdenada = GenerarListaNota();

            if (ListaNotaOrdenada != null)
            {
                Nota AuxNota = new Nota();
                int k, f = 1;
                for (k = 1; k < ListaNotaOrdenada.Count(); k++)
                {
                    for (f = 1; f < ListaNotaOrdenada.Count - k; f++)
                    {
                        if (ListaNotaOrdenada[f].Legajo > ListaNotaOrdenada[f + 1].Legajo)
                        {
                            AuxNota = ListaNotaOrdenada[f];
                            ListaNotaOrdenada[f] = ListaNotaOrdenada[f + 1];
                            ListaNotaOrdenada[f + 1] = AuxNota;

                        }
                    }
                }
            }
            return ListaNotaOrdenada;
        }

        public List<Promedio> CorteDePromedio(List<Nota> ListaOrdenada)
        {
            List<Alumno> ListaDeAlumnos = new List<Alumno>();
            ListaDeAlumnos = EstructuraDeAlumnos.GenerarListaAlumno();

            int count = 0;
            float PromedioAlumno = 0;
            int TotalNota = 0;
            int NumNota = 0;

            int countalumno = 0;
            string NombreAlumno = "";
            string ApellidoAlumno = "";
            int LegajoAlumno = 0;

            Alumno AuxAlumno = new Alumno();

            while ( count != ListaOrdenada.Count())
            {
                
                AuxAlumno.Legajo = ListaOrdenada[count].Legajo;
                while (count != ListaOrdenada.Count() && AuxAlumno.Legajo == ListaOrdenada[count].Legajo)
                {
                    TotalNota += ListaOrdenada[count].Calificacion;
                    NumNota++;
                    count++;
                    
                }
              
                PromedioAlumno = TotalNota / NumNota;
                LegajoAlumno = AuxAlumno.Legajo;

                //APAREO DE ARCHIVOS--------------------------------------------------------------------

                while (countalumno != ListaDeAlumnos.Count())
                {
                    if (LegajoAlumno == ListaDeAlumnos[countalumno].Legajo)
                    {
                        NombreAlumno = ListaDeAlumnos[countalumno].Nombre;
                        ApellidoAlumno = ListaDeAlumnos[countalumno].Apellido;
                        
                    }
                    countalumno++;
                }
                countalumno = 0;

                ListaDePromedios.AgregarPromedio(LegajoAlumno, NombreAlumno, ApellidoAlumno, PromedioAlumno);
                NumNota = 0;
                TotalNota = 0;
            }

            return ListaDePromedios.RetornarPromedios();
                      
        }

       
    }
}
