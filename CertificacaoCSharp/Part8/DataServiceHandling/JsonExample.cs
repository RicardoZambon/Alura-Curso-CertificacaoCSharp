using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Zambon.Alura.CertificacaoCSharp.DataServiceHandling
{
    class JsonExample
    {
        static async Task _Main(string[] args)
        {
            //TAREFA:
            //CONSULTAR OS DADOS DO CEP 04101-300
            //NO SERVIÇO DA http://viacep.com.br
            //E EXIBIR SEUS DADOS

            Console.Write("Digite um CEP para a pesquisa: ");
            var cep = Console.ReadLine();

            while (cep.Length < 8)
            {
                var foregroundColor = Console.ForegroundColor;
                Console.Write("CEP informado é ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("inválido");
                Console.ForegroundColor = foregroundColor;
                Console.Write(", informe um novo CEP: ");
                cep = Console.ReadLine();
            }

            var url = $"http://viacep.com.br/ws/{cep}/json";

            Endereco endereco;
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                endereco = JsonConvert.DeserializeObject<Endereco>(json);
            }

            Console.WriteLine();
            Console.WriteLine("DADOS DO CEP:");
            Console.WriteLine(
                $"Logradouro: {endereco.Logradouro}\n" +
                $"Bairro: {endereco.Bairro}\n" +
                $"Município: {endereco.Municipio}\n" +
                $"UF: {endereco.UF}\n" +
                $"CEP: {endereco.CEP}\n");

            Console.ReadKey();
        }
    }

    class Endereco
    {
        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        public string Municipio { get; set; }

        public string UF { get; set; }
    }
}