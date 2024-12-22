using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs12

{
    public delegate void MessageDelegate(string message);
    public delegate double ArithmeticOperation(double a, double b);


    class Program
    {
        // Метод для простого виведення тексту
        public static void ShowMessage(string message)
        {
            Console.WriteLine($"Повідомлення: {message}");
        }

        // Метод для виведення тексту у верхньому регістрі
        public static void ShowUppercaseMessage(string message)
        {
            Console.WriteLine($"ВЕЛИКИМИ БУКВАМИ: {message.ToUpper()}");
        }

        // Метод для виведення довжини тексту
        public static void ShowMessageLength(string message)
        {
            Console.WriteLine($"Довжина повідомлення: {message.Length}");
        }
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;

        static bool IsEven(int number) => number % 2 == 0;

        static bool IsOdd(int number) => number % 2 != 0;

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static bool IsFibonacci(int number)
        {
            int a = 0, b = 1, temp;
            while (a <= number)
            {
                if (a == number) return true;
                temp = a;
                a = b;
                b = temp + b;
            }
            return false;
        }



        static void Main()
        {
            MessageDelegate messageDelegate;

            // Тестування різних методів
            Console.WriteLine("Введіть повідомлення:");
            string inputMessage = Console.ReadLine();

            // Призначення методу делегату
            messageDelegate = ShowMessage;
            messageDelegate.Invoke(inputMessage);

            messageDelegate = ShowUppercaseMessage;
            messageDelegate.Invoke(inputMessage);

            messageDelegate = ShowMessageLength;
            messageDelegate.Invoke(inputMessage);

            ArithmeticOperation operation;

            Console.WriteLine("Введіть перше число:");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введіть друге число:");
            double num2 = double.Parse(Console.ReadLine());

            // Додавання
            operation = Add;
            Console.WriteLine($"Додавання: {operation(num1, num2)}");

            // Віднімання
            operation = Subtract;
            Console.WriteLine($"Віднімання: {operation(num1, num2)}");

            // Множення
            operation = Multiply;
            Console.WriteLine($"Множення: {operation(num1, num2)}");

            Predicate<int> predicate;

            Console.WriteLine("Введіть число для перевірки:");
            int num = int.Parse(Console.ReadLine());

            // Перевірка на парність
            predicate = IsEven;
            Console.WriteLine($"Число парне: {predicate(num)}");

            // Перевірка на непарність
            predicate = IsOdd;
            Console.WriteLine($"Число непарне: {predicate(num)}");

            // Перевірка на простоту
            predicate = IsPrime;
            Console.WriteLine($"Число просте: {predicate(num)}");

            // Перевірка на число Фібоначчі
            predicate = IsFibonacci;
            Console.WriteLine($"Число є числом Фібоначчі: {predicate(num)}");
        }
    }
}
