using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class FileHandling
    {
        static void _Main(string[] args)
        {
            //TAREFAS: GRAVAR E LER DADOS DE UM ARQUIVO USANDO A CLASSE File

            string content = "Conteúdo inicial do arquivo";
            string additionalContent = "\nConteúdo adicional ao arquivo";

            File.WriteAllText("Arquivo.txt", content);

            File.AppendAllText("Arquivo.txt", additionalContent);

            if (File.Exists("Arquivo.txt"))
            {
                Console.WriteLine("O arquivo já existe");
            }

            Console.WriteLine($"Conteúdo do arquivo: {File.ReadAllText("Arquivo.txt")}");

            File.Copy("Arquivo.txt", "CopiaArquivo.txt", overwrite: true);

            string copyContent;
            using (var stream = File.OpenText("CopiaArquivo.txt"))
            {
                copyContent = stream.ReadToEnd();
            }
            Console.WriteLine(copyContent);

            Console.ReadKey();
        }
    }
}