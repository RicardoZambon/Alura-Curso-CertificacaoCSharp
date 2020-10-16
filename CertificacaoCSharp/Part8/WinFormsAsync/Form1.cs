using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Item17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTimer.Text = DateTime.Now.ToString("HH:mm:ss:fff");
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            //TAREFA:   IMPLEMENTAR ACESSO ASSÍNCRONO A ARQUIVOS,
            //          TANTO NA LEITURA QUANTO NA GRAVAÇÃO

            // GRAVANDO UM ARQUIVO
            using (var stream = new FileStream("ArquivoSaida.txt", FileMode.Create, FileAccess.Write))
            {
                string message = "Olá, Alura!";

                byte[] array = Encoding.UTF8.GetBytes(message);

                //stream.Write(array, 0, message.Length);
                //Thread.Sleep(2000);
                await stream.WriteAsync(array, 0, message.Length);
                await Task.Delay(2000);
            }

            // LENDO UM ARQUIVO
            using (var stream = new FileStream("ArquivoSaida.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[stream.Length];

                //stream.Read(bytes, 0, (int)stream.Length);
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                string texto = Encoding.UTF8.GetString(bytes);

                Console.WriteLine("Mensagem Lida: " + texto);
            }
        }
    }
}