using System;
using System.Text;

namespace Zambon.Alura.CertificacaoCSharp.Strings.UsingStringBuilder
{
    class Program
    {
        static void _Main(string[] args)
        {
            StringBuilder materias = new StringBuilder();
            materias.Append("Português");
            Console.WriteLine(materias);
            materias.Append(", Matemática");
            Console.WriteLine(materias);
            materias.Append(", Geografia");
            Console.WriteLine(materias);
            Console.ReadKey();

            ///<image url="$(ProjectDir)/img1.png"/>
        }
    }
}