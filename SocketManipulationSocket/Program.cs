using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketManipulationSocket
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
            Teste2();
        }

        static void Teste()
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(localAddr, 8080);
            tcpListener.Start();

            for (; ; )
            {
                Socket socket = tcpListener.AcceptSocket();

                if (socket.Connected)
                {

                }

            }
        }

        static void Teste2()
        {
            byte[] input = new byte[] { 1 };
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            socket.Bind(new IPEndPoint(IPAddress.Broadcast, 80));
            socket.IOControl(IOControlCode.ReceiveAll, input, null);

            byte[] buffer = new byte[0x10000];

            //Task.Factory.StartNew(() =>
            //{
                while (true)
                {
                    int len = socket.Receive(buffer);
                    if (len <= 40) continue; //Poor man's check for TCP payload
                    string bin = Encoding.UTF8.GetString(buffer, 0, len); //Don't trust to this line. Encoding may be different :) even it can contain binary data like images, videos etc.
                    Console.WriteLine(bin);
                }
            //});
        }
    }
}
