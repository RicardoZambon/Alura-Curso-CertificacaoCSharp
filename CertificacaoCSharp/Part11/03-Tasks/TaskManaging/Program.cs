using System;
using System.Threading;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.Tasks.TaskManaging
{
    class Program
    {
        static void Main(string[] args)
        {
            var tarefa1 = new Task(() => ExecutaTrabalho(1));
            tarefa1.Start();
            tarefa1.Wait();

            var tarefa2 = Task.Run(() => ExecutaTrabalho(2));
            tarefa2.Wait();

            var tarefa3 = Task.Run<int>(() => CalcularResultado(2, 3));
            Console.WriteLine($"O resultado é: {tarefa3.Result}");

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        public static void ExecutaTrabalho(int item)
        {
            Console.WriteLine("Trabalho iniciado: {0}", item);
            Thread.Sleep(2000);
            Console.WriteLine("Trabalho terminado: {0}", item);
            Console.WriteLine();
        }

        public static int CalcularResultado(int numero1, int numero2)
        {
            Console.WriteLine("Trabalho iniciado");
            Thread.Sleep(2000);
            Console.WriteLine("Trabalho terminado");
            Console.WriteLine();
            return numero1 + numero2;
        }
    }
}