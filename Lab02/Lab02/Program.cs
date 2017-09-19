using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ingresar la ruta del archivo original
            Console.WriteLine("Escribir la ruta del archivo:");
            string ruta = Console.ReadLine();
            //Si el archivo existe
            if (File.Exists(ruta)) 
            {
                byte[] Archivo = File.ReadAllBytes(ruta); //Leer el archivo como un arreglo de bytes.
                byte auxiliar = Archivo[0]; //Obtengo el contenido del primer byte.
                int Repeticiones = 0;
                StringBuilder Salida = new StringBuilder(); //Ire acumulando strings para mandar al archivo de salida
                for (int n = 0; n < Archivo.Length; n++)
                {
                    if (Archivo[n] == auxiliar) //Si el contenido de la casilla es igual
                    {
                        Repeticiones++;
                    }
                    else //Sino escribir datos, reiniciar contador y anotar el nuevo "caracter"
                    {
                        Salida.AppendLine("Repeticiones: " + Repeticiones.ToString() + " Caracter: " + auxiliar);
                        auxiliar = Archivo[n];
                        Repeticiones = 1;
                    }
                }
                //Por el diseño del for los datos del último caracter no son escritos, los escribo ahora.
                Salida.AppendLine("Repeticiones: " + Repeticiones.ToString() + " Caracter: " + auxiliar);
                Console.WriteLine(Salida); //Escribir todos los string que acumulé.
                Console.ReadLine();
            }
        }
    }
}
