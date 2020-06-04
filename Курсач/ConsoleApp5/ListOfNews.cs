using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ConsoleApp5
{
    class ListOfNews
    {
        private List<ConsoleApp5.News> news = new List<News>();
        private List<string> authors = new List<string>();
        private List<string> tags = new List<string>();
        public ListOfNews() 
        {
            string line;
            int position = 0;
            int start = 0;
            string path = Environment.CurrentDirectory + @"\news.txt";
            var sentences = new List<String>();
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    do
                    {
                        position = line.IndexOf('|', start);
                        if (position >= 0)
                        {
                            sentences.Add(line.Substring(start, position - start).Trim());
                            start = position + 1;
                        }
                    } while (position > 0);
                    position = 0;
                    start = 0;
                }
                List<int> t = new List<int>();
                for (int i = 0, j = 1; i <= sentences.ToArray().Length - 5; i += 5, j++)
                {
                    news.Add(new News(sentences[i], new List<string>(sentences[i + 1].Split(new char[] { ',' })), sentences[i + 2], Convert.ToDateTime(sentences[i + 3]),sentences[i+4]));
                }
                for (int i = 0; i < news.Count; i++) 
                {
                    news[i].Show();
                }
            }
        }
        public void setAuthors()
        {

            string line;
            string path = Environment.CurrentDirectory + @"\authors.txt";
            if (authors.Capacity == 0)
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        authors.Add(line);
                    }
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if(!authors.Contains(line))authors.Add(line);
                    }
                }
            }
        }
        public void setTags()
        {
            string line;
            string path = Environment.CurrentDirectory + @"\tags.txt";
            if (tags.Capacity == 0)
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        tags.Add(line);
                    }
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!tags.Contains(line)) tags.Add(line);
                    }
                }
            }
        }
        public List<string> getAutors()
        {
            return authors;
        }
        public List<string> getTags()
        {
            return tags;
        }
        public void Show()
        {
            for (int i = 0; i < news.Count; i++)
            {
                news[i].Show();
            }
        }
        public void FindAuthor() 
        {
            Console.WriteLine("Введитe автора новости");
            string a;
            a = Console.ReadLine();
            foreach (News n in news) 
            {
                if (n.author == a) n.Show();
            }
        }
        public void FindTag()
        {
            Console.WriteLine("Введитe тег");
            string tag;
            tag = Console.ReadLine();
            foreach (News n in news)
            {
                foreach (string t in n.tag) 
                {
                    if (t == tag) n.Show();
                }
            }
        }
        public void Add(News n)
        {
            news.Add(n);
        }
        public void FindDate()
        {
            Console.WriteLine("Введитe дату с  новости");
            DateTime d1;
            d1 = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введитe дату по  новости");
            DateTime d2;
            d2 = Convert.ToDateTime(Console.ReadLine());
            foreach (News n in news)
            {
                if (n.createdon >d1 && n.createdon<d2) n.Show();
            }
        }
        public void FindRubrics()
        {
            Console.WriteLine("Введите желаемую рубрику :");
            string r = Console.ReadLine();
            foreach (News n in news)
            {
                if (n.rubrics == r ) n.Show();
            }
        }
    }
}
