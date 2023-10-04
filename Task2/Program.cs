
// Программа, меняющая местами первую и вторую половины массива

using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 0; // длина массива
            int curEl = 0; // элемент массива
            int[] array = null; // обрабатываемый массив

            // Считывание пользовательского ввода (длина массива)
            do
            {
                try
                {
                    Console.Write("Введите размер массива: ");
                    size = int.Parse(Console.ReadLine());
                    if (size <= 0)
                    {
                        throw new OverflowException();
                    }
                    break;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введена пустая строка. Повторите ввод");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введенное значение не является целым числом. Повторите ввод");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Недопустимое числовое значение. Повторите ввод");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetType().Name}: {ex.Message} Повторите ввод");
                }
            } while (true);

            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = new Random().Next(0, 10);
            }

            Console.Write($"{"Исходный массив: ",20}");
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            // обмен значениями элементов в первой и второй половинах массива
            for (int i = 0; i < size / 2; i++)
            {
                curEl = array[i];
                array[i] = array[size / 2 + i];
                array[size / 2 + i] = curEl;
            }
            // Если длина массива - нечетное число
            if (size % 2 != 0)
            {
                curEl = array[size - 1];
                for (int i = 1; i <= size / 2; i++)
                {
                    array[size - i] = array[size - i - 1];
                }
                array[size / 2] = curEl;
            }

            Console.Write($"{"Новый массив: ",20}");
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}