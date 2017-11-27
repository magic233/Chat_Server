using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Chat_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            const int textSize = 8192;
            Console.WriteLine("Server is running ...");
            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            TcpListener listener = new TcpListener(ip, 8500);
            listener.Start();
            Console.WriteLine("Start Listening ...");
            TcpClient remoteClient = listener.AcceptTcpClient();
            NetworkStream streamToClient = remoteClient.GetStream();
            byte[] text = new byte[textSize];
            int bytesRead = streamToClient.Read(text, 0, textSize);
            Console.WriteLine("Reading data,{0} bytes...", bytesRead);
            string msg = Encoding.Unicode.GetString(text, 0, bytesRead);
            Console.WriteLine(msg);
            streamToClient.Write(text, 0, textSize);
            Console.WriteLine("Enter Q exit ...");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
        }
    }
}
