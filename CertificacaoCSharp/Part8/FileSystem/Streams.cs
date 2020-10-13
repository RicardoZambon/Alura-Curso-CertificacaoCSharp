using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class Streams
    {
        static void _Main(string[] args)
        {
            //TAREFA: Usar FileStream dá muito trabalho...
            //        Não podemos usar algo mais simples??

            using (var stream = new StreamWriter("ArquivoSaida.txt"))
            {
                stream.Write("Olá, Alura! (Gravado com StreamWriter)");
            }

            using (var stream = new StreamReader("ArquivoSaida.txt"))
            {
                Console.WriteLine($"Texto lido: {stream.ReadToEnd()}");
            }

            Console.ReadKey();
        }
    }
}