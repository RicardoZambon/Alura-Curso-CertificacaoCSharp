using System;

namespace Zambon.Alura.CertificacaoCSharp.Events.Lambda
{
    class Program
    {
        delegate int Operacao(int a, int b);

        static void Main(string[] args)
        {
            Operacao operacao = (x, y) => x + y;
            Console.WriteLine(operacao(3, 2));

            Console.ReadKey();
        }
    }
}