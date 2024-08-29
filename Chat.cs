using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lcs1sem9pr1
{
    internal class Chat
    { 
        //private UdpClient ucl;
        //public Chat( string ip, int port)
        //{
        //   this. ucl = new UdpClient();
        //    ucl.Connect(ip, port);
        //}
        public static void Server()
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 0);
            UdpClient ucl = new UdpClient(12345); //инициализируем клиент
            Console.WriteLine("Сервер ожидает сообщения от клиента");

            while (true)
            {

                try
                {
                    byte[] buffer = ucl.Receive(ref localEP);
                    string str1 = Encoding.UTF8.GetString(buffer);


                    Message? somemessage = Message.FromJson(str1);


                    if (somemessage != null)
                    {
                        Console.WriteLine(somemessage.ToString());

                        string numberMessage = somemessage.ToString().Substring(0, 3);

                        //Console.WriteLine(numberMessage);
                        string mesOtv = numberMessage + " СООБЩЕНИЕ ПОЛУЧЕНО" ;


                        Message newmessage = new Message("server", mesOtv); //1+3 стр добавлено для задания ответа сервера
                        string js = newmessage.ToJson();//
                        byte[] bytes = Encoding.UTF8.GetBytes(js);//
                        ucl.Send(bytes, bytes.Length, localEP);//
                    }
                    else
                    {
                        Console.WriteLine("Некорректное сообщение");
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }

        }

        public static void Client(string nik) 
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            UdpClient ucl = new UdpClient();
            //Console.WriteLine("Укажите имя"); //1-я версия проверка печати
            //string nik = Console.ReadLine(); //1-я версия проверка печати

            int numberOfMessage = 1;
            while (true)
            {

                Console.WriteLine("Введите сообщение");
                Console.Write(numberOfMessage);
                Console.Write(" ");
                string text = Console.ReadLine();

                text = $"{numberOfMessage}   " + " " + text;
                numberOfMessage++;
                if (String.IsNullOrEmpty(text))
                {
                    break;
                }
                Message newmessage = new Message(nik, text);
                string js = newmessage.ToJson();
                byte[] bytes = Encoding.UTF8.GetBytes(js);
                ucl.Send(bytes, bytes.Length, localEP); 

                byte[] buffer = ucl.Receive(ref localEP);//1+3 стр добавлено для задания ответа сервера
                string str1 = Encoding.UTF8.GetString(buffer);//
                Message? somemessage = Message.FromJson(str1);//
                Console.WriteLine(somemessage);//


            }
        }
    }
}
