using System;
using System.Reflection;

namespace Zambon.Alura.CertificacaoCSharp.ReflectionGetModulesTypesMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tarefa 1: obter o nome completo do assembly atual

            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"Nome do assembly: {assembly.FullName}");
            Console.WriteLine();
            //Tarefa 2: obter a versão do assembly atual

            //Obter a identidade do assembly primeiro.
            var identidadeAssembly = assembly.GetName();
            Console.WriteLine($"Versão: {identidadeAssembly.Version}");
            Console.WriteLine($"Versão Major: {identidadeAssembly.Version.Major}");
            Console.WriteLine($"Versão Minor: {identidadeAssembly.Version.Minor}");
            Console.WriteLine();

            //Tarefa 3: descobrir se o assembly atual 
            //          está no Global Assembly Cache

            Console.WriteLine($"Está no Global Assembly Cache? {assembly.GlobalAssemblyCache}");
            Console.WriteLine();

            //Tarefa 4: descobrir todos os módulos, 
            //          tipos e membros do assembly

            foreach (var modulo in assembly.GetModules())
            {
                Console.WriteLine($"Módulo: {modulo}");
            }
            Console.WriteLine();

            foreach (var tipo in assembly.GetTypes())
            {
                Console.WriteLine($"\tTipo: {tipo}");
                Console.WriteLine();

                foreach (var membro in tipo.GetMembers())
                {
                    Console.WriteLine($"\t\tMembro: {membro} ({membro.MemberType})");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}