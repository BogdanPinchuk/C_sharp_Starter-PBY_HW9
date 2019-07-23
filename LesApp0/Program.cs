using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // для створення випадкових чисел
            Random rnd = new Random();

            // кількість елементів в масиві
            int count = 10;

            // створення масиву
            double[] mas = new double[count];

            // заповнення випадковими даними
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.NextDouble();
            }

            // виведення
            Console.WriteLine("\nВиведення в прямому порядку:\n");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"\t{mas[i]:N2}");
            }

            Console.WriteLine("\n\nВиведення в зворотньому порядку:\n");
            for (int i = mas.Length - 1; i >= 0; i--)
            {
                Console.Write($"\t{mas[i]:N2}");
            }

            // повторення
            DoExitOrRepeat();
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
