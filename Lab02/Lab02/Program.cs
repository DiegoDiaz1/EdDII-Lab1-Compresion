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
            string ruta2 = "C:\\Users\\Diego Diaz\\Desktop\\Descompresion.txt";
            //Si el archivo existe
            if (File.Exists(ruta)) 
            {
                byte[] Archivo = File.ReadAllBytes(ruta); //Leer el archivo como un arreglo de bytes.
                byte auxiliar = Archivo[0]; //Obtengo el contenido del primer byte.
                string[] Mensaje = new string[Archivo.Length];//Arreglo en donde se Guardan las letras del mensaje;
                int[] cantidadDeRepeticiones = new int[Archivo.Length];//Arreglo donde se guardan las veces que se repite una letra;
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
                        Mensaje[n] = System.Text.Encoding.ASCII.GetString(new[] { auxiliar });//obtengo la letra y la guardo en el array;
                        cantidadDeRepeticiones[n] = Repeticiones;//obtengo las veces que se repito esta letra;
                        Repeticiones = 1;
                    }

                }
                //Por el diseño del for los datos del último caracter no son escritos, los escribo ahora.
                Salida.AppendLine("Repeticiones: " + Repeticiones.ToString() + " Caracter: " + auxiliar);

                File.Create(ruta2).Close();//Creo un archivo si no existe eh inmediatamente lo cierro

                //Escribo el mensaje decodificado
                using (StreamWriter textWriter = new StreamWriter(ruta2, true))
                {
                    int j;
                    for (int i = 0; i < Mensaje.Length; i++)
                    {
                        int rep = cantidadDeRepeticiones[i];
                        j = 0;
                        while (j < rep)
                        {
                            textWriter.Write(Mensaje[i]);//Se Ecribe la letra en el texto 
                            j++;
                        }
                    }
                    textWriter.Close();//Cierro el StreamWriter
                }

                Console.WriteLine(Salida); //Escribir todos los string que acumulé.
                Console.ReadLine();
            }
        }
    }
}
