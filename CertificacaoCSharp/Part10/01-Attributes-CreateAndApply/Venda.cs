using System;
using System.Drawing;

namespace Zambon.Alura.CertificacaoCSharp.AttributesCreateAndApply
{
    [Serializable]
    [FormatoResumido("{0}  {1}  {2}  {3}")]
    [FormatoDetalhado("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}")]
    public class Venda
    {
        public string Data;
        public string Produto;
        public int Preco;
        public string TipoPagamento;
        [NonSerialized]
        public string Nome;
        public string Cidade;
        public string Estado;
        public string Pais;
        public string DataCriacao;
        public string UltimoLogin;
        public double Latitude;
        public double Longitude;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class FormatoResumidoAttribute : Attribute
    {
        public string Formato { get; set; }

        public FormatoResumidoAttribute(string formato)
        {
            Formato = formato;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class FormatoDetalhadoAttribute : Attribute
    {
        public string Formato { get; set; }

        public FormatoDetalhadoAttribute(string formato)
        {
            Formato = formato;
        }
    }
}