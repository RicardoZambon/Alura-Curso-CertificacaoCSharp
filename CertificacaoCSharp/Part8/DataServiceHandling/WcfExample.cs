using ServiceReference1;
using System;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.DataServiceHandling
{
    class WcfExample
    {
        static async Task Main()
        {
            //TAREFA:
            //1. ADICIONAR UMA REFERÊNCIA A UM SERVIÇO
            //      WCF (WINDOWS COMMUNICATION FOUNDATION)
            //2. CONSUMIR O SERVIÇO E EXIBIR OS CURSOS DE NÚMERO 1 A 15

            var service = new MeuServicoClient();

            for (var i = 1; i <= 15; i++)
            {
                var value = await service.GetValorAsync(i);
                Console.WriteLine($"Nome do curso: {value}");
            }

            Console.ReadKey();
        }
    }
}