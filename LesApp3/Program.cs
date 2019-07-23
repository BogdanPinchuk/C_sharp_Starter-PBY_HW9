using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
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

            #region Заповнення даними
            // створення масиву
            int[] array = new int[N];

            // для створення випадкових чисел
            Random rnd = new Random();

            // заповнення масиву випадвовими значеннями
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(sbyte.MinValue, sbyte.MaxValue);
            }

            // виведення даних на екран
            Console.Write($"\n\tВсі елементи масиву: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"\t{array[i]}");
            }
            Console.WriteLine();
            #endregion

            // введення додаткових даних
            Console.Write("\n\tВведіть значення елемента який необхідно додати: ");
            error = int.TryParse(Console.ReadLine(), out int value);
            // аналіз чи можна далі продовжувати 
            AnaliseOfInputNumber(error);

            // Додавання елемента:
            int[] mas = AddElemToArray(array, value);

            Console.Write($"\n\tНовий масив: ");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"\t{mas[i]}");
            }

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Додавання нового елементан на початок
        /// </summary>
        /// <param name="array">масив до якого необхідно додати елементн</param>
        /// <param name="value">значення елемента</param>
        /// <returns></returns>
        static int[] AddElemToArray(int[] array, int value)
        {
            // створення новго масиву
            int[] mas = new int[array.Length + 1];

            // додаємо елемнт на початок
            mas[0] = value;

            // додаємо інші дані
            for (int i = 1; i < mas.Length; i++)
            {
                mas[i] = array[i - 1];
            }

            // повертаємо дані
            return mas;
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
