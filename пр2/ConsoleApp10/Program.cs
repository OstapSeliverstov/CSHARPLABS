/*using System;

class Program
{
    static void Main()
    {
        int lastDigit = 3;
        int intervalEnd = 10 + lastDigit;

        Console.WriteLine("Введіть три цілих числа:");

        int num1 = GetValidInt();
        int num2 = GetValidInt();
        int num3 = GetValidInt();

        bool foundInInterval = false;

        Console.WriteLine($"Числа, які належать інтервалу [1, {intervalEnd}]:");

        if (IsInInterval(num1, 1, intervalEnd))
        {
            Console.WriteLine(num1);
            foundInInterval = true;
        }
        if (IsInInterval(num2, 1, intervalEnd))
        {
            Console.WriteLine(num2);
            foundInInterval = true;
        }
        if (IsInInterval(num3, 1, intervalEnd))
        {
            Console.WriteLine(num3);
            foundInInterval = true;
        }

        if (!foundInInterval)
        {
            Console.WriteLine("Жодне число не належить інтервалу.");
        }
    }

    static int GetValidInt()
    {
        int result;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Неправильний формат. Введіть ціле число:");
            }
        }
    }

    static bool IsInInterval(int number, int start, int end)
    {
        return number >= start && number <= end;
    }
}*/


/*using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть три сторони трикутника:");

        double a = ReadSide("a");
        double b = ReadSide("b");
        double c = ReadSide("c");

        if (IsValidTriangle(a, b, c))
        {
            double perimeter = CalculatePerimeter(a, b, c);
            double area = CalculateArea(a, b, c);
            string triangleType = DetermineTriangleType(a, b, c);

            Console.WriteLine($"Периметр трикутника: {perimeter}");
            Console.WriteLine($"Площа трикутника: {area}");
            Console.WriteLine($"Вид трикутника за сторонами: {triangleType}");
        }
        else
        {
            Console.WriteLine("Трикутник з такими сторонами не існує.");
        }
    }

    static double ReadSide(string sideName)
    {
        double side;
        while (true)
        {
            Console.Write($"{sideName} = ");
            if (double.TryParse(Console.ReadLine(), out side) && side > 0)
            {
                return side;
            }
            else
            {
                Console.WriteLine("Некоректне значення. Введіть додатне число.");
            }
        }
    }

    static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    static double CalculatePerimeter(double a, double b, double c)
    {
        return a + b + c;
    }

    static double CalculateArea(double a, double b, double c)
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    static string DetermineTriangleType(double a, double b, double c)
    {
        if (a == b && b == c)
        {
            return "Рівносторонній";
        }
        else if (a == b || b == c || a == c)
        {
            return "Рівнобедрений";
        }
        else
        {
            return "Різносторонній";
        }
    }
}*/


/*using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int lastDigit = 3;
        int arrayLength = 10 + lastDigit;

        int[] array = new int[arrayLength];

        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100); 
        }

        int minValue = array.Min();
        int maxValue = array.Max();

        Console.WriteLine("Масив:");
        foreach (int value in array)
        {
            Console.Write(value + " ");
        }

        Console.WriteLine("\nМінімальне значення: " + minValue);
        Console.WriteLine("Максимальне значення: " + maxValue);
    }
}*/


using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int lastDigit = 3;
        int arrayLength = 10 + lastDigit;

        int[] arrayX = new int[arrayLength];

        Random random = new Random();
        for (int i = 0; i < arrayX.Length; i++)
        {
            arrayX[i] = random.Next(-50, 51); 
        }

        Console.Write("Введіть число М: ");
        int M;
        while (!int.TryParse(Console.ReadLine(), out M))
        {
            Console.WriteLine("Некоректне значення. Введіть ціле число.");
            Console.Write("Введіть число М: ");
        }

        int[] arrayY = arrayX.Where(x => Math.Abs(x) > M).ToArray();

        Console.WriteLine("Початковий масив X:");
        foreach (int value in arrayX)
        {
            Console.Write(value + " ");
        }

        Console.WriteLine($"\nЧисло М: {M}");

        Console.WriteLine("Отриманий масив Y:");
        foreach (int value in arrayY)
        {
            Console.Write(value + " ");
        }
    }
}




