using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class FileRead
    {
        static void _Main(string[] args)
        {
            //TAREFAS:
            //1. ABRIR O ARQUIVO Diretores.txt
            //2. LER 10 BYTES DO ARQUIVO
            //3. IMPRIMIR ESSES BYTES NO CONSOLE

            var stream = new FileStream("Diretores.txt", FileMode.Open, FileAccess.Read);

            var size = 10;
            var array = new byte[size];

            stream.Read(array, 0, size);
            foreach (var chr in array)
            {
                Console.Write((char)chr);
            }

            stream.Seek(5, SeekOrigin.Current);

            stream.Read(array, 1, size);
            foreach (var chr in array)
            {
                Console.Write((char)chr);
            }

            Console.ReadKey();
        }
    }
}