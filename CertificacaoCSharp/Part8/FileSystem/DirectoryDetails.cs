using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class DirectoryDetails
    {
        static void _Main(string[] args)
        {
            //TAREFA:
            //Criar um novo diretório
            //Verificar se ele foi criado
            //Exibir os atributos do diretório
            //Exibir último acesso
            //Apagar o diretório que foi criado

            var foreground = Console.ForegroundColor;

            var directoryInfo = new DirectoryInfo("Novo diretório");

            directoryInfo.Create();

            if (directoryInfo.Exists)
            {
                Console.Write("O diretório foi ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("criado");
                Console.ForegroundColor = foreground;
                Console.Write(" com ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("sucesso");
                Console.ForegroundColor = foreground;
                Console.WriteLine("!");
                Console.WriteLine();
            }

            Console.WriteLine($"Atributos: {directoryInfo.Attributes}\n" +
                $"Último acesso: {directoryInfo.LastAccessTime:dd/MMM/yyyy HH:mm:ss}\n");

            directoryInfo.Delete();

            Console.Write("O diretório foi ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("removido");
            Console.ForegroundColor = foreground;
            Console.Write(" com ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("sucesso");
            Console.ForegroundColor = foreground;
            Console.WriteLine("!");
        }
    }
}