using System;

namespace _2._Exer_02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleData = Console.ReadLine().Split(", ");
            Article article = new Article()
            {
                Title = articleData[0],
                Content = articleData[1],
                Author = articleData[2]
            };

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                switch (command[0])
                {
                    case "Edit":
                        article.Edit(command[1]);
                        break;

                    case "ChangeAuthor":
                        article.ChangeAuthor(command[1]);
                        break;

                    case "Rename":
                        article.Rename(command[1]);
                        break;
                }
            }

            Console.WriteLine(article);


        }

        class Article
        {
            // Constructor
            public Article()
            {

            }

            //Properties
            public string Title { get; set; }

            public string Content { get; set; }

            public string Author { get; set; }

            // Methods
            public void Edit(string content)
            {
                this.Content = content;
            }

            public void ChangeAuthor(string author)
            {
                this.Author = author;
            }

            public void Rename(string title)
            {
                this.Title = title;
            }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }

        }

    }
}
