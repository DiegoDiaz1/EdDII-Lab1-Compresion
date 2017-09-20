using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanTree huffmanTree = new HuffmanTree();
            string ruta2 = "C:\\Users\\Diego Diaz\\Desktop\\Descompresion2.txt";
            Console.WriteLine("Escribir la ruta del archivo:");
            string ruta = Console.ReadLine();
            byte[] mensaje = File.ReadAllBytes(ruta);
            if (File.Exists(ruta))
            {
                huffmanTree.Build(mensaje);
                BitArray encoded = huffmanTree.Encode(mensaje);

                Console.Write("Encoded: ");
                byte[] bytes = new byte[encoded.Length / 8 + (encoded.Length % 8 == 0 ? 0 : 1)];
                encoded.CopyTo(bytes, 0);
                File.WriteAllBytes(@"C:\Users\Diego Diaz\Desktop\Compressed.txt", bytes);
                Console.WriteLine();

                byte[] decoded = huffmanTree.Decode(encoded);
                File.Create(ruta2).Dispose();
                using (StreamWriter textWriter = new StreamWriter(ruta2, true))
                {
                    for (int i = 0; i < decoded.Length; i++)
                    {
                        textWriter.Write(System.Text.Encoding.ASCII.GetString(new byte[] { decoded[i] }));
                    }
                }

                    Console.ReadLine();
            }
        }
    }
}
