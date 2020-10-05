using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zambon.Alura.CertificacaoCSharp.Serialization..JSON
{
    [JsonObject(nameof(LojaDeFilmes))]
    public class MovieStore
    {
        [JsonProperty(nameof(LojaDeFilmes.Diretores))]
        public List<Director> Directors = new List<Director>();
        [JsonProperty(nameof(LojaDeFilmes.Filmes))]
        public List<Movie> Movies = new List<Movie>();
        public static MovieStore AddMovie(Movie movie)
        {
            MovieStore store = new MovieStore();
            // ...
            return store;
        }
    }

    [JsonObject(nameof(Diretor))]
    public class Director
    {
        [JsonProperty(nameof(Diretor.Nome))]
        public string Name { get; set; }
        [JsonIgnore]
        public int NumberOfMovies;
    }

    [JsonObject(nameof(Filme))]
    public class Movie
    {
        [JsonProperty(nameof(Filme.Diretor))]
        public Director Director { get; set; }
        [JsonProperty(nameof(Filme.Titulo))]
        public string Title { get; set; }
        [JsonProperty(nameof(Filme.Ano))]
        public string Year { get; set; }
    }
}