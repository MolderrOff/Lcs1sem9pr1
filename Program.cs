using System;
/*Чат-приложение */
namespace Lcs1sem9pr1
{
    internal class Program
    {
        //public void Client() //1-я версия проверка печати
        //{                    //1-я версия проверка печати

        //}                    //1-я версия проверка печати
        static void Main(string[] args)
        {
            ////Message some = new Message() { Name = "Ivan", Stime = DateTime.Now, Text = "something" }; //сериализуем
            //string str1 = some.ToJson();
            ////Console.WriteLine(some.ToJson());
            //Console.WriteLine(str1);
            //var some2 = Message.FromJson(str1);//Десериализуем
            //Console.WriteLine(some2.Name);
            //Chat chat = new Chat();
            if (args.Length == 0)
            {
                Chat.Server(); 
            }
            else
            {
                Chat.Client(args[0]);
            }
        }
    }
}
