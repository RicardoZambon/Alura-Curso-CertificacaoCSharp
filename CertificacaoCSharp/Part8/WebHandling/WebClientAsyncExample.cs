using System;
using System.Net;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.WebHandling
{
    class WebClientAsyncExample
    {
        static async Task _Main(string[] args)
        {
            //TAREFA:
            //Conectar-se site da caelum (http://www.caelum.com.br)
            //apenas para obter e exibir o conteúdo da página do site
            //de forma ASSÍNCRONA

            string textoDoSite = await GetSiteContent();
            Console.WriteLine(textoDoSite);
            Console.ReadKey();
        }

        private static async Task<string> GetSiteContent()
        {
            var webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync("http://www.caelum.com.br");
        }
    }
}