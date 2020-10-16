using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.DatabaseHandling
{
    class UsingSqlParameters
    {
        private const string DatabaseServer = "(LocalDB)\\MSSQLLocalDB";
        private const string MasterDatabase = "master";
        private const string DatabaseName = "Cinema";

        static async Task Main(string[] args)
        {
            await CriarBancoDeDadosAsync();

            string connectionString = $"Server={DatabaseServer};Integrated security=SSPI;database={DatabaseName}";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                await ListarFilmes(connection);

                //TAREFA: EVITAR A TÉCNICA DE SQL INJECTION

                Console.Write("Digite o Id do filme a ser alterado: ");
                string filmeId = Console.ReadLine();
                Console.Write("Digite o novo título do filme: ");
                string novoTitulo = Console.ReadLine();

                int result;
                string textoComando = "UPDATE Filmes SET Titulo=@novoTitulo WHERE Id = @filmeId;";
                using (var command = new SqlCommand(textoComando, connection))
                {
                    command.Parameters.AddWithValue("@novoTitulo", novoTitulo);
                    command.Parameters.AddWithValue("@filmeId", filmeId);

                    result = await command.ExecuteNonQueryAsync();
                }
                Console.WriteLine("Número de linhas atualizadas: {0}", result);

                await ListarFilmes(connection);
            }

            Console.ReadKey();
        }

        static async Task ListarFilmes(SqlConnection connection)
        {
            using (var command = new SqlCommand(
                " SELECT d.Nome AS Diretor, f.Id, f.Titulo AS Titulo" +
                " FROM Filmes AS f" +
                " INNER JOIN Diretores AS d" +
                "   ON d.Id = f.DiretorId"
                , connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    string diretor = reader.GetString("Diretor");
                    string filmeId = reader.GetString("Id");
                    string titulo = reader.GetString("Titulo");

                    Console.WriteLine($"Diretor: {diretor}, Titulo: {filmeId}-{titulo}");
                }
            }
        }


        #region Banco de dados
        private static async Task CriarBancoDeDadosAsync()
        {
            await CriarBancoAsync();
            await CriarTabelasAsync();
            await InserirRegistrosAsync();
        }

        private static async Task CriarBancoAsync()
        {
            string sql = $@"IF EXISTS (SELECT * FROM sys.databases WHERE name = N'{DatabaseName}')
                    BEGIN
                        DROP DATABASE [{DatabaseName}]
                    END;
                    CREATE DATABASE [{DatabaseName}];";
            await ExecutarComandoAsync(sql, MasterDatabase);
        }

        private static async Task CriarTabelasAsync()
        {
            string sql = $@"CREATE TABLE [dbo].[Diretores] (
                        [Id]   INT           IDENTITY (1, 1) NOT NULL,
                        [Nome] VARCHAR (255) NOT NULL
                    );
                    CREATE TABLE [dbo].[Filmes] (
                        [Id]        INT           IDENTITY (1, 1) NOT NULL,
                        [DiretorId] INT           NOT NULL,
                        [Titulo]    VARCHAR (255) NOT NULL,
                        [Ano]       INT           NOT NULL,
                        [Minutos]   INT           NOT NULL
                    );";
            await ExecutarComandoAsync(sql, DatabaseName);
        }

        private static async Task InserirRegistrosAsync()
        {
            string sql = @"
                    INSERT Diretores (Nome) VALUES ('Quentin Tarantino');
                    INSERT Diretores (Nome) VALUES ('James Cameron');
                    INSERT Diretores (Nome) VALUES ('Tim Burton');

                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Pulp Fiction', 1994,	154);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Django Livre', 2012,	165);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Kill Bill Volume 1', 2003,	111);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'Avatar', 2009,	162);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'Titanic', 1997,	194);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'O Exterminador', 1984,	107);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'O Estranho Mundo de Jack', 1993,	76);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'Alice', 2010,	108);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Noiva Cadáver', 2005,	77);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Fantástica Fábrica de Chocolate', 2005,	115);";
            await ExecutarComandoAsync(sql, DatabaseName);
        }

        private static async Task ExecutarComandoAsync(string sql, string banco)
        {
            using (var connection = new SqlConnection($"Server={DatabaseServer};Integrated security=SSPI;database={banco}"))
            using (var command = new SqlCommand(sql, connection))
            {
                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    Console.WriteLine("Script executado com sucesso.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        #endregion
    }
}