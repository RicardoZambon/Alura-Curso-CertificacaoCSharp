﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zambon.Alura.CertificacaoCSharp.Serialization.JSON
{
    public class LojaDeFilmes
    {
        public List<Diretor> Diretores = new List<Diretor>();
        public List<Filme> Filmes = new List<Filme>();
        public static void AdicionarFilme(Filme filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    public class Diretor
    {
        public string Nome { get; set; }
        [JsonIgnore]
        public int NumeroFilmes;
    }

    public class Filme
    {
        public Diretor Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }
}