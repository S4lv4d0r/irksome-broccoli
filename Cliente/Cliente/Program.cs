using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Conectar();
        }
        public static void Conectar()
        {
            //declaracion de destino=servidor
            IPEndPoint destino = new IPEndPoint(IPAddress.Parse("192.168.1.223"), 5555);
            //declaracion de socket cliente
            Socket cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //TcpClient cliente = new TcpClient();
            try
            {
                //declaramel buffer de escritura
                byte[] bufferEscritura = null;
                //conectamos: cliente--destino
                cliente.Connect(destino);
                Console.WriteLine("Conectado con exito");
                //enviamos mensage
                //Stream str = cliente.GetStream();
                String texto = Console.ReadLine();
                bufferEscritura = Encoding.Default.GetBytes(texto);
                cliente.Send(bufferEscritura,0,bufferEscritura.Length,0);
                //if(str.CanWrite)
                //{
                //    bufferEscritura = Encoding.ASCII.GetBytes();
                //    if(str!=null)
                //    {
                //        //enviamos el sms
                //        str.Write(bufferEscritura,0,bufferEscritura.Length);
                //    }
                //}
                cliente.Close();
                cliente = null;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error {0}", error.ToString());
            }
            Console.WriteLine("Presiona para salir");
            Console.ReadLine();
        }
    }
}
