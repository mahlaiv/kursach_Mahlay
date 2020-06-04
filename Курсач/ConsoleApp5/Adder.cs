using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ConsoleApp5
{
    class Adder
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;
        public News AddNews(List<string>au,List<string> t)
        {

            Console.WriteLine("Список авторов :");
            foreach (string avt in au) Console.WriteLine(avt);
            Console.WriteLine("Список тегов :");
            foreach (string ttt in t) Console.WriteLine(ttt);
            Console.WriteLine("Введитя свое имя, как автора");
            string a;
            a = Console.ReadLine();
            int f = 0;
   
            foreach (string ta in au)
            {
                if (ta == a) f = 1;
            }
            if (f == 0)
            {
                Console.WriteLine("Незарегистрированный автор");
                return null;
            }
            string tg;
            f = 0;
            string ttgg="";
            Console.WriteLine("Введите 3 тега новости по очереди");
            for (int i = 0; i < 3; i++)
            {  
                tg = Console.ReadLine();
                foreach (string tt in t)
                {
                    if (tt == tg) f = 1;
                }
                if (f == 0)
                {
                    Console.WriteLine("Незарегистрированный тег");
                    return null;
                }
                ttgg += tg + ",";
                f = 0;
            }
            ttgg = ttgg.Substring(0, ttgg.Length - 1);
            Console.WriteLine("Введите дату новости");
            string date = Console.ReadLine();
            Console.WriteLine("Введите рубрику :");
            string r = Console.ReadLine();
            Console.WriteLine("Введите текст новости");
            string txt = Console.ReadLine();
            string path = Environment.CurrentDirectory + @"\news.txt";
            string text = Environment.NewLine+ txt + '|' + ttgg + '|' + a + '|' + date + '|' + r + '|' + Environment.NewLine;
            File.AppendAllText(path, text);
            Notify?.Invoke("Была добавлена новость");
            return new News(txt, new List<string>(ttgg.Split(new char[] { ',' })), a, Convert.ToDateTime(date), r); 
        }
        public void addAuthor()
        {
            Console.WriteLine("Введите нового автора");
            string a = Console.ReadLine();
            string path = Environment.CurrentDirectory + @"\authors.txt";
            string text = Environment.NewLine + a + Environment.NewLine;
            File.AppendAllText(path, text);
            Notify?.Invoke("Был зарегистрирован автор");
        }
        public void addTag()
        {
            Console.WriteLine("Введите новый тег");
            string a = Console.ReadLine();
            string path = Environment.CurrentDirectory + @"\tags.txt";
            string text = Environment.NewLine + a + Environment.NewLine;
            File.AppendAllText(path, text);
            Notify?.Invoke("Был зарегистрирован новый тег");
        }
    }
}
