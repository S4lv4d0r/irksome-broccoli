using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            Conectar();
        }
        public static void Conectar()
        {
            //por donde vamos a escuchar
            IPEndPoint destino = new IPEndPoint(IPAddress.Parse("192.168.1.223"),5555);
            //definimos el socket
            Socket servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            byte[] bufferEscritura = null;
            try
            {
                //asocioamos el socket a la direccion de destino
                servidor.Bind(destino);
                //ponemos el servidor a la escucha
                servidor.Listen(1);
                Console.WriteLine("Escuchando...");
                Socket escuchar = servidor.Accept();
                Console.WriteLine("Conexion con exito");
                bufferEscritura = new byte[255];
                int a = escuchar.Receive(bufferEscritura, 0, bufferEscritura.Length, 0);
                Array.Resize(ref bufferEscritura, a);
                Console.WriteLine("El cliente dice: "+Encoding.Default.GetString(bufferEscritura));
                servidor.Close();
                /*
                 *creamos un nuevo socket en cuanto recibe peticion de conexion, asi 
                 *nuestro servidor queda disponible para seguir escuchando a otros 
                 */
            }
            catch(Exception error)
            {
                Console.WriteLine("Error {0}",error.ToString());
            }
            Console.WriteLine("Pulse para salir");
            Console.ReadLine();
        }
    }
}
