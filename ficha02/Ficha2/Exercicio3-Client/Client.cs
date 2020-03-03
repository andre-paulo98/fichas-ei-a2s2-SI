using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using EI.SI;

namespace Exercicio3_Client {
    class Client {
        private const int PORT = 9999;
        static void Main(string[] args) {

            Console.WriteLine(" == CLIENT == ");
            Console.Title = "CLIENT";

            TcpClient client = null;
            NetworkStream stream = null;
            ProtocolSI protocol = null;

            byte[] packet = null;
            string temp = "";

            int bytesRead;

            try {

                protocol = new ProtocolSI();

                client = new TcpClient();
                client.Connect(IPAddress.Loopback, PORT);

                stream = client.GetStream();

                ProtocolSICmdType cmd = ProtocolSICmdType.NORMAL;
                do {

                    Console.WriteLine("\n\nOpções:");
                    Console.WriteLine("\t1) Send INT");
                    Console.WriteLine("\t2) Send STRING");
                    Console.WriteLine("\t9) END");
                    Console.Write("\t\tOpção: ");

                    switch (Console.ReadKey().Key) {
                        case ConsoleKey.D1: // enviar int
                            packet = protocol.Make(ProtocolSICmdType.NORMAL, 1234);
                            temp = "int";
                            break;
                        case ConsoleKey.D2: // enviar string
                            packet = protocol.Make(ProtocolSICmdType.DATA, "Estou na aula de SI");
                            temp = "string";
                            break;
                        case ConsoleKey.D9: // EOT
                            cmd = ProtocolSICmdType.EOT;
                            packet = protocol.Make(ProtocolSICmdType.EOT);
                            temp = "eot";
                            break;
                        default:
                            Console.WriteLine("\nInvalid option.");
                            break;
                    }

                    stream.Write(packet, 0, packet.Length);
                    Console.WriteLine($"Enviado: {temp}");
                    
                    // receber confirmação
                    stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    if(protocol.GetCmdType() == ProtocolSICmdType.ACK) {
                        Console.WriteLine("Confirmação recebida (ACK).");
                    } else {
                        Console.WriteLine("Confirmação incorreta");
                    }
                    

                } while (cmd != ProtocolSICmdType.EOT);

                Console.WriteLine("Comunicação Terminada. <tecla para terminar>");


            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            } finally {
                if (client != null)
                    client.Dispose();
                if (stream != null)
                    stream.Dispose();
            }


            Console.ReadKey();

        }
    }
}
