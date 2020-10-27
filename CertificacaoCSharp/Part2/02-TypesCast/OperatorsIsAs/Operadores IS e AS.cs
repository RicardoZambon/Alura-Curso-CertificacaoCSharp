using System;

namespace Zambon.Alura.CertificacaoCSharp.TypesCast.OperatorsIsAs
{
    class OperadoresISeAS
    {
        public void Executar()
        {
            Animal animal = new Animal();
            Gato gato = new Gato();
            Cliente cliente = new Cliente("José da Silva", 30);

            Alimentar(animal);
            Alimentar(gato);
            Alimentar(cliente);
        }

        public void Alimentar(object obj)
        {
            if (obj is Animal animal)
            {
                animal.Beber();
                animal.Comer();
                return;
            }

            Console.WriteLine("obj não é um animal");
        }
    }

    class Gato : Animal
    {

    }

    class Animal
    {
        public void Beber()
        {

        }

        public void Comer()
        {

        }
    }

    class Cliente
    {
        public Cliente(string nome, int idade)
        {

        }
    }
}