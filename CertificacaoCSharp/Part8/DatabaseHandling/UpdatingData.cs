using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Zambon.Alura.CertificacaoCSharp.DatabaseHandling
{
    class UpdatingData
    {
        private const string DatabaseServer = "(LocalDB)\\MSSQLLocalDB";
        private const string MasterDatabase = "master";
        private const string DatabaseName = "Cinema";

        static async Task _Main(string[] args)
        {
            await CriarBancoDeDadosAsync();

            string connectionString = $"Server={DatabaseServer};Integrated security=SSPI;database={DatabaseName}";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                await ListarFilmes(connection);

                //TAREFA:
                //1. Mudar o nome do primeiro diretor para "Quentin Tarantino"
                //2. Contar quantas linhas foram atualizadas

                int result;
                using (var command = new SqlCommand("UPDATE Diretores SET Nome ='QUENTIN TARANTINO' WHERE Id = 1", connection))
                {
                    result = await command.ExecuteNonQueryAsync();
                }
                Console.WriteLine($"Número de linhas atualizadas: {result}");

                await ListarFilmes(connection);
            }

            Console.ReadKey();

        }

        static async Task ListarFilmes(SqlConnection connection)
        {
            using (var command = new SqlCommand(
                " SELECT d.Nome AS Diretor, f.Titulo AS Titulo" +
                " FROM Filmes AS f" +
                " INNER JOIN Diretores AS d" +
                "   ON d.Id = f.DiretorId"
                , connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var diretor = reader.GetString("Diretor");
                    var titulo = reader.GetString("Titulo");
                    Console.WriteLine($"Diretor: {diretor} Titulo: {titulo}");
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
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'O Exterminador do Futuro', 1984,	107);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'O Estranho Mundo de Jack', 1993,	76);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'Alice no País das Maravilhas', 2010,	108);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Noiva Cadáver', 2005,	77);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Fantástica Fábrica de Chocolate', 2005,	115);";
            await ExecutarComandoAsync(sql, DatabaseName);
        }

        private static async Task ExecutarComandoAsync(string sql, string banco)
        {
            SqlConnection conexao = new SqlConnection($"Server={DatabaseServer};Integrated security=SSPI;database={banco}");
            SqlCommand comando = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                await comando.ExecuteNonQueryAsync();
                Console.WriteLine("Script executado com sucesso.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }
        #endregion
    }
}