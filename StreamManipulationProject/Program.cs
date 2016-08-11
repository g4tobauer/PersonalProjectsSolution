using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamManipulationProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            ReadFiles();
        }

        static void ReadFiles()
        {
            int tamanhoBuffer = 10;
            // O arquivo que será lido
            Stream streamEntrada = File.OpenRead(@"C:\Users\dvp03\Documents\visual studio 2013\Projects\PersonalProjectsSolution\StreamManipulationProject\Files\Texto.txt");

            // O arquivo que será escrito
            Stream streamSaida = File.OpenWrite(@"C:\Users\dvp03\Documents\visual studio 2013\Projects\PersonalProjectsSolution\StreamManipulationProject\Files\TextoCopia.txt");

            // O buffer que irá armazenar o bytes
            byte[] buffer = new Byte[tamanhoBuffer];

            int bytesLidos;

            //escreve no arquivo enquanto houver bytes no buffer a serem escritos 
            while ((bytesLidos = streamEntrada.Read(buffer, 0, buffer.Length)) > 0)
            {
                streamSaida.Write(buffer, 0, bytesLidos);
            }

            //Fecha as streams
            streamSaida.Close();
            streamEntrada.Close();

        }
    }
}
