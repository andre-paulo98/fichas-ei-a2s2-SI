﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EI.SI;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Server
{
    /// <summary>
    /// Server
    /// </summary>
    class Server
    {
        public static string SEPARATOR = "...";

        /// <summary>
        /// IMPORTANTE: a cada RECEÇÃO deve seguir-se, obrigatóriamente, um ENVIO de dados
        /// IMPORTANT: each network .Read() must be fallowed by a network .Write()
        /// </summary>
        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint listenEndPoint;
            TcpListener server = null;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;

            try
            {
                Console.WriteLine("SERVER");

                #region Defenitions
                // Binding IP/port
                listenEndPoint = new IPEndPoint(IPAddress.Any, 9999);

                // Client/Server Protocol to SI
                protocol = new ProtocolSI();


                #endregion

                Console.WriteLine(SEPARATOR);

                #region TCP Listner
                // Start TcpListener
                server = new TcpListener(listenEndPoint);
                server.Start();

                // Waits for a client connection (bloqueant wait)
                Console.Write("waiting for a connection... ");
                client = server.AcceptTcpClient();
                netStream = client.GetStream();
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data (Unsecure channel)

                Console.WriteLine("waiting for key");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                byte[] key = protocol.GetData();

                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");

                Console.WriteLine("waiting for iv");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                byte[] iv = protocol.GetData();

                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");

                #endregion

                using(AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {
                    aes.Key = key;
                    aes.IV = iv;

                    Console.WriteLine("waiting for message");
                    netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    byte[] encryptedMessage = protocol.GetData();

                    SymmetricsSI symmetric = new SymmetricsSI(aes);

                    try {
                        //aes.Key = aes.IV;
                        string message = Encoding.UTF8.GetString(symmetric.Decrypt(encryptedMessage));

                        Console.WriteLine($"Recieved message: '{message}'");

                        Console.Write("Sending a ACK... ");
                        msg = protocol.Make(ProtocolSICmdType.ACK);
                        netStream.Write(msg, 0, msg.Length);
                        Console.WriteLine("ok.");
                    } catch (Exception) {
                        Console.Write("Sending a NACK... ");
                        msg = protocol.Make(ProtocolSICmdType.NACK);
                        netStream.Write(msg, 0, msg.Length);
                        Console.WriteLine("ok.");
                        throw;
                    }

                    



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
                if (server != null)
                    server.Stop();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with client was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }
    }
}
