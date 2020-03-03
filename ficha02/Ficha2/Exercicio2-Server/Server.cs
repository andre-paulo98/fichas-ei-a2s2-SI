using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2_Server {
    class Server {
        private const int PORT = 9999;
        static void Main(string[] args) {

            Console.WriteLine(" == SERVER == ");
            Console.Title = "SERVER";

            TcpListener listener = null;
            TcpClient client = null;
            NetworkStream stream = null;

            byte[] ack = Encoding.UTF8.GetBytes("ACK");
            byte[] buffer = new byte[1024];
            int bytesRead;

            try {

                listener = new TcpListener(IPAddress.Any, PORT);
                listener.Start();

                client = listener.AcceptTcpClient();
                stream = client.GetStream();

                #region Recieve Int

                Console.WriteLine("Waiting for clients message..");
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                Console.WriteLine($"Recebido: {Encoding.UTF8.GetString(buffer, 0, bytesRead)}");


                stream.Write(ack, 0, ack.Length);
                Console.WriteLine("ACK enviado.");

                #endregion

                #region Recieve String

                Console.WriteLine("Waiting for clients message..");
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                Console.WriteLine($"Recebido: {Encoding.UTF8.GetString(buffer, 0, bytesRead)}");


                stream.Write(ack, 0, ack.Length);
                Console.WriteLine("ACK enviado.");

                #endregion

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
