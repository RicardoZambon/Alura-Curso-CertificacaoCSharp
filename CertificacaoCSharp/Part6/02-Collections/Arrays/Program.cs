using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.Collections.Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string alura = "Alura";
            string caelum = "Caelum";
            string casaDoCodigo = "Casa do Código";

            Console.WriteLine(alura);
            Console.WriteLine(caelum);
            Console.WriteLine(casaDoCodigo);

            //MATRIZ = ARRAY

            //var empresas = new string[3];
            //empresas[0] = alura;
            //empresas[1] = caelum;
            //empresas[3] = casaDoCodigo;

            //var empresas = new string[]
            //{
            //    alura, caelum, casaDoCodigo
            //};

            string[] empresas = { alura, caelum, casaDoCodigo };

            Imprimir(empresas);

            caelum = "Caelum Ensino e Inovação";

            Imprimir(empresas);

            empresas[1] = "Caelum Ensino e Inovação";

            Imprimir(empresas);

            Console.WriteLine("Primeiro elemento: " + empresas[0]);
            Console.WriteLine("Último elemento: " + empresas[empresas.Length]);

            //Localizando índice da primeira ocorrência no array
            Console.WriteLine("O índice de 'Casa do Código' é: " + Array.IndexOf(empresas, "Casa do Código"));

            //Localizando índice da última ocorrência no array
            Console.WriteLine("O último índice de 'Casa do Código' é: " + Array.LastIndexOf(empresas, "Casa do Código"));

            //Revertendo a sequência do array
            Array.Reverse(empresas);
            Imprimir(empresas);

            //Revertendo NOVAMENTE a sequência do array
             Array.Reverse(empresas);
            Imprimir(empresas);

            //Redimensionando um array (truncando a última posição)
            Array.Resize(ref empresas, 2);
            Imprimir(empresas);

            //Redimensionando um array (deixando a última posição vazia)
            Array.Resize(ref empresas, 3);
            Imprimir(empresas);

        }

        private static void Imprimir(string[] empresas)
        {
            for (int i = 0; i < empresas.Length; i++)
            {
                var empresa = empresas[i];
                Console.WriteLine(empresa);
            }
        }
    }
}