
// Операции над массивами

using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fstArr = null; // первый массив
            int[] sndArr = null; // второй массив
            int[] resArr = null; // вспомогательный массив
            int fstSize; // размер первого массива
            int sndSize; // размер второго массива
            int value;        // вспомогательная целочисленная переменная
            float floatValue; // вспомогательная переменная с плавающей запятой

            // Задание начальных значений
            OutputColorMsg("> Введите длину первого массива: ", ConsoleColor.Yellow);
            fstSize = SetCorrectValue(isSize: true);
            OutputColorMsg("> Введите длину второго массива: ", ConsoleColor.Yellow);
            sndSize = SetCorrectValue(isSize: true);
            OutputColorMsg("> Введите число, на которое будет умножен первый массив: ", ConsoleColor.Yellow);
            value = SetCorrectValue(isSize: false);

            // Инициализация массивов случайными числами
            InitArray(out fstArr, fstSize);
            InitArray(out sndArr, sndSize);

            // Вывод массивов на консоль
            Console.Write($"{"Первый массив:",42} ");
            PrintArr(fstArr);
            Console.Write($"{"Второй массив:",42} ");
            PrintArr(sndArr);

            // Суммирование массивов
            resArr = SummArrays(fstArr, sndArr);
            Console.Write($"{"Сумма массивов:",42} ");
            PrintArr(resArr);

            // Умножение массива на число
            resArr = MultiplyArrByVal(fstArr, value);
            Console.Write($"{"Умножение первого массива на число",38} {value,2}: ");
            PrintArr(resArr);

            // Поиск общих значений массивов
            resArr = SearchArrCommVal(fstArr, sndArr);
            Console.Write($"{"Общие значения первого и второго массивов:",42} ");
            PrintArr(resArr);

            // Сортировка массива по убыванию
            resArr = SortArrDesc(fstArr);
            Console.Write($"{"Сортировка первого массива по убыванию:",42} ");
            PrintArr(resArr);

            // Поиск минимального значения в массиве
            Console.Write($"{"Минимальное значение в первом массиве:",42} ");
            if (SearchArrMinVal(fstArr, out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("-");
            }

            // Поиск максимального значения в массиве
            Console.Write($"{"Максимальное значение в первом массиве:",42} ");
            if (SearchArrMaxVal(fstArr, out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("-");
            }

            // Поиск среднего значения в массиве
            Console.Write($"{"Среднее значение в первом массиве:",42} ");
            if (SearchArrAvgVal(fstArr, out floatValue) != 0)
            {
                Console.WriteLine($"{floatValue:N1}");
            }
            else
            {
                Console.WriteLine("-");
            }
        }

        /// <summary>
        /// Инициализация массива случайными значениями.
        /// </summary>
        /// <param name="array">Инициализируемый массив.</param>
        /// <param name="size">Размер массива.</param>
        static void InitArray(out int[] array, int size)
        {
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = new Random().Next(0, 10);
            }
        }

        /// <summary>
        /// Сложение массивов, имеющих одинаковую длину.
        /// </summary>
        /// <param name="array1">Первый массив.</param>
        /// <param name="array2">Второй массив.</param>
        /// <returns>Сумма массивов array1 и array2;<para />
        /// null, если array является указателем на null.</returns>
        static int[] SummArrays(int[] array1, int[] array2)
        {
            int[] result = null;

            // Если массивы имеют равную длину
            if (array1.Length == array2.Length)
            {
                int length = array1.Length;
                int index = 0;

                result = new int[length];

                while (index < length)
                {
                    result[index] = array1[index] + array2[index];
                    index += 1;
                }
            }
            return result;
        }

        /// <summary>
        /// Умножение массива на целочисленное значение.
        /// </summary>
        /// <param name="array">Исходный массив.</param>
        /// <param name="val">Число, на которое умножается каждый элемент массива.</param>
        /// <returns>Массив array, поэлементно умноженный на число val;<para />
        /// null, если массив array является указателем на null.</returns>
        static int[] MultiplyArrByVal(int[] array, int val)
        {
            int[] result = null;

            if (array != null)
            {
                int length = array.Length;
                result = new int[length];
                int index = 0;

                while (index < length)
                {
                    result[index] = array[index] * val;
                    index += 1;
                }
            }

            return result;
        }

        /// <summary>
        /// Поиск общих значений двух массивов.
        /// </summary>
        /// <param name="array1">Первый массив.</param>
        /// <param name="array2">Второй массив.</param>
        /// <returns>Массив общих значений;<para />
        /// null, если array1 или array2 является указателем на null.</returns>
        static int[] SearchArrCommVal(int[] array1, int[] array2)
        {
            int[] commVals = null;
            int ctr = 0;

            if (array1 != null || array2 != null)
            {
                commVals = new int[array1.Length];

                foreach (int i in array1)
                {
                    //if (array2.Contains(i) && !commVals.Contains(i))
                    if (CheckArrForVal(array2, i) && !CheckArrForVal(commVals, i))
                    {
                        commVals[ctr++] = i;
                    }
                }
                Array.Resize(ref commVals, ctr);
                Array.Sort(commVals);
            }
            return commVals;

        }

        /// <summary>
        /// Вывод массива на консоль.<para />
        /// Если array указывает на null, происходит выход из метода
        /// без печати каких-либо значений.
        /// </summary>
        /// <param name="array">Массив для печати.</param>
        static void PrintArr(int[] array)
        {
            if (array == null)
            {
                Console.WriteLine();
                return;
            }

            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Сортировка массива по убыванию.
        /// </summary>
        /// <param name="array">Массив для сортировки.</param>
        /// <returns>Отсортированный массив;<para />
        /// null, если array является указателем на null.</returns>
        static int[] SortArrDesc(int[] array)
        {
            int[] sortedArr = null;

            if (array != null)
            {
                int length = array.Length;
                sortedArr = new int[length];

                for (int i = 0; i < length; i++)
                {
                    sortedArr[i] = array[i];
                }

                int left = 0;
                int right = length - 1;

                while (left < right)
                {
                    for (int i = left; i < right; i++)
                    {
                        if (sortedArr[i] < sortedArr[i + 1])
                        {
                            SwapArrElems(sortedArr, i, i + 1);
                        }
                    }
                    right -= 1;

                    for (int i = right; i > left; i--)
                    {
                        if (sortedArr[i - 1] < sortedArr[i])
                        {
                            SwapArrElems(sortedArr, i, i - 1);
                        }
                    }
                    left += 1;
                }
            }

            return sortedArr;
        }

        /// <summary>
        /// Поиск минимального значения в массиве.
        /// </summary>
        /// <param name="array">Массив, в котором осуществляется поиск.</param>
        /// <param name="minVal">Минимальное значение в массиве.</param>
        /// <returns>true, если максимальное значение найдено;<para />
        /// false, если максимальное значение найти не удалось.</returns>
        static bool SearchArrMinVal(int[] array, out int minVal)
        {
            minVal = int.MaxValue;

            if (array != null)
            {
                foreach (int i in array)
                {
                    minVal = (i < minVal ? i : minVal);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Поиск максимального значения в массиве.
        /// </summary>
        /// <param name="array">Массив, в котором осуществляется поиск</param>
        /// <param name="maxVal">Максимальное значение в массиве.</param>
        /// <returns>true, если максимальное значение найдено;<para />
        /// false, если максимальное значение найти не удалось.</returns>
        static bool SearchArrMaxVal(int[] array, out int maxVal)
        {
            maxVal = int.MinValue;

            if (array != null)
            {
                foreach (int i in array)
                {
                    maxVal = (i > maxVal ? i : maxVal);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Поиск среднего значения в массиве.
        /// </summary>
        /// <param name="array">Массив, в котором осуществляется поиск.</param>
        /// <param name="avgVal">Среднее значение по массиву.</param>
        /// <returns>true, если среднее значение найдено;<para />
        /// false, если среднее значение найти не удалось.</returns>
        static int SearchArrAvgVal(int[] array, out float avgVal)
        {
            avgVal = 0F;

            if (array != null)
            {
                foreach (int i in array)
                {
                    avgVal += i;
                }
                avgVal /= array.Length;
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Задание корректного числового значения.
        /// </summary>
        /// <param name="isSize">Является ли задаваемое число размером массива.</param>
        /// <returns>Значение, прошедшее все проверки.</returns>
        static int SetCorrectValue(bool isSize)
        {
            int value = 0;
            do
            {
                try
                {
                    value = int.Parse(Console.ReadLine());
                    if (isSize && value <= 0)
                    {
                        throw new OverflowException();
                    }
                    break;
                }
                catch (ArgumentNullException)
                {
                    Console.Write("Введена пустая строка. Повторите ввод: ");
                }
                catch (FormatException)
                {
                    Console.Write("Введенное значение не является целым числом. Повторите ввод: ");
                }
                catch (OverflowException)
                {
                    Console.Write("Недопустимое числовое значение. Повторите ввод: ");
                }
                catch (Exception ex)
                {
                    Console.Write($"{ex.GetType().Name}: {ex.Message} Повторите ввод: ");
                }
            } while (true);

            return value;
        }

        /// <summary>
        /// Вывести на консоль цветную строку.
        /// </summary>
        /// <param name="message">Сообщение для вывода.</param>
        /// <param name="color">Цвет сообщения.</param>
        static void OutputColorMsg(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Проверка, содержит ли массив array элемент val.<para />
        /// (Метод написан, так как ни один онлайн компилятор не распознавал
        /// конструкцию array.Contains(val)).
        /// </summary>
        /// <param name="array">Массив для проверки</param>
        /// <param name="val">Искомое значение</param>
        /// <returns>true, если массив array содержит элемент val;<para />
        /// false, если не содержит или если array указывает на null.</returns>
        static bool CheckArrForVal(int[] array, int val)
        {
            if (array != null)
            {
                foreach (int i in array)
                {
                    if (i == val)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Поменять элементы массива местами.
        /// </summary>
        /// <param name="array">Массив элементов.</param>
        /// <param name="fstIndex">Индекс первого элемента.</param>
        /// <param name="sndIndex">Индекс второго элемента.</param>
        static void SwapArrElems(int[] array, int fstIndex, int sndIndex)
        {
            int tmpVal = array[fstIndex];
            array[fstIndex] = array[sndIndex];
            array[sndIndex] = tmpVal;
        }
    }
}