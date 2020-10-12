using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Zambon.Alura.CertificacaoCSharp.Collections.CustomCollections
{
    class Program
    {
        static PlacasDeCarro placas = new PlacasDeCarro();

        static void Main(string[] args)
        {
            placas.Add("FND-7714");
            placas.Add("ABC-1234");
            placas.Add("XYZ-9987");
            placas.Add("123-ABCD");

            foreach (var placa in placas)
            {
                Console.WriteLine(placa);
            }

            //PROBLEMA: CRIAR UMA COLEÇÃO DE PLACAS DE CARRO VÁLIDAS
            //SOLUÇÃO: CRIAR UMA COLEÇÃO PERSONALIZADA
        }


    }

    class PlacasDeCarro : ICollection<string>
    {
        private List<string> lista = new List<string>();


        public void Add(string item)
        {
            if (!EhPlacaValida(item))
            {
                throw new ArgumentException($"Placa não é válida: {item}");
            }
            lista.Add(item);
        }

        public void Clear() => lista.Clear();

        public bool Contains(string item) => lista.Contains(item);

        public void CopyTo(string[] array, int arrayIndex) => lista.CopyTo(array, arrayIndex);

        public int Count => lista.Count;

        public IEnumerator<string> GetEnumerator() => lista.GetEnumerator();

        public bool IsReadOnly => false;

        public bool Remove(string item) => lista.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => lista.GetEnumerator();

        static bool EhPlacaValida(string value)
            => new Regex(@"^[A-Z]{3}\-\d{4}$").IsMatch(value);
    }
}