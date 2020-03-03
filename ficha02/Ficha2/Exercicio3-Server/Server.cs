using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using EI.SI;

namespace Exercicio3_Server {
    class Server {
        private const int PORT = 9999;
        static void Main(string[] args) {

            Console.WriteLine(" == SERVER == ");
            Console.Title = "SERVER";

            TcpListener listener = null;
            TcpClient client = null;
            NetworkStream stream = null;
            ProtocolSI protocol = null;
            byte[] packet = null;

            int bytesRead;

            try {

                protocol = new ProtocolSI();

                listener = new TcpListener(IPAddress.Any, PORT);
                listener.Start();

                client = listener.AcceptTcpClient();
                stream = client.GetStream();

                ProtocolSICmdType cmd;

                do {

                    Console.WriteLine("Waiting for client..");
                    stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                    cmd = protocol.GetCmdType();

                    switch (cmd) {
                        case ProtocolSICmdType.NORMAL:
                            Console.WriteLine($"Recebido: {protocol.GetIntFromData()}");
                            break;
                        case ProtocolSICmdType.DATA:
                            Console.WriteLine($"Recebido: {protocol.GetStringFromData()}");
                            break;
                        case ProtocolSICmdType.EOT:
                            Console.WriteLine("Recebido: EOT");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                    packet = protocol.Make(ProtocolSICmdType.ACK);
                    // enviar o ACK
                    stream.Write(packet, 0, packet.Length);
                    Console.WriteLine("ack enviado");

                } while (cmd != ProtocolSICmdType.EOT);
                Console.WriteLine("Comunicação Terminada. <tecla para terminar>");

            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            } finally {
                if (client != null)
                    client.Dispose();
                if (stream != null)
                    stream.Dispose();
                if (listener != null)
                    listener.Stop();
            }


            Console.ReadKey();
        }
    }
}
