using System;

namespace Zambon.Alura.CertificacaoCSharp.CreateReferenceTypes.Dynamic
{
    class Dinamicos
    {
        public void Executar()
        {
            object objeto = 1;
            //objeto = objeto + 3;

            dynamic dinamico = 1;
            dinamico = dinamico + 3;
            Console.WriteLine(dinamico);

            //dinamico.teste();
        }
    }
}