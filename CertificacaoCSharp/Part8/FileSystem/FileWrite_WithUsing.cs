using System;
using System.IO;
using System.Text;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class FileWrite_WithUsing
    {
        static void _Main(string[] args)
        {
            //ESCRITA
            using (var writeStream = new FileStream("ArquivoSaida.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                var mensagemSaida = "Olá, Alura";

                var arrayWrite = Encoding.UTF8.GetBytes(mensagemSaida);
                writeStream.Write(arrayWrite, 0, arrayWrite.Length);
            }

            //LEITURA
            string texto;
            using (var readStream = new FileStream("ArquivoSaida.txt", FileMode.Open, FileAccess.Read))
            {
                var arrayRead = new byte[readStream.Length];

                readStream.Read(arrayRead, 0, arrayRead.Length);
                texto = Encoding.UTF8.GetString(arrayRead);
            }
            Console.WriteLine($"Mensagem lida: {texto}");

            Console.ReadKey();
        }
    }
}
