using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace EI.SI
{
    /// <summary>
    /// Client
    /// Symmetrics (Encryption)
    /// </summary>
    class ClientWithProtocolSI
    {
        public static string SEPARATOR = "...";

        /// <summary>
        /// IMPORTANTE: a cada RECEÇÃO deve seguir-se, obrigatóriamente, um ENVIO de dados
        /// IMPORTANT: each network .Read must be fallowed by a network .Write
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint serverEndPoint;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;
            AesCryptoServiceProvider aes = null;
            SymmetricsSI symmetricsSI = null;
            RSACryptoServiceProvider rsaClient = null;
            RSACryptoServiceProvider rsaServer = null;

            try
            {
                Console.WriteLine("CLIENT");

                #region Defenitions
                // algortimos assimétricos
                rsaClient = new RSACryptoServiceProvider();
                rsaServer = new RSACryptoServiceProvider();

                // algoritmos simétrico a usar...
                aes = new AesCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(aes);


                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                // Defenitions for TcpClient: IP:port (127.0.0.1:13000)
                serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);
                #endregion

                Console.WriteLine(SEPARATOR);

                #region TCP Connection
                // Connects to Server ...
                Console.Write("Connecting to server... ");
                client = new TcpClient();
                client.Connect(serverEndPoint);
                netStream = client.GetStream();
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Public Keys
                // Send public key...
                Console.Write("Sending public key... ");
                msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaClient.ToXmlString(false));
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");

                // Receive server public key
                Console.Write("waiting for server public key...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                rsaServer.FromXmlString(protocol.GetStringFromData());
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Secret Key
                // Send key...
                Console.Write("Sending  key... ");
                msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, rsaServer.Encrypt(aes.Key, true));
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                Console.WriteLine("   Sent: " + ProtocolSI.ToHexString(aes.Key));

                // Receive ack
                Console.Write("waiting for ACK...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");


                // Send iv...
                Console.Write("Sending  iv... ");
                msg = protocol.Make(ProtocolSICmdType.IV, rsaServer.Encrypt(aes.IV, true));
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                Console.WriteLine("   Sent: " + ProtocolSI.ToHexString(aes.IV));

                // Receive ack
                Console.Write("waiting for ACK...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");

                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data (Secure channel)
                // Send data...
                byte[] clearData = Encoding.UTF8.GetBytes("hello world!!!");
                Console.Write("Sending  data... ");
                byte[] encryptedData = symmetricsSI.Encrypt(clearData);
                msg = protocol.Make(ProtocolSICmdType.DATA, encryptedData);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                Console.WriteLine("   Data: {0} = {1}", ProtocolSI.ToString(clearData), ProtocolSI.ToHexString(clearData));
                Console.WriteLine("   Encrypted: {0}", ProtocolSI.ToHexString(encryptedData));

                // Receive answer from server
                Console.Write("waiting for ACK...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");
                #endregion



                #region Send Digital signature
                Console.Write("Sending digital signature... ");
                msg = protocol.Make(ProtocolSICmdType.DIGITAL_SIGNATURE, rsaClient.SignData(encryptedData, new SHA256CryptoServiceProvider()));
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("OK");

                Console.Write("waiting... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine(protocol.GetCmdType());

                #endregion

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
