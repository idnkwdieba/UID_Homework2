
// Умножение матриц

using System;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = 1000; // число строк/столбцов квадратной матрицы
            int[] fstMatrix = null;
            int[] sndMatrix = null;
            int[] resMatrix = null;

            // Инициализация матриц
            InitMatrix(ref fstMatrix, matrixSize);
            InitMatrix(ref sndMatrix, matrixSize);
            resMatrix = new int[matrixSize * matrixSize];

            /*
            // Вывод исходных матриц на консоль
            PrintMatrix(fstMatrix, matrixSize);
            Console.WriteLine();
            PrintMatrix(sndMatrix,matrixSize);
            Console.WriteLine();
            */

            // проход по строкам 1-й матрицы и результирующей матрицы
            for (int i = 0; i < matrixSize; i++)
            {
                // проход по столбцам 2-й матрицы и результирующей матрицы
                for (int j = 0; j < matrixSize; j++)
                {
                    // проход по столбцам 1-й матрицы и строкам 2-й матрицы
                    for (int k = 0; k < matrixSize; k++)
                    {
                        // Элемент матрицы Xij
                        resMatrix[matrixSize * i + j] +=
                            (fstMatrix[matrixSize * i + k] * sndMatrix[matrixSize * k + j]);
                    }
                }
            }

            /*
            // Вывод результата на консоль
            PrintMatrix(resMatrix, matrixSize);
            Console.WriteLine();
            */
        }

        /// <summary>
        /// Инициализация квадратной матрицы случайными значениями.
        /// </summary>
        /// <param name="array">Инициализируемый массив, хранящий матрицу.</param>
        /// <param name="dimSize">Число строк/столбцов квадратной матрицы.</param>
        static void InitMatrix(ref int[] array, int dimSize)
        {
            array = new int[dimSize * dimSize];
            for (int i = 0; i < dimSize * dimSize; i++)
            {
                array[i] = new Random().Next(0, 2);
            }
        }

        /// <summary>
        /// Вывод квадратной матрицы на консоль.
        /// </summary>
        /// <param name="array">Массив, хранящий матрицу.</param>
        /// <param name="dimSize">Число строк/столбцов квадратной матрицы.</param>
        static void PrintMatrix(in int[] array, int dimSize)
        {
            for (int i = 0; i < dimSize; i++)
            {
                for (int j = 0; j < dimSize; j++)
                {
                    Console.Write($"{array[dimSize * i + j],3} ");
                }
                Console.WriteLine();
            }
        }
    }
}