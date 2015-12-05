using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace c_charp_1
{
    class Program
    {
        static const byte SSH_MSG_KEXINIT = 20;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World");
            
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(System.Net.IPAddress.Parse("77.222.40.18"), System.Convert.ToInt16(22));

                if (socket.Connected)
                {
                    Console.WriteLine("Connected!");

                    byte[] data = new byte[100500];

                    int received = socket.Receive(data);
                    Console.WriteLine("Received from server: ");
                    Console.WriteLine(received);
                    for (int i = 0; i < received; ++i)
                    {
                        Console.Write((char)data[i]);
                    }

                    string payload = "SSH-2.0-myclient_v0.1\r\n";

                    socket.Send(Encoding.ASCII.GetBytes(payload));

                    received = socket.Receive(data);

                    UInt32 packet_length = (uint)(data[0] << 24 | data[1] << 16 | data[2] << 8 | data[3]);
                    Byte padding_length = data[4];

                    Console.WriteLine(String.Format("Packet length: {0}", packet_length));
                    Console.WriteLine(String.Format("Padding length: {0}", padding_length));

                    if (data[5] == SSH_MSG_KEXINIT)
                    {
                        Console.WriteLine("SSH_MSG_KEXINIT");
                    }
                }
                else
                {
                    Console.WriteLine("Unable to connect to host!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
