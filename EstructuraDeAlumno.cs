using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Archivo
{
    class EstructuraDeAlumno
    {
        public List<Alumno> GenerarListaAlumno()
        {
            List <Alumno> ListaDeAlumnos = new List<Alumno>();

            ListaDeAlumnos.Add(new Alumno { Legajo = 1, Nombre = "Pablo", Apellido = "Perez"});
            ListaDeAlumnos.Add(new Alumno { Legajo = 4, Nombre = "Guille", Apellido = "Gomez" });
            ListaDeAlumnos.Add(new Alumno { Legajo = 3, Nombre = "Daniel", Apellido = "Diaz" });
            ListaDeAlumnos.Add(new Alumno { Legajo = 2, Nombre = "Armando", Apellido = "Arias" });

            return ListaDeAlumnos;
        }
    }
}
