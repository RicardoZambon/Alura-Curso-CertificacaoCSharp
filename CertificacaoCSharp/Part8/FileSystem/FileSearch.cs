using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class FileSearch
    {
        static void Main(string[] args)
        {
            //TAREFAS:
            //Obter o diretório de início do projeto
            //Listar todos os diretórios do projeto
            //Listar todos os arquivos csharp (.cs) do projeto

            var path = new DirectoryInfo(@"..\..\..");

            Console.WriteLine("Diretórios do projeto:");
            ListarDiretorios(path);
            ListarArquivos(path);
        }

        private static void ListarDiretorios(DirectoryInfo path)
        {
            foreach (var directory in path.GetDirectories())
            {
                Console.WriteLine(directory.FullName);
                ListarArquivos(path);

                ListarDiretorios(directory);
            };
        }

        private static void ListarArquivos(DirectoryInfo path)
        {
            foreach (var file in path.GetFiles("*.cs"))
            {
                Console.WriteLine(file.FullName);
            }
        }
    }
}