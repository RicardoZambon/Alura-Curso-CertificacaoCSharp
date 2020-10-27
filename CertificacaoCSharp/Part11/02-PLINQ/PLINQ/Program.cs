﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Zambon.Alura.CertificacaoCSharp.QLINQ
{
    //PLINQ = Parallel LINQ
    class Program
    {
        public class Filme
        {
            public string Titulo { get; set; }
            public decimal Faturamento { get; set; }
            public decimal Orcamento { get; set; }
            public string Distribuidor { get; set; }
            public string Genero { get; set; }
            public string Diretor { get; set; }
            public decimal Lucro { get; set; }
            public decimal LucroPorcentagem { get; set; }

            public int CompareTo(object obj)
            {
                Filme outro = obj as Filme;
                return Titulo.CompareTo(outro.Titulo);
            }
        }

        static void Main(string[] args)
        {
            IEnumerable<Filme> filmes =
                JsonConvert.DeserializeObject<IEnumerable<Filme>>
                (File.ReadAllText("filmes.json"));

            var consulta =
                from f in filmes
                select new Filme
                {
                    Titulo = f.Titulo,
                    Faturamento = f.Faturamento,
                    Orcamento = f.Orcamento,
                    Distribuidor = f.Distribuidor,
                    Genero = f.Genero,
                    Diretor = f.Diretor,
                    Lucro = f.Faturamento - f.Orcamento,
                    LucroPorcentagem = (f.Faturamento - f.Orcamento) / f.Orcamento
                };

            filmes = consulta;

            var stopwatch = new Stopwatch();
            var times = new long[8];


            //Tarefa 1: obter a lista de filmes de Aventura

            stopwatch.Start();

            var consulta1 =
                from f in filmes
                where f.Genero == "Adventure"
                select f;

            GeraRelatorio("Tarefa 1: obter a lista de filmes de Aventura", consulta1);

            stopwatch.Stop();
            times[0] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();


            //Tarefa 2: obter a lista de filmes de Aventura, executando em PARALELO

            stopwatch.Restart();

            var consulta2 =
                from f in filmes.AsParallel()
                where f.Genero == "Adventure"
                select f;

            GeraRelatorio("Tarefa 2: obter a lista de filmes de Aventura, executando em PARALELO", consulta2);

            stopwatch.Stop();
            times[1] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();


            //Tarefa 3: obter a lista de filmes de Aventura, executando em PARALELO com modo de execução default

            stopwatch.Restart();

            var consulta3 =
                from f in filmes.AsParallel().WithExecutionMode(ParallelExecutionMode.Default)
                where f.Genero == "Adventure"
                select f;

            GeraRelatorio("Tarefa 3: obter a lista de filmes de Aventura, executando em PARALELO com modo de execução default", consulta3);

            stopwatch.Stop();
            times[2] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();


            //Tarefa 4: obter a lista de filmes de Aventura, executando em PARALELO forçando paralelismo

            stopwatch.Restart();

            var consulta4 =
                from f in filmes.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                where f.Genero == "Adventure"
                select f;

            GeraRelatorio("Tarefa 4: obter a lista de filmes de Aventura, executando em PARALELO forçando paralelismo", consulta4);

            stopwatch.Stop();
            times[3] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();


            //Tarefa 5: obter a lista de filmes de Aventura, executando em PARALELO forçando paralelismo e com grau de paralelismo = 4

            stopwatch.Restart();

            var consulta5 =
                from f in filmes.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism).WithDegreeOfParallelism(4)
                where f.Genero == "Adventure"
                select f;

            GeraRelatorio("Tarefa 5: obter a lista de filmes de Aventura, executando em PARALELO forçando paralelismo e com grau de paralelismo = 4", consulta5);

            stopwatch.Stop();
            times[4] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();


            //Tarefa 6: obter a lista de filmes de Aventura, executando em PARALELO e preservando a ordem

            stopwatch.Restart();

            var consulta6 =
                from f in filmes.AsParallel().AsOrdered()
                where f.Genero == "Adventure"
                select f;

            GeraRelatorio("Tarefa 6: obter a lista de filmes de Aventura, executando em PARALELO e preservando a ordem", consulta6);

            stopwatch.Stop();
            times[5] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();


            //Tarefa 7: obter os 4 filmes de Aventura de maior faturamento, executando em PARALELO

            stopwatch.Restart();

            var consulta7 =
                (from f in filmes.AsParallel().AsOrdered()
                 where f.Genero == "Adventure"
                 orderby f.Faturamento descending
                 select f).Take(4);

            GeraRelatorio("Tarefa 7: obter os 4 filmes de Aventura de maior faturamento, executando em PARALELO", consulta7);

            stopwatch.Stop();
            times[6] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();


            //Tarefa 8: Imprimir somente os títulos dos filmes, de aventura, consultando em PARALELO e usando uma ação em PARALELO

            stopwatch.Restart();

            var consulta8 =
                from f in filmes.AsParallel()
                where f.Genero == "Adventure"
                select f;

            consulta8.ForAll(filme =>
            {
                Console.WriteLine(filme.Titulo);
            });

            stopwatch.Stop();
            times[7] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();


            Console.WriteLine();
            Console.WriteLine("Tempos de execução:");
            for (var i = 0; i < 8; i++)
            {
                Console.WriteLine($"Tarefa {i + 1}: {times[i] / 1000.0:N3} segundos");
            }
            Console.WriteLine();

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        private static void GeraRelatorio(string tituloRelatorio, IEnumerable<Filme> resultado)
        {
            Console.WriteLine("Relatório: {0}", tituloRelatorio);

            Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    "Item",
                    "Faturamento",
                    "Orcamento",
                    "Lucro",
                    "% Lucro");
            Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    new string('=', 30),
                    new string('=', 20),
                    new string('=', 20),
                    new string('=', 20),
                    new string('=', 10));

            foreach (var item in resultado)
            {
                Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    item.Titulo,
                    item.Faturamento,
                    item.Orcamento,
                    item.Lucro,
                    item.LucroPorcentagem);
            }
            Console.WriteLine();
            Console.WriteLine("FIM DO RELATÓRIO: {0}", tituloRelatorio);
        }
    }
}