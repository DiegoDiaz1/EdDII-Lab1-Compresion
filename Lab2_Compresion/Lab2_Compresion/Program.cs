using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Lab2_Compresion
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanTree huffmanTree = new HuffmanTree();
            string option = "";
            string compresion;
            string ruta;
            Console.Title = "Laboratorio No. 2 Compresion.";
            Console.WriteLine("Que Metodo Desea usar: ");
            Console.WriteLine("H para Huffman. \n R para RLE.");
            option = Console.ReadLine();
            Console.WriteLine("Ingrese La ruta del archivo: ");
            ruta = Console.ReadLine();
            byte[] mensaje = File.ReadAllBytes(ruta);
            switch (option)
            {
                case "H":
                    Console.Clear();
                    Console.WriteLine("-c para comprimir -d para descomprimir.");
                    compresion = Console.ReadLine();
                    while (compresion != "-c" && compresion != "-d")
                    {
                        switch (compresion)
                        {
                            case "-c":
                                Console.Clear();
                                
                                if (File.Exists(ruta))
                                {
                                    huffmanTree.Build(mensaje);
                                    BitArray encoded = huffmanTree.Encode(mensaje);
                                    byte[] bytes = new byte[encoded.Length / 8 + (encoded.Length % 8 == 0 ? 0 : 1)];
                                    encoded.CopyTo(bytes, 0);
                                    File.WriteAllBytes(@"C:\Users\user\Desktop\Compressed.comp", bytes);//Cambiar user por su user
                                }
                                else
                                {
                                    Console.WriteLine("No existe la ruta del archivo.");
                                }
                                break;
                            case "-d":
                                Console.Clear();

                                if (File.Exists(ruta))
                                {
                                    huffmanTree.Build(mensaje);
                                    List<bool> encodedSource = new List<bool>();
                                    for (int i = 0; i < mensaje.Length; i++)
                                    {
                                        List<bool> encodedSymbol = huffmanTree.Root.Traverse(mensaje[i], new List<bool>());
                                        encodedSource.AddRange(encodedSymbol);
                                    }

                                    BitArray bits = new BitArray(encodedSource.ToArray());

                                    byte[] decoded = huffmanTree.Decode(bits);
                                    string ruta2 = @"C:\Users\user\Desktop\Decompressed.txt";
                                    File.Create(ruta2).Dispose();
                                    using (StreamWriter textWriter = new StreamWriter(ruta2, true))
                                    {
                                        for (int i = 0; i < decoded.Length; i++)
                                        {
                                            textWriter.Write(System.Text.Encoding.ASCII.GetString(new byte[] { decoded[i] }));
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No existe la ruta del archivo.");
                                }
                                break;
                            default:
                                break;
                        }

                    }
                    break;
                case "R":
                    Console.Clear();
                    Console.WriteLine("-c para comprimir -d para descomprimir.");
                    compresion = Console.ReadLine();
                    while (compresion != "-c" && compresion != "-d")
                    {
                        switch (compresion)
                        {
                            case "-c":
                                Console.Clear();

                                if (File.Exists(ruta))
                                {
                                    //codigo compresion
                                }
                                else
                                {
                                    Console.WriteLine("No existe la ruta del archivo.");
                                }
                                break;
                            case "-d":
                                Console.Clear();

                                if (File.Exists(ruta))
                                {
                                    //Codigo descompresion
                                }
                                else
                                {
                                    Console.WriteLine("No existe la ruta del archivo.");
                                }
                                break;
                            default:
                                break;
                        }

                    }
                    break;
                default:
                    break;
            }
        }
    }
}
