using System;
using System.IO;
using System.Net;

namespace Zambon.Alura.CertificacaoCSharp.WebHandling
{
    class WebRequestExample
    {
        static void _Main(string[] args)
        {
            //TAREFAS:
            //1) conectar-se site da caelum (http://www.caelum.com.br)
            //2) obter o conteúdo da página do site
            //3) exibir o conteúdo da página

            var request = WebRequest.Create("http://www.caelum.com.br");
            var response = request.GetResponse();

            string siteContent;
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                siteContent = stream.ReadToEnd();
            }

            Console.WriteLine(siteContent);
            Console.ReadKey();
        }
    }
}