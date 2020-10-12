using System;
using System.Collections.Generic;

namespace Zambon.Alura.CertificacaoCSharp.Events.Events
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var campainha = new Campainha();
                campainha.OnCampainhaTocou += CampainhaTocou1;
                campainha.OnCampainhaTocou += CampainhaTocou2;

                Console.WriteLine("A campainha será tocada.");
                campainha.Tocar("101");

                campainha.OnCampainhaTocou -= CampainhaTocou1;
                Console.WriteLine("A campainha será tocada.");
                campainha.Tocar("202");

            }
            catch (AggregateException e)
            {
                foreach (var exc in e.InnerExceptions)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        static void CampainhaTocou1(object sender, CampainhaEventArgs args)
        {
            Console.WriteLine($"A campainha tocou no apartamento {args.Apartamento}. (1)");
            throw new Exception($"Ocorreu um erro em {nameof(CampainhaTocou1)}");
        }

        static void CampainhaTocou2(object sender, CampainhaEventArgs args)
        {
            Console.WriteLine($"A campainha tocou no apartamento {args.Apartamento}. (2)");
            throw new Exception($"Ocorreu um erro em {nameof(CampainhaTocou2)}");
        }
    }

    class Campainha
    {
        public event EventHandler<CampainhaEventArgs> OnCampainhaTocou;

        public void Tocar(string apartamento)
        {
            var erros = new List<Exception>();
            foreach (var manipulador in OnCampainhaTocou.GetInvocationList())
            {
                try
                {
                    manipulador.DynamicInvoke(this, new CampainhaEventArgs(apartamento));
                }
                catch (Exception e)
                {
                    erros.Add(e.InnerException);
                }
            }

            if (erros.Count > 0)
            {
                throw new AggregateException(erros);
            }
        }
    }

    class CampainhaEventArgs : EventArgs
    {
        public string Apartamento { get; }

        public CampainhaEventArgs(string apartamento)
        {
            Apartamento = apartamento;
        }
    }
}