using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.ManyTasksInParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            //MUITAS TAREFAS EM PARALELO, COM PARÂMETRO
            //=========================================
            //Tarefa 1: processar 100 itens em série
            //Tarefa 2: processar 100 itens em paralelo - percorrendo uma faixa
            //Tarefa 3: processar 100 itens em paralelo - percorrendo uma coleção

            var stopwatch = new Stopwatch();

            var times = new long[3];

            stopwatch.Start();
            Console.WriteLine("Tarefa 1: processar 100 itens em série");
            for (var i = 0; i < 100; i++)
            {
                Processar(i);
            }
            stopwatch.Stop();
            times[0] = stopwatch.ElapsedMilliseconds;
            Console.WriteLine();

            stopwatch.Reset();

            stopwatch.Restart();
            Console.WriteLine("Tarefa 2: processar 100 itens em paralelo - percorrendo uma faixa");
            Parallel.For(0, 100, (i) => Processar(i));
            stopwatch.Stop();
            times[1] = stopwatch.ElapsedMilliseconds;
            Console.WriteLine();

            stopwatch.Reset();

            stopwatch.Restart();
            Console.WriteLine("Tarefa 3: processar 100 itens em paralelo - percorrendo uma coleção");
            var itens = Enumerable.Range(0, 100);
            Parallel.ForEach(itens, (item) => Processar(item));
            stopwatch.Stop();
            times[2] = stopwatch.ElapsedMilliseconds;
            Console.WriteLine();

            Console.WriteLine("Tempo decorrido:");
            Console.WriteLine($"Tarefa 1: {times[0] / 1000.0:N3} segundos");
            Console.WriteLine($"Tarefa 2: {times[1] / 1000.0:N3} segundos");
            Console.WriteLine($"Tarefa 3: {times[2] / 1000.0:N3} segundos");
            Console.WriteLine();

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void Processar(object item)
        {
            Console.WriteLine("Começando a trabalhar com: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Terminando a trabalhar com: " + item);
        }
    }
}