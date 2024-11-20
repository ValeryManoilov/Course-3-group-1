using SQLitePCL;

namespace Practice18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQLitePCL.Batteries.Init();

            string connectionString = "Data Source=data.db";

            var Table = new ContactRepository(connectionString);

            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Выберите функцию:");
                Console.WriteLine("1) Посмотреть все контакты");
                Console.WriteLine("2) Посмотреть контакт по имени");
                Console.WriteLine("3) Добавить контакт");
                Console.WriteLine("4) Удалить контакт по имени");
                Console.WriteLine("5) Выход");

                string ans = Console.ReadLine();

                switch (ans)
                {
                    case ("1"):
                        Console.WriteLine("---------------------------------");

                        Table.GetAllContacts();

                        Console.WriteLine("---------------------------------");
                        break;

                    case ("2"):
                        Console.WriteLine("---------------------------------");

                        Console.WriteLine("Введите имя");

                        string contactName = Console.ReadLine();

                        var needContact = Table.GetContactByName(contactName);

                        if (!needContact)
                        {
                            Console.WriteLine("Такого контакта не найдено");
                        }

                        Console.WriteLine("---------------------------------");
                        break;

                    case ("3"):
                        Console.WriteLine("---------------------------------");

                        Console.WriteLine("Введите имя");
                        string name = Console.ReadLine();

                        Console.WriteLine("Введите почту");
                        string email = Console.ReadLine();

                        Console.WriteLine("Введите номер телефона");
                        string phone = Console.ReadLine();

                        Table.AddContact(name, email, phone);

                        Console.WriteLine("Контакт добавлен");

                        Console.WriteLine("---------------------------------");
                        break;

                    case ("4"):
                        Console.WriteLine("---------------------------------");

                        Console.WriteLine("Введите имя:");

                        string contactDelName = Console.ReadLine();

                        var deletingContact = Table.GetContactByName(contactDelName);

                        if (!deletingContact)
                        {
                            Console.WriteLine("Такого контакта не найдено");
                        }
                        else
                        {
                            Table.DeleteContact(contactDelName);
                        }

                        Console.WriteLine("---------------------------------");
                        break;

                    case ("5"):
                        Console.WriteLine("Спасибо, что пользуетесь нашим приложением!");
                        flag = false;
                        break;

                    default:
                        break;
                    }
                }
        }
    }
}
