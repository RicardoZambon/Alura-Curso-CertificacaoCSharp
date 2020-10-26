﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Zambon.Alura.CertificacaoCSharp.UserInterface
{
    public partial class Form1 : Form
    {
        Stopwatch relogio;

        public Form1()
        {
            InitializeComponent();
            relogio = new Stopwatch();
            relogio.Start();
        }

        private void btnRelogio_Click(object sender, EventArgs e)
        {
            VisualizaRelogio();
        }

        private void VisualizaRelogio()
        {
            Thread.Sleep(100);
            TimeSpan tempo = relogio.Elapsed;
            int minutos = tempo.Minutes;
            int segundos = tempo.Seconds;
            int milissegundos = tempo.Milliseconds;
            txtRelogio.Text = $"{minutos:00}:{segundos:00}:{milissegundos:000}";
        }
    }
}
