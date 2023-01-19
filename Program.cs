using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Displaying IP address to the console
            Console.WriteLine("IP Address of the computer is : " + LocalIPAddress());

            //Coding for Server

            // 1. Create Socket

            Socket m_listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 2. Bind to a port

            int iPort = 8080;
            IPEndPoint m_LocalIPEP = new IPEndPoint(IPAddress.Any, iPort);
            m_listenSocket.Bind(m_LocalIPEP);

            Console.WriteLine("Server IP Address : " +LocalIPAddress());

            Console.WriteLine("Listening on port "+ iPort);

            // 3. Put it in listen Mode

            m_listenSocket.Listen(4);

            // 4. Accept the connection

            Socket m_acceptSocket = m_listenSocket.Accept();

            // 5. Receive data

            Byte[] ReceiveBuffer = new Byte[1024];
            int count;

            count =  m_acceptSocket.Receive(ReceiveBuffer,SocketFlags.None);
            if (count > 0) { 
                String msg = Encoding.ASCII.GetString(ReceiveBuffer,0,count);
                Console.WriteLine(msg);
            }

            // 6. Shutdown & Close the socket

            m_acceptSocket.Shutdown(SocketShutdown.Both);

            m_acceptSocket.Close();

        }

        //Method to obtain the IP address & display

        public static String LocalIPAddress() {
            IPHostEntry host;
            String localIP = "";

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in host.AddressList){
                if (ip.AddressFamily == AddressFamily.InterNetwork ) {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
    }
}