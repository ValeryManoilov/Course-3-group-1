using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace WebSocketApp_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string username = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(username) || username == "server")
            {
                Console.Write("Некорректно введено имя. Введите имя еще раз: ");
                username = Console.ReadLine();

            }
            using(WebSocket ws = new WebSocket($"ws://127.0.0.1:8716/chat?username={username}"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    Console.WriteLine($"{e.Data}");
                };

                ws.OnClose += (sender, e) =>
                {
                    Console.WriteLine("Соединение закрыто");
                };

                ws.OnError += (sender, e) =>
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                };

                ws.Connect();

                Console.WriteLine("Введите сообщение (или '/exit' для выхода)");

                string message = "";

                while (message != "/exit")
                {
                    message = Console.ReadLine();
                    ws.Send($"[{username}]: {message}");
                }

                ws.Close();
            }
        }
    }
}
