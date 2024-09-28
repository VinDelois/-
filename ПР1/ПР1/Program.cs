using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m, n;

            // Ввод количества строк БИМ БИМ БИМ
            Console.Write("Введите количество строчек (m): ");
            while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
            {
                Console.WriteLine("КУДА?! Я запрещаю вводить отрицательные значения (букв это тоже касается).");
            }

            // Ввод количества столбцов БАМ БАМ БАМ4
            Console.Write("Введите количество столбиков (n): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("КУДА?! Я запрещаю вводить отрицательные значения (букв это тоже касается).");
            }

            double[,] matrix = new double[m, n];

            // Ввод элементов матрицы ТЫК ТЫК ТЫК
            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    while (true)
                    {
                        Console.Write($"Элемент [{i + 1}, {j + 1}]: ");
                        if (double.TryParse(Console.ReadLine(), out double value))
                        {
                            matrix[i, j] = value;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("КУДА?! Я запрещаю вводить НЕ вещественые значения.");
                        }
                    }
                }
            }

            double[] b = new double[m + n + m + n]; // Длина вектора B

            // №1 Произведение элементов каждой строки
            for (int i = 0; i < m; i++)
            {
                double product = 1.0;
                for (int j = 0; j < n; j++)
                {
                    product *= matrix[i, j];
                }
                b[i] = product;
            }

            // №2 Среднее арифметическое каждого столбца
            for (int j = 0; j < n; j++)
            {
                double sum = 0.0;
                for (int i = 0; i < m; i++)
                {
                    sum += matrix[i, j];
                }
                b[m + j] = sum / m;
            }

            // №3 Разность наибольшего и наименьшего элемента каждой строки
            for (int i = 0; i < m; i++)
            {
                double max = double.MinValue;
                double min = double.MaxValue;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > max) max = matrix[i, j];
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
                b[m + n + i] = max - min;
            }

            // №4 Первые отрицательные элементы в каждом столбце
            for (int j = 0; j < n; j++)
            {
                double firstNegative = double.NaN; // значение, при отсутствии отрицательных
                for (int i = 0; i < m; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        firstNegative = matrix[i, j];
                        break;
                    }
                }
                b[m + n + m + j] = firstNegative;
            }

            // Вывод результата ЛОЛ
            Console.WriteLine($"Вектор b: [{string.Join(", ", b)}]");
            Console.ReadKey();

        }
    }
}
