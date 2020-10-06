using System;
using System.Collections.Generic;

namespace Zambon.Alura.CertificacaoCSharp.Collections.Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            var esperanca = new Filme("Episódio IV -Uma nova esperança", 1977);
            var imperio = new Filme("Episódio V -O Império Contra-Ataca", 1980);
            var retorno = new Filme("Episódio VI -O Retorno de Jedi", 1983);
            var ameaca = new Filme("Episódio I: A Ameaça Fantasma", 1999);

            //SETS = CONJUNTOS

            //declarando set de filmes
            ISet<Filme> filmes = new HashSet<Filme>();

            //adicionando: esperanca, imperio, retorno
            filmes.Add(esperanca);
            filmes.Add(imperio);
            filmes.Add(retorno);

            //Características do Set (conjunto)
            //1. Não permite duplicidade
            Imprimir(filmes);
            filmes.Add(retorno);
            Imprimir(filmes);

            //2. Os elementos não são mantidos em ordem específica
            filmes.Remove(imperio);
            Imprimir(filmes);
            filmes.Add(ameaca);
            Imprimir(filmes);

            //3. Não permite acesso pelo índice
            //filmes[0].

            //Qual a vantagem do set sobre a lista? Tempo de pesquisa!!
            //https://stackoverflow.com/a/10762995

            //Desvantagem: Consumo de memória

            //É possível ordenar um conjunto?
            //filmes.Sort();

            //Copiando para uma lista
            var listaFilmes = new List<Filme>(filmes);
            //Ordenando a cópia
            listaFilmes.Sort();
            Imprimir(listaFilmes);

            //Verificando se object existe
            Console.WriteLine("O filme Uma Nova Esperança existe? " + filmes.Contains(esperanca));

            //Verificando se objeto com mesmos dados existe
            var novaEsperanca = new Filme("Episódio IV -Uma nova esperança", 1977);
            Console.WriteLine("O filme Uma Nova Esperança existe? " + filmes.Contains(novaEsperanca));
        }

        private static void Imprimir(IEnumerable<Filme> filmes)
        {
            foreach (var filme in filmes)
            {
                Console.WriteLine(filme);
            }
            Console.WriteLine();
        }
    }

    public class Filme : IComparable
    {
        public Filme(string titulo, int ano)
        {
            Titulo = titulo;
            Ano = ano;
        }

        public string Titulo { get; set; }
        public int Ano { get; set; }

        public int CompareTo(object obj)
        {
            Filme esta = this;
            Filme outra = obj as Filme;

            if (outra == null)
            {
                return 1;
            }

            return esta.Titulo.CompareTo(outra.Titulo);
        }

        public override string ToString()
        {
            return $"{Titulo} - {Ano}";
        }

        public override bool Equals(object obj)
        {
            Filme outra = obj as Filme;
            if (outra == null)
            {
                return false;
            }

            return outra.Titulo.Equals(this.Titulo)
                && outra.Ano.Equals(this.Ano);
        }

        public override int GetHashCode()
        {
            int hashCode = -131496797;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Titulo);
            hashCode = hashCode * -1521134295 + Ano.GetHashCode();
            return hashCode;
        }
    }
}