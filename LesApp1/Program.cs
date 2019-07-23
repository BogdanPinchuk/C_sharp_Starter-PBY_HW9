using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // введення даних
            Console.Write("\tВведіть кількість елементів масиву: ");
            bool error = int.TryParse(Console.ReadLine(), out int N);
            // аналіз чи можна далі продовжувати 
            AnaliseOfInputNumber(error);

            // створення масиву
            int[] mas = new int[N];

            // для створення випадкових чисел
            Random rnd = new Random();

            // заповнення масиву випадвовими значеннями
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(sbyte.MinValue, sbyte.MaxValue);
            }

            // виведення даних на екран
            Console.Write($"\n\tВсі елементи масиву: ");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"\t{mas[i]}");
            }
            Console.WriteLine();

            Console.WriteLine($"\n\tНайбільше значення в масиві: {mas.Max():N0}");
            Console.WriteLine($"\n\tНайменше значення в масиві: {mas.Min():N0}");
            Console.WriteLine($"\n\tСума всіх елементів в масиві: {mas.Sum():N0}");
            Console.WriteLine($"\n\tСереднє арифметичне значення в масиві: {mas.Average():N2}");
            #region додатково, находження медіани з використанням колекцій
            {
                // сортування елементів
                Console.Write($"\n\tВідсортовані елементи масиву: ");
                var temp = mas.OrderBy(t => t).ToArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    Console.Write($"\t{temp[i]}");
                }
                Console.WriteLine();
                Console.WriteLine($"\n\tМедіана в масиві: {temp[N / 2]:N0}");
            }
            #endregion
            #region використання колекцій
            Console.Write($"\n\tВсі непарні числа масиву: ");
            {
                // фільтрація https://metanit.com/sharp/tutorial/15.2.php
                var temp = mas.Where(t => Math.Abs(t % 2) == 1).ToArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    Console.Write($"\t{temp[i]}");
                }
            }
            #endregion
            #region звичайний перебір
            Console.Write($"\n\tВсі непарні числа масиву: ");
            for (int i = 0; i < mas.Length; i++)
            {
                if (Math.Abs(mas[i] % 2) == 1)
                {
                    Console.Write($"\t{mas[i]}");
                }
            }
            #endregion
            
            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Умова коли невірно введені дані
        /// </summary>
        /// <param name="res"></param>
        static void AnaliseOfInputNumber(bool res)
        {
            if (!res)
            {
                Console.WriteLine("\nНевірно введені дані!");
                DoExitOrRepeat();
            }
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
