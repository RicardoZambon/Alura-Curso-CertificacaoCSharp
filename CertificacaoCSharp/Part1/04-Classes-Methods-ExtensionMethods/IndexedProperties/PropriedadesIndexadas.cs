using System;
using System.Collections.Generic;

namespace Zambon.Alura.CertificacaoCSharp.ClassesMethodsExtensionMethods.IndexedProperties
{
    class PropriedadesIndexadas
    {
        public void Executar()
        {
            var sala = new Sala();
            sala["D01"] = new ClienteCinema("Maria de Souza");
            sala["D02"] = new ClienteCinema("José da Silva");

            sala.ImprimirReservas();
        }
    }

    class ClienteCinema
    {
        public ClienteCinema(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }

    class Sala
    {
        private readonly IDictionary<string, ClienteCinema> reservas
            = new Dictionary<string, ClienteCinema>();

        public ClienteCinema this[string codigoAssento]
        {
            get
            {
                return reservas[codigoAssento];
            }

            set
            {
                reservas[codigoAssento] = value;
            }
        }

        public void ImprimirReservas()
        {
            Console.WriteLine("Assentos Reservados");
            Console.WriteLine("===================");
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"{reserva.Key} - {reserva.Value}");
            }
        }
    }
}
///<image url="$(ProjectDir)img6.png" />