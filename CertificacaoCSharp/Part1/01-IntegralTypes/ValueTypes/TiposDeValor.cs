using System;

namespace Zambon.Alura.CertificacaoCSharp.IntegralTypes.ValueTypes
{
    class TiposDeValor
    {
        public void Executar()
        {
            int idade;
            idade = 30;
            Console.WriteLine(idade);

            System.Int32 copiaIdade = idade;

            Console.WriteLine($"idade: {idade}");
            Console.WriteLine($"copiaIdade: {copiaIdade}");

            idade = 23;

            Console.WriteLine($"idade: {idade}");
            Console.WriteLine($"copiaIdade: {copiaIdade}");

            int? idade2 = null;
            System.Nullable<int> idade3 = null;
        }
    }
}