using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using WebSocketSharp;
using static System.Collections.Specialized.BitVector32;


namespace WebSocketApp_server
{
    internal class ChatController : WebSocketBehavior
    {

        protected override void OnOpen()
        {
            var username = Context.QueryString["username"];
            if (string.IsNullOrEmpty(username))
            {
                Send("Ошибка: имя пользователя не указано.");
                return;
            }
            Console.WriteLine($"Пользователь {username} подключился.");
            Sessions.Broadcast($"Пользователь {username} подключился к чату.");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            var message = e.Data;

            Sessions.Broadcast(message);
            Console.WriteLine($"[{Context.QueryString["username"]}]: {message}");
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine($"Пользователь {Context.QueryString["username"]} отключился.");
            Sessions.Broadcast($"Пользователь {Context.QueryString["username"]} покинул чат.");
        }
    }
}
