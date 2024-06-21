using System;

namespace BookExample
{
    class Title
    {
        public string BookTitle { get; private set; }

        public Title(string title)
        {
            BookTitle = title;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Title: {BookTitle}");
            Console.ResetColor();
        }
    }

    class Author
    {
        public string BookAuthor { get; set; }

        public Author(string author)
        {
            BookAuthor = author;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Author: {BookAuthor}");
            Console.ResetColor();
        }
    }

    class Content
    {
        public string BookContent { get; set; }

        public Content(string content)
        {
            BookContent = content;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Content: {BookContent}");
            Console.ResetColor();
        }
    }

    class Book
    {
        public Title Title { get; }
        public Author Author { get; set; }
        public Content Content { get; set; }

        public Book(string title, string author, string content)
        {
            Title = new Title(title);
            Author = new Author(author);
            Content = new Content(content);
        }

        public void Show()
        {
            Title.Show();
            Author.Show();
            Content.Show();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("The Great Gatsby", "F. Scott Fitzgerald", "A novel set in the Roaring Twenties.");

            book.Show();

            Console.WriteLine("Введіть нового автора:");
            book.Author.BookAuthor = Console.ReadLine();

            Console.WriteLine("Введіть новий зміст:");
            book.Content.BookContent = Console.ReadLine();

            book.Show();
        }
    }
}



/*using System;

namespace Geometry
{
    class Point
    {
        private int x;
        private int y;
        private string name;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public string Name
        {
            get { return name; }
        }

        public Point(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }

    class Figure
    {
        private Point[] points;
        private string name;

        public Figure(Point p1, Point p2, Point p3)
        {
            points = new Point[] { p1, p2, p3 };
            name = $"{p1.Name}-{p2.Name}-{p3.Name}";
        }

        public Figure(Point p1, Point p2, Point p3, Point p4) : this(p1, p2, p3)
        {
            Array.Resize(ref points, 4);
            points[3] = p4;
            name += $"-{p4.Name}";
        }

        public Figure(Point p1, Point p2, Point p3, Point p4, Point p5) : this(p1, p2, p3, p4)
        {
            Array.Resize(ref points, 5);
            points[4] = p5;
            name += $"-{p5.Name}";
        }

        public double LengthSide(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }

        public void PerimeterCalculator()
        {
            double perimeter = 0;
            for (int i = 0; i < points.Length; i++)
            {
                perimeter += LengthSide(points[i], points[(i + 1) % points.Length]);
            }
            Console.WriteLine($"Figure: {name}");
            Console.WriteLine($"Perimeter: {perimeter}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(0, 0, "A");
            Point B = new Point(0, 3, "B");
            Point C = new Point(4, 0, "C");
            Point D = new Point(4, 3, "D");

            Figure triangle = new Figure(A, B, C);
            triangle.PerimeterCalculator();

            Figure rectangle = new Figure(A, B, C, D);
            rectangle.PerimeterCalculator();
        }
    }
}*/

