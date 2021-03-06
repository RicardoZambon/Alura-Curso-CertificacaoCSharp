﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class AsyncStreamErrorHandling
    {
        static async Task Main(string[] args)
        {
            //TAREFA: CAPTURAR A EXCEÇÃO 
            //GERADA POR UM MÉTODO ASSÍNCRONO

            byte[] dados = new byte[100];
            try
            {
                // nome do arquivo com caractere inválido ">"
                await GravarBytesAsync("destino>.dat", dados);
            }
            catch (Exception writeException)
            {
                Console.WriteLine(writeException.Message);
                Console.WriteLine("escrita falhou");
            }
            Console.Read();
        }

        static async Task GravarBytesAsync(string nomeArquivo, byte[] items)
        //Nunca retornar void, e sim Task!
        {
            using (FileStream fluxoSaida = new FileStream(nomeArquivo, FileMode.OpenOrCreate, FileAccess.Write))
            {
                await fluxoSaida.WriteAsync(items, 0, items.Length);
            }
        }
    }
}