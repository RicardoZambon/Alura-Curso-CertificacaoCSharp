using System;
using System.Threading;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.StopingParallelLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tarefa 1: Processar uma faixa de 100 itens em paralelo
            //Tarefa 2: Completou sem interrupção?
            //Tarefa 3: Interromper quando começar a processar o valor 75
            //Tarefa 4: Quantos itens foram processados (parcialmente)?

            var resultadoLoop = Parallel.For(0, 100,
                (int i, ParallelLoopState state) => {

                    if (i == 75)
                    {
                        state.Break();
                    }

                    Processar(i);
                });
            Console.WriteLine();

            Console.WriteLine($"Completou sem interrupção? {resultadoLoop.IsCompleted}");
            Console.WriteLine();

            Console.WriteLine($"Quantos itens foram processados (parcialmente)? {resultadoLoop.LowestBreakIteration}");
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