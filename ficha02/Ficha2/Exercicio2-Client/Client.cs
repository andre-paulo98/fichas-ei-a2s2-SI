using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2_Client {
    class Client {
        private const int PORT = 9999;
        static void Main(string[] args) {

            Console.WriteLine(" == CLIENT == ");
            Console.Title = "CLIENT";

            TcpClient client = null;
            NetworkStream stream = null;
            byte[] buffer = new byte[3];
            byte[] bytes = null;
            int bytesRead = 0;

            try {
                client = new TcpClient();
                client.Connect(IPAddress.Loopback, PORT);

                stream = client.GetStream();

                #region Send Integer

                Console.WriteLine("Sending int ...");
                int number = 123;

                bytes = Encoding.UTF8.GetBytes(number.ToString());
                stream.Write(bytes, 0, bytes.Length);
                Console.WriteLine($"Enviado: {number}");

                bytesRead = stream.Read(buffer, 0, buffer.Length);
                var msgFromServer = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"Recebido: {msgFromServer} ({bytesRead} bytes lidos)");

                #endregion

                #region Send String

                Console.WriteLine("Sending string ...");
                string msg = "Estou na aula de SI";

                bytes = Encoding.UTF8.GetBytes(msg.ToString());
                stream.Write(bytes, 0, bytes.Length);
                Console.WriteLine($"Enviado: {msg}");

                bytesRead = stream.Read(buffer, 0, buffer.Length);
                msgFromServer = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"Recebido: {msgFromServer} ({bytesRead} bytes lidos)");

                #endregion


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
