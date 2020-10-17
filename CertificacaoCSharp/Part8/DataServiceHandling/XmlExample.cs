using System;
using System.IO;
using System.Xml;

namespace Zambon.Alura.CertificacaoCSharp.DataServiceHandling
{
    class XmlExample
    {
        const string xml =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<Filmes>" +
                "<Filme Genero=\"Policial\">" +
                    "<Diretor>Quentin Tarantino</Diretor>" +
                    "<Titulo>Pulp Fiction</Titulo>" +
                    "<Minutos>154</Minutos>" +
                "</Filme>" +
                "<Filme Genero=\"Ficção Científica\">" +
                    "<Diretor>James Cameron</Diretor>" +
                    "<Titulo>Avatar</Titulo>" +
                    "<Minutos>162</Minutos>" +
                "</Filme>" +
            "</Filmes>";

        static void _Main(string[] args)
        {
            //TAREFA:
            //1. LER UMA STRING CONTENDO DOCUMENTO XML:
            //      - DECLARAÇÃO XML
            //      - ELEMENTOS
            //      - TEXTOS
            //      - ATRIBUTOS
            //2. INTERPRETAR CADA NÓ DA ESTRUTURA XML:
            //      - TIPO
            //      - NOME
            //      - VALOR

            using (var reader = new StringReader(xml))
            {
                using (var xmlReader = new XmlTextReader(reader))
                {
                    while (xmlReader.Read())
                    {
                        ReadXml(xmlReader);

                        if (xmlReader.HasAttributes)
                        {
                            while (xmlReader.MoveToNextAttribute())
                            {
                                ReadXml(xmlReader);
                            }
                        }
                    }
                }
            }

            Console.ReadKey();
        }

        private static void ReadXml(XmlTextReader xmlReader)
        {
            Console.WriteLine($"Tipo: {xmlReader.NodeType}, Nome: {xmlReader.Name}, Valor: {xmlReader.Value}");
        }
    }
}