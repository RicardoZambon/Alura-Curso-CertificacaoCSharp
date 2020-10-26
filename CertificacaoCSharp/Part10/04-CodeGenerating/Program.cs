using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.CodeGenerating
{
    //Gerar código em tempo de execução usando expressões CodeDom e lambda

    class Program
    {
        static void Main(string[] args)
        {
            //TAREFA: Utilizar código C# para gerar código C#,
            //          produzindo a classe Funcionario:

            /*
            namespace RecursosHumanos
            {
                using system;
                public class Funcionario
                {
                    public string nome;
                    public decimal salario;
                    public Funcionario(string nome, decimal salario)
                    {
                    }
                }
            }
            */

            //Tarefa 1: criar uma unidade de compilação

            var unit = new CodeCompileUnit();

            //Tarefa 2: criar o namespace RecursosHumanos

            var codeNamespace = new CodeNamespace("RecursosHumanos");

            //Tarefa 2.1: importar o namespace System

            var import = new CodeNamespaceImport("System");
            codeNamespace.Imports.Add(import);

            //Tarefa 2.2: criar a classe Funcionario
            var funcionario = new CodeTypeDeclaration("Funcionario");

            //Tarefa 2.3: criar o campo nome
            var nome = new CodeMemberField(typeof(string), "nome");
            nome.Attributes = MemberAttributes.Public;
            funcionario.Members.Add(nome);

            //Tarefa 2.4: criar o campo salário
            var salario = new CodeMemberField(typeof(decimal), "salario");
            salario.Attributes = MemberAttributes.Public;
            funcionario.Members.Add(salario);

            //Tarefa 2.5: criar o construtor da classe
            var construtor = new CodeConstructor();
            construtor.Attributes = MemberAttributes.Public;

            var parametroNome = new CodeParameterDeclarationExpression(typeof(string), "nome");
            construtor.Parameters.Add(parametroNome);
            var parametroSalario = new CodeParameterDeclarationExpression(typeof(decimal), "salario");
            construtor.Parameters.Add(parametroSalario);

            funcionario.Members.Add(construtor);

            codeNamespace.Types.Add(funcionario);

            //Tarefa 3: cria o provedor de modelo de código

            unit.Namespaces.Add(codeNamespace);

            var provider = CodeDomProvider.CreateProvider("CSharp");

            //Tarefa 4: gerar código e salva o arquivo
            using (var streamWriter = new StreamWriter("Funcionario.cs"))
            {
                provider.GenerateCodeFromCompileUnit(unit, streamWriter, new CodeGeneratorOptions());
            }
        }
    }
}