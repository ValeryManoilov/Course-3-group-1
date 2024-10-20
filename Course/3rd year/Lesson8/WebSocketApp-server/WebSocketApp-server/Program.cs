using System;
using System.Collections.Generic;
using System.Linq;


using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using WebSocketSharp;


namespace WebSocketApp_server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer wssv = new WebSocketServer("ws://127.0.0.1:8716");

            wssv.AddWebSocketService<ChatController>("/chat");

            wssv.Start();
            Console.WriteLine("Запуск сервера");
            using (WebSocket ws = new WebSocket($"ws://127.0.0.1:8716/chat?username=server"))
            {
                ws.Connect();

                string message = Console.ReadLine();
                while (message != "/stop")
                {
                    message = Console.ReadLine();
                    ws.Send(message);
                }
                ws.Close();
            }
            wssv.Stop();
        }
    }
}
