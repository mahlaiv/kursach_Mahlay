using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class News
    {
        public string Text;
        public List<string> tag = new List<string>();
        public string author;
        public DateTime createdon;
        public string rubrics;
        public News(string t,List<string> ta,string a,DateTime dt,string r ) 
        {
            Text = t;
            author = a;
            createdon = dt;
            rubrics = r;
            foreach (string tags in ta) 
            {
                tag.Add(tags);
            }
        }
        public void Show() 
        {
            Console.WriteLine("Автор: {0}",author);
            Console.WriteLine("Теги:");
            foreach (string s in tag) 
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Дата: {0}",createdon);
            Console.WriteLine("Рубрика : {0}",rubrics);
            Console.WriteLine(Text);
        }
    }
}
