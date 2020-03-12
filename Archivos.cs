using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tp_Archivo
{
    class Archivos
    {
        string Archivo = "PromediosDeAlumnos.txt";
        public void AgregarLinea(Promedio Promedio)
        {
            FileStream Fs = new FileStream(Archivo, FileMode.Append, FileAccess.Write);
            using (StreamWriter Writter = new StreamWriter(Fs))
            {
                string Linea = Promedio.GenerarPromedio();
                Writter.WriteLine(Linea);
            }
            Fs.Close();
        }
    }
}
