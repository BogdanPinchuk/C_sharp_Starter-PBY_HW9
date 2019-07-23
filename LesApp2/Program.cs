using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
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
            #endregion

            #region Ручне інвертування
            // Інвертування
            {
                var mas2 = MyReverse(mas);

                // виведення даних
                Console.Write($"\n\tВсі елементи інвертованого масиву: ");
                for (int i = 0; i < mas2.Length; i++)
                {
                    Console.Write($"\t{mas2[i]}");
                }
            }
            Console.WriteLine();
            #endregion

            #region Автоматичне інвертування
#if false
            {
                var mas2 = mas.Reverse().ToArray();

                Console.Write($"\n\tВсі елементи інвертованого масиву через колекції: ");
                for (int i = 0; i < mas2.Length; i++)
                {
                    Console.Write($"\t{mas2[i]}");
                }
            }
#endif
            #endregion

            // введення додаткових даних
            Console.Write("\n\tВведіть індекс початку копіювання: ");
            error = int.TryParse(Console.ReadLine(), out int index);
            // аналіз чи можна далі продовжувати 
            AnaliseOfInputNumber(error);

            Console.Write("\n\tВведіть кількість елементів які треба спопіювати: ");
            error = int.TryParse(Console.ReadLine(), out int count);
            // аналіз чи можна далі продовжувати 
            AnaliseOfInputNumber(error);

            // Перевірка на <0 реалізована в методі SubArray / SubArray2

            // створення масиву в який треба скопіювати необхідні дані масиву
#if false
            int[] masCut = SubArray2(mas, index, count);
            int[] masCut = SubArray<int>(mas, index, count);    // через Generic типи
#endif

            int[] masCut = SubArray(mas, index, count);

            // виведення даних
            if (masCut != null)
            {
                Console.Write($"\n\tСкопійовані  елементи масиву: ");
                for (int i = 0; i < masCut.Length; i++)
                {
                    Console.Write($"\t{masCut[i]}");
                }
            }

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод копіює частину даних із масиву (власний варіант)
        /// </summary>
        /// <param name="array">масив</param>
        /// <param name="index">початковий індекс для копіювання</param>
        /// <param name="count">кількість елементів які необхідно скопіювати</param>
        /// <returns></returns>
        static int[] SubArray2(int[] array, int index, int count)
        {
            // робимо перевірки
#region перевірка щоб програма не перестала працювати (не крашнулась)
            if (index >= array.Length || index < 0)           // вихід за межі
            {
                Console.WriteLine("\nПомилка 1. Введений індекс знаходиться поза межами масива.");
                Console.WriteLine("Або невірно введені дані.");
                return default;
            }

            if (count > array.Length - index || count <= 0)   // вихід за межі
            {
                Console.WriteLine("\nПомилка 2. Введена кількість елементів для копіювання перевищує реальний розмір.");
                Console.WriteLine("Або невірно введені дані.");
                return default;
            }
#endregion

            // створення масиву
            int[] mas = new int[count];

            // копіювання даних
            for (int i = index; i < index + count; i++)
            {
                mas[i - index] = array[i];
            }

            return mas;
        }

        /// <summary>
        /// Метод пробує копіювати частину даних із масиву
        /// </summary>
        /// <param name="array">масив</param>
        /// <param name="index">початковий індекс для копіювання</param>
        /// <param name="count">кількість елементів які необхідно скопіювати</param>
        /// <returns></returns>
        static int[] SubArray(int[] array, int index, int count)
        {
            // робимо перевірки
#region перевірка щоб програма не перестала працювати (не крашнулась)
            if (index >= array.Length || index < 0)           // вихід за межі
            {
                Console.WriteLine("\nПомилка 1. Введений індекс знаходиться поза межами масива.");
                Console.WriteLine("Або невірно введені дані.");
                return default;
            }

            if (count <= 0)   // вихід за межі
            {
                Console.WriteLine("\nПомилка 2. Введена кількість елементів для копіювання перевищує реальний розмір.");
                Console.WriteLine("Або невірно введені дані.");
                return default;
            }


            // створення масиву
            int[] mas = new int[count];

            // перевірка виходу за межі
            if (count > array.Length - index)
            {
                // копіювання даних
                for (int i = index; i < index + count; i++)
                {
                    if (i < array.Length)
                    {
                        mas[i - index] = array[i];
                    }
                    else
                    {
                        mas[i - index] = 1;
                    }
                }
            }
            else
            {
                // копіювання даних
                for (int i = index; i < index + count; i++)
                {
                    mas[i - index] = array[i];
                }
            }

#endregion

            return mas;
        }

        /// <summary>
        /// Узагальнені типи
        /// </summary>
        /// <typeparam name="T">будь який тип явий в самиві</typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        static T[] SubArray<T>(T[] array, int index, int count)
        {
            // робимо перевірки
            #region перевірка щоб програма не перестала працювати (не крашнулась)
            if (index >= array.Length || index < 0)           // вихід за межі
            {
                Console.WriteLine("\nПомилка 1. Введений індекс знаходиться поза межами масива.");
                Console.WriteLine("Або невірно введені дані.");
                return default;
            }

            if (count > array.Length - index || count <= 0)   // вихід за межі
            {
                Console.WriteLine("\nПомилка 2. Введена кількість елементів для копіювання перевищує реальний розмір.");
                Console.WriteLine("Або невірно введені дані.");
                return default;
            }
            #endregion

            // створення масиву
            T[] mas = new T[count];

            // копіювання даних
            for (int i = index; i < index + count; i++)
            {
                mas[i - index] = array[i];
            }

            return mas;
        }

        /// <summary>
        /// Інвертування (зміна порядку  елементів)
        /// </summary>
        /// <param name="array">масив цілих чисел</param>
        /// <returns></returns>
        static int[] MyReverse(int[] array)
        {
            // створення масиву в який записуватимуться значення в іншому порядку
            int[] mas = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                mas[array.Length - 1 - i] = array[i];
            }

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
