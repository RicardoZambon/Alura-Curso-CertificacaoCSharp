using System;
using System.IO;
using System.IO.Compression;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class Streams_Zipped
    {
        static void Main(string[] args)
        {
            //TAREFA: USAR ARQUIVO COMPACTADO Texto.zip NO LUGAR
            //DO ArquivoSaida.txt

            //ESCRITA
            using (var fileStream = new FileStream("Texto.zip", FileMode.OpenOrCreate, FileAccess.Write))
            using (var zipStream = new GZipStream(fileStream, CompressionMode.Compress))
            using (var writer = new StreamWriter(zipStream))
            {
                writer.Write("Olá, Alura! (Gravado com StreamWriter)");
            }

            //LEITURA
            using (var fileStream = new FileStream("Texto.zip", FileMode.Open, FileAccess.Read))
            using (var zipStream = new GZipStream(fileStream, CompressionMode.Decompress))
            using (var reader = new StreamReader(zipStream))
            {
                Console.WriteLine($"Texto lido: {reader.ReadToEnd()}");
            }

            Console.ReadKey();
        }
    }
}
