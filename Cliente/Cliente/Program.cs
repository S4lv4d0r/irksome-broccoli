using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

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
            try
            {
                //conectamos: cliente--destino
                cliente.Connect(destino);
                Console.WriteLine("Conectado con exito");
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
