using System;
using Zambon.Alura.CertificacaoCSharp.ReflectionDiscoveringClassProperties.Modelo;

namespace Zambon.Alura.CertificacaoCSharp.ReflectionDiscoveringClassProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            //TAREFA 1: obter as propriedades de CarrinhoCliente
            //TAREFA 2: descobrir se podem ler ou escrever
            //TAREFA 3: descobrir seus acessadores getters e setters

            var propriedades = typeof(CarrinhoCliente).GetProperties();

            foreach (var propriedade in propriedades)
            {
                Console.WriteLine($"Propriedade: {propriedade.Name}");

                if (propriedade.CanRead)
                {
                    Console.WriteLine("\tPode ler");
                    Console.WriteLine($"\t\tMétodo get: {propriedade.GetMethod}");
                }

                if (propriedade.CanWrite)
                {
                    Console.WriteLine("\tPode escrever");
                    Console.WriteLine($"\t\tMétodo set: {propriedade.SetMethod}");
                }
            }

            Console.ReadLine();
        }
    }
}