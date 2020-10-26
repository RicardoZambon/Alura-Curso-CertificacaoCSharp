using System;
using System.Linq.Expressions;

namespace Zambon.Alura.CertificacaoCSharp.CodeGeneratingExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<float, float> metade = quo => quo / 2;
            Console.WriteLine("Metade de 9 é {0}", metade(9));

            //TAREFA: Recriar a Função acima, 
            //porém usando árvore de expressões LINQ

            //1) Criar as expressões individuas
            var quociente = Expression.Parameter(typeof(float), "quo");

            var divisor = Expression.Constant(2f, typeof(float));

            var opDivisao = Expression.Divide(quociente, divisor);

            //2) Criar a árvore de expressões

            var exprMetade = Expression.Lambda<Func<float, float>>(opDivisao, new ParameterExpression[] { quociente });

            //3) Compilar e executar o codigo

            var metadeCompilada = exprMetade.Compile();
            Console.WriteLine("Metade de 7 é {0}", metadeCompilada(7));

            //4) Modificar a árvore de expressões

            var troca = new TrocarDivisaoPorMultiplicacao();
            var exprDobro = (Expression<Func<float, float>>)troca.Modificar(exprMetade);

            var dobroCompilado = exprDobro.Compile();
            Console.WriteLine("Metade de 15 é {0}", dobroCompilado(15));

            Console.ReadLine();
        }
    }

    class TrocarDivisaoPorMultiplicacao : ExpressionVisitor
    {
        public Expression Modificar(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Divide)
            {
                return Expression.Multiply(node.Left, node.Right);
            }
            return base.VisitBinary(node);
        }
    }
}