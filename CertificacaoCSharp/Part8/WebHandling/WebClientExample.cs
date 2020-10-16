using System;
using System.Net;

namespace Zambon.Alura.CertificacaoCSharp.WebHandling
{
    class WebRequestAsyncExample
    {
        static void _Main(string[] args)
        {
            //TAREFAS:
            //1) conectar-se site da caelum (http://www.caelum.com.br)
            //2) obter o conteúdo da página do site
            //3) exibir o conteúdo da página

            var webClient = new WebClient();
            var content = webClient.DownloadString("http://www.caelum.com.br");

            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}