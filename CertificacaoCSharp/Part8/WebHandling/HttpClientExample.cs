using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.WebHandling
{
    class HttpClientExample
    {
        static async Task Main(string[] args)
        {
            //TAREFA:
            //Conectar-se site da caelum (http://www.caelum.com.br)
            //de forma ASSÍNCRONA, porém o código precisa rodar em 
            // 
            // - Aplicações Windows (Windows Forms, WPF)
            // - Aplicações Web (ASP.NET e ASP.NET Core)
            // - Xamarin (aplicativos de celular / tablet)
            // - Windows Universal Application Platform

            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("http://www.caelum.com.br");

            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}