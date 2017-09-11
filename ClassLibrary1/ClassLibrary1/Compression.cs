using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace CompressionCode
{
    public class Compression
    {
        public static byte[] Compress(byte[] buffer)
        {
            MemoryStream newMemoryStream = new MemoryStream();
            GZipStream newGZipStream = new GZipStream(newMemoryStream, CompressionMode.Compress, true);
            newGZipStream.Write(buffer, 0, buffer.Length);
            newGZipStream.Close();
            newMemoryStream.Position = 0;


            byte[] compressed = new byte[newMemoryStream.Length];
            newMemoryStream.Read(compressed, 0,buffer.Length);

            byte[] gZipBuffer = new byte[compressed.Length + 4];
            Buffer.BlockCopy(compressed, 0, gZipBuffer, 4, compressed.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return gZipBuffer;
        }

        public static byte[] Decompress(byte[] gzBuffer)
        {
            MemoryStream ms = new MemoryStream();
            int msgLength = BitConverter.ToInt32(gzBuffer, 0);
            ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

            byte[] buffer = new byte[msgLength];

            ms.Position = 0;
            GZipStream zip = new GZipStream(ms, CompressionMode.Decompress);
            zip.Read(buffer, 0, buffer.Length);

            return buffer;
        }
    }
}
