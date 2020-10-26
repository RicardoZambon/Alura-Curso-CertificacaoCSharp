using System;

namespace Zambon.Alura.CertificacaoCSharp.FloatBooleanStructEnum.BooleanType
{
    class Booleanos
    {
        public void Executar()
        {
            //bool possuiSaldo = 1;

            bool possuiSaldo = true;

            /// WriteLine() automaticamente converte o valor de "possuiSaldo" para texto.
            Console.WriteLine($"possuiSaldo: {possuiSaldo}");

            int dias = DateTime.Now.Day;
            Console.WriteLine($"dias: {dias}");

            // Atribui a diasPar o valor de uma expressão booleana.
            bool diasPar = (dias % 2 == 0);

            if (diasPar)
            {
                Console.WriteLine("dias é um número par");
            }
            else
            {
                Console.WriteLine("dias é um número ímpar");
            }
        }
    }
}