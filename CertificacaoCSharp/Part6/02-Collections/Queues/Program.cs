using System;
using System.Collections.Generic;

namespace Zambon.Alura.CertificacaoCSharp.Collections.Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            //COLEÇÃO: FILA = QUEUE
            //Regra: primeiro que entra é o primeiro que sai

            //TAREFA: Implementar uma fila de pedágio

            var pedagio = new Pedagio();

            pedagio.Enfileirar("Van");
            pedagio.Enfileirar("Kombi");
            pedagio.Enfileirar("Guincho");
            pedagio.Enfileirar("Pickup");

            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
        }
    }

    class Pedagio
    {
        Queue<string> fila = new Queue<string>();

        public void Enfileirar(string veiculo)
        {
            fila.Enqueue(veiculo);

            Console.WriteLine("Entrou na fila: " + veiculo);
            Imprimir();
        }

        private void Imprimir()
        {
            Console.WriteLine("VEÍCULOS NA FILA:");
            foreach (var v in fila)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("---------------------------------");
        }

        public void Desenfileirar()
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("A fila já está vazia!");
                return;
            }

            var veiculo = fila.Dequeue();
            Console.WriteLine("Saiu da fila: " + veiculo);

            if (fila.Count == 0)
            {
                Console.WriteLine("A fila já está vazia!");
                return;
            }

            var proximo = fila.Peek();
            Console.WriteLine("O próximo da fila é: " + proximo);
            Imprimir();
        }
    }
}