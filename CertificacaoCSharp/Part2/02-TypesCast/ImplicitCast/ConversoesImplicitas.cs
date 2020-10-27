using System;

namespace Zambon.Alura.CertificacaoCSharp.TypesCast.ImplicitCast
{
    class ConversoesImplicitas
    {
        public void Executar()
        {
            int inteiro = 2_123_456_789;
            long inteiroLongo = inteiro;
            Console.WriteLine(inteiroLongo);

            //inteiro = inteiroLongo;

            ///<image url="$(ProjectDir)img12.png" />

            Gato gato = new Gato();
            Animal animal = gato;
            Console.WriteLine(animal.GetType());
            IAnimal ianimal = gato;
            Console.WriteLine(ianimal.GetType());
            //gato = ianimal;

        }
    }

    class Gato : Animal
    {

    }

    class Animal : IAnimal
    {

    }

    interface IAnimal
    {

    }
}

//TABELA DE CONVERSÕES NUMÉRICAS IMPLÍCITAS
//=========================================

//De        Para
//=============================================================
//sbyte     short, int, long, float, double ou decimal
//byte      short, ushort, int, uint, long, ulong, float, double ou decimal
//short     int, long, float, double ou decimal
//ushort    int, uint, long, ulong, float, double ou decimal
//int       long, float, double ou decimal
//uint      long, ulong, float, double ou decimal
//long      float, double ou decimal
//char      ushort, int, uint, long, ulong, float, double ou decimal
//float     double
//ulong     float, double ou decimal
//double    (nenhum)
//decimal   (nenhum)