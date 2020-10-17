using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zambon.Alura.CertificacaoCSharp.AppDebug.Data;

namespace Zambon.Alura.CertificacaoCSharp.AppDebug
{
    class Program
    {
        private const string DatabaseServer = "(LocalDB)\\MSSQLLocalDB";
        private const string MasterDatabase = "master";
        private const string DatabaseName = "Cinema";

        static async Task Main(string[] args)
        {
            //TraceListener traceListener = new ConsoleTraceListener();
            //TraceListener traceListener = new TextWriterTraceListener("log.txt");

            //Trace.Listeners.Add(traceListener);
            //Trace.AutoFlush = true;

            var cinemaDB = new CinemaDB(DatabaseServer, MasterDatabase, DatabaseName);

            await cinemaDB.CriarBancoDeDadosAsync();

            IList<Filme> filmes = await cinemaDB.GetFilmes();

            Console.WriteLine($"| {"RELATÓRIO DE FILMES",41}{"",22} |");
            Console.WriteLine(new string('=', 67));
            foreach (var filme in filmes)
            {
                Console.WriteLine($"| {filme.Diretor,-20} | {filme.Titulo,-40} |");
                Console.WriteLine(new string('-', 67));
            }

            //traceListener.Flush();
            Console.ReadKey();
        }
    }
}