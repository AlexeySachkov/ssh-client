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
        const byte SSH_MSG_KEXINIT = 20;

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

                    Reader reader = new Reader(data);
                    UInt32 packet_length = reader.readUInt32();
                    Byte padding_length = reader.readByte();

                    Console.WriteLine(String.Format("Packet length: {0}", packet_length));
                    Console.WriteLine(String.Format("Padding length: {0}", padding_length));

                    Byte message_type = reader.readByte();

                    if (message_type == SSH_MSG_KEXINIT)
                    {
                        Console.WriteLine("SSH_MSG_KEXINIT");

                        Byte[] cookie = reader.readBytes(16);

                        String[] kex_algoritmhs = reader.readNameList();
                        String[] server_host_key_algorithms = reader.readNameList();
                        String[] encryption_algorithms_client_to_server = reader.readNameList();
                        String[] encryption_algorithms_server_to_client = reader.readNameList();
                        String[] mac_algorithms_client_to_server = reader.readNameList();
                        String[] mac_algorithms_server_to_client = reader.readNameList();
                        String[] compression_algorithms_client_to_server = reader.readNameList();
                        String[] compression_algorithms_server_to_client = reader.readNameList();
                        String[] languages_client_to_server = reader.readNameList();
                        String[] languages_server_to_client = reader.readNameList();
                        Boolean first_kex_packet_follows = reader.readBoolean();

                        Console.WriteLine("\nskex_algorithms: ");
                        if (kex_algoritmhs != null)
                        {
                            for (int i = 0; i < kex_algoritmhs.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", kex_algoritmhs[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tempty list");
                        }

                        Console.WriteLine("\nserver_host_key_algorithms: ");
                        if (server_host_key_algorithms != null)
                        {
                            for (int i = 0; i < server_host_key_algorithms.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", server_host_key_algorithms[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tempty list");
                        }

                        Console.WriteLine("\nencryption_algorithms_client_to_server: ");
                        if (encryption_algorithms_client_to_server != null)
                        {
                            for (int i = 0; i < encryption_algorithms_client_to_server.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", encryption_algorithms_client_to_server[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tempty list");
                        }

                        Console.WriteLine("\nencryption_algorithms_server_to_client: ");
                        if (encryption_algorithms_server_to_client != null)
                        {
                            for (int i = 0; i < encryption_algorithms_server_to_client.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", encryption_algorithms_server_to_client[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tempty list");
                        }

                        Console.WriteLine("\n mac_algorithms_client_to_server: ");
                        if (mac_algorithms_client_to_server != null)
                        {
                            for (int i = 0; i < mac_algorithms_client_to_server.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", mac_algorithms_client_to_server[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("empty list");
                        }

                        Console.WriteLine("\n mac_algorithms_server_to_client: ");
                        if (mac_algorithms_server_to_client != null)
                        {
                            for (int i = 0; i < mac_algorithms_server_to_client.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", mac_algorithms_server_to_client[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tempty list");
                        }

                        Console.WriteLine("\n compression_algorithms_client_to_server: ");
                        if (compression_algorithms_client_to_server != null)
                        {
                            for (int i = 0; i < compression_algorithms_client_to_server.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", compression_algorithms_client_to_server[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tempty list");
                        }

                        Console.WriteLine("\n compression_algorithms_server_to_client: ");
                        if (compression_algorithms_server_to_client != null)
                        {
                            for (int i = 0; i < compression_algorithms_server_to_client.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", compression_algorithms_server_to_client[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tempty list");
                        }

                        Console.WriteLine("\n languages_client_to_server: ");
                        if (languages_client_to_server != null)
                        {
                            for (int i = 0; i < languages_client_to_server.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", languages_client_to_server[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tempty list");
                        }

                        Console.WriteLine("\n languages_server_to_client: ");
                        if (languages_server_to_client != null)
                        {
                            for (int i = 0; i < languages_server_to_client.Length; ++i)
                            {
                                Console.WriteLine("\t{0}", languages_server_to_client[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tempty list");
                        }

                        Console.WriteLine(String.Format("\nfirst_kex_packet_follows: {0}", first_kex_packet_follows));
                    }
                    else
                    {
                        Console.WriteLine("not SSH_MSG_KEXINIT");
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


    class Reader
    {
        private Byte[] data;
        private Int32 pos;
        private Int32 length;

        public Reader(Byte[] _data)
        {
            if (_data == null)
            {
                throw new Exception("Input array cannot be null reference!");
            }

            this.data = _data;
            this.pos = 0;
        }

        public void reset()
        {
            this.pos = 0;
        }

        public Boolean eof()
        {
            return (this.pos == this.data.Length);
        }

        public Byte readByte()
        {
            if (!this.eof())
            {
                return this.data[this.pos++];
            }
            else
            {
                throw new Exception("End of buffer reached!");
            }
        }

        public Byte[] readBytes(int length)
        {
            if (length <= 0)
            {
                throw new Exception("Zero length array not allowed!");
            }
            else if (!this.eof() && this.pos + length < this.data.Length)
            {
                Byte[] res = new Byte[length];
                Array.Copy(this.data, this.pos, res, 0, length);

                this.pos += length;
                return res;
            }
            else
            {
                throw new Exception("End of buffer reached!");
            }
        }

        public UInt32 readUInt32()
        {
            if (!this.eof() && this.pos + 4 < this.data.Length)
            {
                UInt32 res = (UInt32)(this.data[this.pos] << 24 | this.data[this.pos + 1] << 16 | this.data[this.pos + 2] << 8 | this.data[this.pos + 3]);
                this.pos += 4;

                return res;
            }
            else
            {
                throw new Exception("End of buffer reached!");
            }
        }

        public String[] readNameList()
        {
            if (!this.eof())
            {
                UInt32 length = this.readUInt32();
                if (length != 0)
                {
                    Byte[] tmpArray = new Byte[length];
                    Array.Copy(this.data, this.pos, tmpArray, 0, length);
                    String tmpString = Encoding.ASCII.GetString(tmpArray);
                    this.pos += (Int32)length;

                    return tmpString.Split(',');
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("End of buffer reached!");
            }
        }

        public Boolean readBoolean()
        {
            if (!this.eof())
            {
                Byte res = this.readByte();

                return (res != 0);
            }
            else
            {
                throw new Exception("End of buffer reached!");
            }
        }
    }
}
