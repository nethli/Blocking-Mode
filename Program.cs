using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get the server IP address and the port number
            String serverIP = "";
            String serverPort = "";

            Console.WriteLine("Enter the IP Address of the Server : ");
            serverIP = Console.ReadLine();

            Console.WriteLine("Enter the Port Number of the Server : ");
            serverPort = Console.ReadLine();

            // 1. Create the socket 

            Socket m_sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 2. Connect to the server

            IPAddress destIP = IPAddress.Parse(serverIP);
            int destPort = System.Convert.ToInt16(serverPort);

            IPEndPoint destEP = new IPEndPoint(destIP, destPort);

            // User Message

            Console.WriteLine("Waiting to Connect..");
            m_sendSocket.Bind(destEP);
            Console.WriteLine("Connected.");

            // 3. Send Data

            string msg;
            Console.WriteLine("Enter message to send : ");
            msg = Console.ReadLine();

            Byte[] s_data = System.Text.Encoding.ASCII.GetBytes(msg);

            // User Message
            Console.WriteLine("Sending Data..");
            m_sendSocket.Send(s_data, SocketFlags.None);

            // User Message
            Console.WriteLine("Sending Completed..");

            // 4. Shutdown & Close Socket
            m_sendSocket.Shutdown(SocketShutdown.Both);
            m_sendSocket.Close();

        }
    }
}