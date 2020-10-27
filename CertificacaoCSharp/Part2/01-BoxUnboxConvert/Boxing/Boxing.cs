using System;

namespace Zambon.Alura.CertificacaoCSharp.BoxUnboxConvert.Boxing
{
    class Boxing
    {
        public void Executar()
        {
            int numero = 57;
            /// nesta linha, numero está sofrendo boxing
            object caixa = numero;
            ///object caixa = numero;
            ///<image url="$(ProjectDir)img11.png" />
            ///Console.WriteLine(String.Concat("Resposta", numero, true));
            Console.WriteLine(string.Concat("Resposta", numero, true));
        }
    }
}