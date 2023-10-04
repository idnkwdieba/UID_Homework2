
// Покупка билетов на сеанс в кинотеатре

using System;
using System.Linq;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] outputArr = null;
            int[][] cinemaHall = null;
            int rows;
            int cols;
            int seatsNum;
            int ctr = 0;

            Console.WriteLine("|Входные данные:");

            // Ввод числа мест в зрительном зале
            outputArr = ReadArray(amount: 2, canBeNull: false);
            rows = outputArr[0];
            cols = outputArr[1];

            // Заполнение матрицы свободных и занятых мест
            cinemaHall = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                cinemaHall[i] = ReadArray(amount: cols, canBeNull: true);
            }

            // Ввод нужного количества свободных мест
            seatsNum = ReadArray(1, false)[0];

            Console.WriteLine("|Выходные данные:");

            // Поиск первого ряда с нужным числом мест
            for (int i = 0; i < rows; i++)
            {
                ctr = 0;
                for (int j = 0; j < cols; j++)
                {
                    ctr = (cinemaHall[i][j] == 0 ? ctr + 1 : 0);
                    if (ctr == seatsNum)
                    {
                        break;
                    }
                }
                if (ctr == seatsNum)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
            if (ctr == 0)
            {
                Console.WriteLine(0);
            }
        }

        static int[] ReadArray(int amount, bool canBeNull)
        {
            int[] array = null;
            string inputStr;

            do
            {
                try
                {
                    inputStr = Console.ReadLine();

                    if (inputStr == null)
                    {
                        // throw new NullReferenceException(); // Не ловится
                        throw new FormatException();
                    }

                    array = inputStr.Split().Select(s => int.Parse(s)).ToArray();

                    if (array.Length != amount)
                    {
                        throw new OverflowException();
                    }
                    foreach (int i in array)
                    {
                        if (i <= 0)
                        {
                            if (i == 0 && canBeNull)
                            {
                                continue;
                            }
                            throw new FormatException();
                        }
                    }
                    break;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Количество значений не равно {amount}. Повторите ввод: ");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Введена пустая строка. Повторите ввод: ");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Введено некорректное значение. Повторите ввод: ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetType().Name}: {ex.Message}. Повторите ввод: ");
                }
            } while (true);

            return array;
        }
    }
}