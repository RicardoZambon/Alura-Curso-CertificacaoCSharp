using System;
using System.IO;

namespace Zambon.Alura.CertificacaoCSharp.FileSystem
{
    class DriveDetails
    {
        private const long KILOBYTE = 1024;
        private const long MEGABYTE = KILOBYTE * 1024;
        private const long GIGABYTE = MEGABYTE * 1024;
        private const long TERABYTE = GIGABYTE * 1024;

        static void _Main(string[] args)
        {
            //TAREFA:
            //=======
            //Nome do drive
            //Verificar se o drive está pronto
            //Tipo do drive
            //Formato do drive
            //Espaço livre, em bytes, KB, MB, GB e TB

            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                Console.WriteLine($"Nome: {drive.Name}");
                if (!drive.IsReady)
                {
                    Console.WriteLine("O drive não está pronto");
                    continue;
                }

                Console.WriteLine($"Tipo: {drive.DriveType}");
                Console.WriteLine($"Formato: {drive.DriveFormat}");
                Console.WriteLine();

                double bytes = drive.TotalFreeSpace;
                Console.WriteLine($"Espaço livre: \n" +
                    $"  {bytes:N0} bytes\n" +
                    $"  {bytes / KILOBYTE:N2} KB\n" +
                    $"  {bytes / MEGABYTE:N2} MB\n" +
                    $"  {bytes / GIGABYTE:N2} GB\n" +
                    $"  {bytes / TERABYTE:N2} TB\n");
            }
        }
    }
}