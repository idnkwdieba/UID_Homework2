
// Вставка группы из M элементов в массив из N элементов,
// начиная с позиции K

using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N; // размер исходного массива
            int M; // количество новых элементов
            int K; // позиция в исходном массиве для вставки M значений
            int[] fstArr = null; // исходный массив
            int[] sndArr = null; // вставляемый массив

            Console.WriteLine("| Размер исходного массива:");
            SetArray(out fstArr, out N);

            Console.WriteLine("| Размер вставляемого массива:");
            SetArray(out sndArr, out M);

            Console.WriteLine("| Позиция для вставки (от 0 до N-1):");
            while ((K = GetValue(isIndex: true)) >= N)
            {
                Console.WriteLine("Индекс выходит за пределы массива. Повторите ввод");
            }

            Console.WriteLine("| Полученные данные:");

            Console.Write($"{"Исходный массив:",20} ");
            foreach (int i in fstArr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.Write($"{"Вставляемый массив:",20} ");
            foreach (int i in sndArr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.WriteLine($"{"Позиция для вставки:",20} {K}");

            Array.Resize(ref fstArr, N + M);
            for (int i = K; M + i < fstArr.Length; i++)
            {
                fstArr[M + i] = fstArr[i];
            }
            for (int i = 0; i < M; i++)
            {
                fstArr[K + i] = sndArr[i];
            }

            Console.Write("| Результат вставки: ");
            foreach (int i in fstArr)
            {
                Console.Write($"{i} ");
            }
        }

        // Задание размера массива, заполнение случайными значениями
        static void SetArray(out int[] array, out int size)
        {
            size = GetValue(isIndex: false);
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = new Random().Next(0, 10);
            }
        }

        // Задание корректного числа путём ввода через консоль
        // bool isIndex - является ли задаваемое число позицией K
        static int GetValue(bool isIndex)
        {
            int value = 0;
            do
            {
                try
                {
                    Console.Write("Введите значение: ");
                    value = int.Parse(Console.ReadLine());
                    if (value <= 0)
                    {
                        if (isIndex && value == 0)
                        {
                            break;
                        }
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

            return value;
        }
    }
}