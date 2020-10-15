using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class DirectoryMethods
    {
        static void _Main(string[] args)
        {
            const string path = "Novo diretório";

            //TAREFA:
            //Criar um novo diretório
            //Verificar se ele foi criado
            //Apagar o diretório que foi criado

            Directory.CreateDirectory(path);

            var foreground = Console.ForegroundColor;

            if (Directory.Exists(path))
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
            }

            Directory.Delete(path);

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