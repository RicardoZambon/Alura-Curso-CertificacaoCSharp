using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class PathMethods
    {
        static void _Main(string[] args)
        {
            //TAREFAS:
            //Descobrir o caminho da pasta "Meus Documentos"
            //Combinar caminho da pasta "Meus Documentos" com arquivo "alura.txt"
            //Obter somente o nome do diretório do arquivo
            //Obter somente o nome do arquivo
            //Obter a extensão do arquivo
            //Modificar a extensão do arquivo

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine($"Meus documentos: {documents}");

            var path = Path.Combine(documents, "alura.txt");
            Console.WriteLine($"Caminho completo: {path}");

            var pathName = Path.GetDirectoryName(path);
            Console.WriteLine($"Somente nome do diretório: {pathName}");

            var fileName = Path.GetFileName(path);
            Console.WriteLine($"Somente nome do arquivo: {fileName}");

            var extension = Path.GetExtension(path);
            Console.WriteLine($"Extensão do arquivo: {extension}");

            path = Path.ChangeExtension(path, "xyz");
            Console.WriteLine($"Nova extensão do arquivo: {Path.GetFullPath(path)}");
        }
    }
}