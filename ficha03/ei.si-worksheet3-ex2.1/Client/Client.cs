using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EI.SI;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Client
{
    /// <summary>
    /// Client
    /// </summary>
    class Client
    {

        

        public static string SEPARATOR = "...";

        /// <summary>
        /// IMPORTANTE: a cada RECEÇÃO deve seguir-se, obrigatóriamente, um ENVIO de dados
        /// IMPORTANT: each network .Read() must be fallowed by a network .Write()
        /// </summary>
        static void Main(string[] args)
        {
            byte[] key, iv;
            byte[] msg;
            IPEndPoint serverEndPoint;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;

            try
            {
                Console.WriteLine("CLIENT");

                #region Defenitions
                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                // Defenitions for TcpClient: IP:port (127.0.0.1:9999)
                serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                #endregion

                Console.WriteLine(SEPARATOR);

                #region TCP Connection
                // Connects to Server ...
                Console.Write("Connecting to server... ");
                client = new TcpClient();
                client.Connect(serverEndPoint);
                netStream = client.GetStream();
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data (Unsecure channel)
                
                using(AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {
                    key = aes.Key;
                    iv = aes.IV;
                }

                Console.WriteLine("Sending KEY");
                msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, key);
                netStream.Write(msg, 0, msg.Length);

                Console.WriteLine("WAITING ACK");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                Console.WriteLine("Sending IV");
                msg = protocol.Make(ProtocolSICmdType.IV, iv);
                netStream.Write(msg, 0, msg.Length);


                Console.WriteLine("WAITING ACK");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                #endregion

                Console.Write("Indique a mensagem para enviar: ");
                string messageSend = Console.ReadLine();
                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {
                    aes.Key = key;
                    aes.IV = iv;

                    SymmetricsSI symmetrics = new SymmetricsSI(aes);
                    var send = symmetrics.Encrypt(Encoding.UTF8.GetBytes(messageSend));

                    Console.WriteLine("Sending ENCRYPTED MESSAGE");
                    msg = protocol.Make(ProtocolSICmdType.SYM_CIPHER_DATA, send);
                    netStream.Write(msg, 0, msg.Length);

                    Console.WriteLine("WAITING ACK");
                    netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    Console.WriteLine($"Recieved from server: '{protocol.GetCmdType()}'");
                }
                



            } catch (Exception ex)
            {
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            finally
            {
                // Close connections
                if (netStream != null)
                    netStream.Dispose();
                if (client != null)
                    client.Close();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with server was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }
    }
}
