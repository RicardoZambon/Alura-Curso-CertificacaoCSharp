using System;
using System.IO;
using System.Text;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class FileWrite
    {
        static void _Main(string[] args)
        {
            //ESCRITA
            var writeStream = new FileStream("ArquivoSaida.txt", FileMode.OpenOrCreate, FileAccess.Write);
            var mensagemSaida = "Olá, Alura";

            var arrayWrite = Encoding.UTF8.GetBytes(mensagemSaida);
            writeStream.Write(arrayWrite, 0, arrayWrite.Length);
            writeStream.Close();


            //LEITURA
            var readStream = new FileStream("ArquivoSaida.txt", FileMode.Open, FileAccess.Read);
            var arrayRead = new byte[readStream.Length];

            readStream.Read(arrayRead, 0, arrayRead.Length);
            Console.WriteLine($"Mensagem lida: {Encoding.UTF8.GetString(arrayRead)}");
            readStream.Close();

            Console.ReadKey();
        }
    }
}