using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    public class StreamExceptions
    {
        static void _Main(string[] args)
        {
            try
            {
                string content = File.ReadAllText("Arquivo.txt1");
                Console.WriteLine($"O conteúdo do arquivo é: {content}");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("O arquivo não foi encontrado.");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}