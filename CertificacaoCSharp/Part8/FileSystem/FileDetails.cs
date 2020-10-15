using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class FileDetails
    {
        static void Main(string[] args)
        {
            //TAREFA:
            //1. Gravar um texto em Arquivo.txt
            //2. Obter informações desse arquivo:
            //      Nome
            //      Caminho completo (diretório + nome do arquivo)
            //      Data e hora do último acesso
            //      Tamanho do arquivo (bytes)
            //      Atributos do arquivo
            //      Adicionar atributo somente-leitura
            //      Verificar os atributos novamente
            //      Remover atributo somente-leitura
            //      Verificar os atributos novamente

            const string fileNAme = "Arquivo.txt";

            File.WriteAllText(fileNAme, "Texto inicial do arquivo");
            var fileInfo = new FileInfo(fileNAme);

            Console.WriteLine($"Nome do arquivo: {fileInfo.Name}\n" +
                $"Caminho: {fileInfo.FullName}\n" +
                $"Último acesso: {fileInfo.LastAccessTime:dd/MMM/yyyy HH:mm:ss}\n" +
                $"Tamanho: {fileInfo.Length:N0} bytes\n" +
                $"Atributos: {fileInfo.Attributes}");

            fileInfo.Attributes |= FileAttributes.ReadOnly;
            Console.WriteLine($"Checando os atributos novamente: {fileInfo.Attributes}");

            fileInfo.Attributes &= ~FileAttributes.ReadOnly;
            Console.WriteLine($"Voltando aos atributos originais: {fileInfo.Attributes}");
        }
    }
}