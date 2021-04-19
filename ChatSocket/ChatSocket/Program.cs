using ChatSocket.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket serverSocket = new ServerSocket(puerto);

            if (serverSocket.Iniciar())
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Esperando Cliente...");
                    if(serverSocket.ObtenerCliente())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Cliente Recibido");
                        Console.WriteLine("S: Hola cliente");
                        serverSocket.Escribir("Hola Cliente");
                        Console.WriteLine("Escriba un mensaje");
                        string mensaje = Console.ReadLine().Trim();
                        Console.WriteLine("S:{0}",mensaje);
                        serverSocket.Escribir(mensaje);

                        string respuesta = serverSocket.Leer();
                        Console.WriteLine("C:{0}", respuesta);

                        serverSocket.CerrarConexion();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se puede levantar el servidor, puerto ocupado");
                Console.ReadKey();
            }
        }
    }
}
