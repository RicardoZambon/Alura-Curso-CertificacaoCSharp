#define RELATORIO_DETALHADO
//#define RELATORIO_RESUMIDO

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.AttributesRead
{
    interface IRelatorio
    {
        string Nome { get; set; }
        void Imprimir();
    }

    class Relatorio : IRelatorio
    {
        public string Nome { get; set; }
        readonly IList<Venda> vendas;

        public Relatorio(string nome)
        {
            this.Nome = nome;
            vendas = JsonConvert.DeserializeObject<List<Venda>>(File.ReadAllText("Vendas.json"));
        }

        public void Imprimir()
        {
            Cabecalho();
            ListagemResumida();
            ListagemDetalhada();
            Console.WriteLine();
        }

        [Conditional("RELATORIO_DETALHADO"), Conditional("RELATORIO_RESUMIDO")]
        void Cabecalho()
        {
            Console.WriteLine(this.Nome);
            Console.WriteLine("=============================");
        }

        [Conditional("RELATORIO_DETALHADO")]
        void ListagemDetalhada()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento Nome                  Cidade                Região                Pais");
            Console.WriteLine("==========================================================================================================================================");

            var formatoDetalhado = (FormatoDetalhadoAttribute)Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoDetalhadoAttribute));

            foreach (var venda in vendas)
            {
                Console.WriteLine(formatoDetalhado.Formato
                            , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento, venda.Nome, venda.Cidade, venda.Estado, venda.Pais);
            }
        }

        [Conditional("RELATORIO_RESUMIDO")]
        void ListagemResumida()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento   ");
            Console.WriteLine("==========================================================");

            var formatoResumido = (FormatoResumidoAttribute)Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoResumidoAttribute));

            foreach (var venda in vendas)
            {
                Console.WriteLine(formatoResumido.Formato
                    , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento);
            }
        }
    }
}