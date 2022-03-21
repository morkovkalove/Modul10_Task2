/*Создайте консольный мини-калькулятор, который будет подсчитывать сумму двух чисел.
 Определите интерфейс для функции сложения числа и реализуйте его.
 Дополнительно: добавьте конструкцию Try/Catch/Finally для проверки корректности введённого значения. */


/*
Реализуйте механизм внедрения зависимостей: добавьте в мини-калькулятор логгер, используя материал из скринкаста юнита 10.1.
Дополнительно: текст ошибки, выводимый в логгере, окрасьте в красный цвет, а текст события — в синий цвет.
 */

using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();

            try
            {
                Calculate calculate = new Calculate();
                calculate.GetValues(logger);
            }
            catch (FormatException)
            {
                Logger.Error("Неверный формат.");
                Program.Main(args);
            }
            catch (DivideByZeroException)
            {
                ILogger.Error("На 0 делить нельзя...");
                Program.Main(args);
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так ..");
                Program.Main(args);
            }

        }
    }

    public interface ISum
    {
        // double GetValues(double x, double y);
        void GetValues(ILogger logger);

    }
    
    public interface ILogger
    {
        void Event(string message);
        static void Error(string message)
        {     
        }
    }


    public class Logger : ILogger
    {
        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    


    class Calculate : ISum
    {
        public void GetValues(ILogger logger)
        {
            Console.WriteLine("Задайте число : ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Окей, что делаем?\n\t+ - 1\n\t- - 2\n\t* - 3\n\t/ - 4");

            switch (Console.ReadLine())
            {
                case "1":
                    Arifmetic.Plus(logger, x);
                    break;
                case "2":
                    Arifmetic.Minus(logger, x);
                    break;
                case "3":
                    Arifmetic.Multipli(logger, x);
                    break;
                case "4":
                    Arifmetic.Division(logger, x);
                    break;
            }
        }
    }

    public class Arifmetic
    {
        public void Plus(Logger logger, double x)
        {
            Console.WriteLine("Введите слагаемое:");
            double b = Convert.ToDouble(Console.ReadLine());
            logger.Event("Подождите 5 секунд...считаем");
            System.Threading.Thread.Sleep(5000);
            double c = Math.Round(x + b, 3);
            logger.Event("Ваш результат:");
            Console.WriteLine($"{x} + {b} = {c}");
        }

        public void Minus(Logger logger, double x)
        {
            Console.WriteLine("Введите слагаемое:");
            double b = Convert.ToDouble(Console.ReadLine());
            logger.Event("Подождите 5 секунд...считаем");
            System.Threading.Thread.Sleep(5000);
            double c = Math.Round(x - b, 3);
            logger.Event("Ваш результат:");
            Console.WriteLine($"{x} - {b} = {c}");
        }
        
        public void Multipli(Logger logger, double x)
        {
            Console.WriteLine("Введите слагаемое:");
            double b = Convert.ToDouble(Console.ReadLine());
            logger.Event("Подождите 5 секунд...считаем");
            System.Threading.Thread.Sleep(5000);
            double c = Math.Round(x * b, 3);
            logger.Event("Ваш результат:");
            Console.WriteLine($"{x} * {b} = {c}");
        }
        
        public void Division(Logger logger, double x)
        {
            Console.WriteLine("Введите слагаемое:");
            double b = Convert.ToDouble(Console.ReadLine());
            if (b == 0)
                throw new DivideByZeroException();
            logger.Event("Подождите 5 секунд...считаем");
            System.Threading.Thread.Sleep(5000);
            double c = Math.Round(x / b, 3);
            logger.Event("Ваш результат:");
            Console.WriteLine($"{x} / {b} = {c}");
        }

        public static void Plus(ILogger logger, int i)
        {
            throw new NotImplementedException();
        }

        public static void Minus(ILogger logger, int i)
        {
            throw new NotImplementedException();
        }
        
        public static void Multipli(ILogger logger, int i)
        {
            throw new NotImplementedException();
        }
        
        public static void Division(ILogger logger, int i)
        {
            throw new NotImplementedException();
        }
    }
    

}