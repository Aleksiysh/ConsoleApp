using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {


        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {

            g = CreatExpandArr(g);
            var sy = GetTranponMatrix(sx);
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            var lenSx = sx.GetLength(0);
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    var gx = 0.0;
                    var gy = 0.0;
                    for (int k = 0; k < lenSx; k++)
                    {
                        for (int l = 0; l < lenSx; l++)
                        {
                            gx += sx[l, k] * g[x + (l - (int)(lenSx / 2)), y + (k - (int)(lenSx / 2))];
                            gy += sy[l, k] * g[x + (l - (int)(lenSx / 2)), y + (k - (int)(lenSx / 2))];
                        }
                    }
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            }

            return GetCutArr(result);
        }

        public static double[,] GetCutArr(double[,] arr)
        {
            var result = new double[arr.GetLength(0) - 2, arr.GetLength(1) - 2];

            for (int i = 1; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < arr.GetLength(1) - 1; j++)
                {
                    result[i - 1, j - 1] = arr[i, j];
                }
            }
            return result;
        }

        public static double[,] CreatExpandArr(double[,] arr)
        {
            var result = new double[arr.GetLength(0) + 2, arr.GetLength(1) + 2];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result[i + 1, j + 1] = arr[i, j];
                }
            }

            var x = result.GetLength(1);
            var y = result.GetLength(0);
            for (int i = 0; i < x - 1; i++)
            {
                result[0, i] = result[1, i];
                result[y - 1, i] = result[y - 2, i];

            }
            for (int i = 0; i < y; i++)
            {
                result[i, 0] = result[i, 1];
                result[i, x - 1] = result[i, x - 2];
            }
            return result;
        }

        static double[,] GetTranponMatrix(double[,] array)
        {
            var result = new double[array.GetLength(1), array.GetLength(0)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    result[i, j] = array[j, i];
                }
            }
            return result;
        }
    }
}
//public static double[,] SobelFilter1(double[,] g, double[,] sx)
//{
//    var width = g.GetLength(0);
//    var height = g.GetLength(1);
//    var result = new double[width, height];
//    for (int x = 1; x < width - 1; x++)
//    {
//        for (int y = 1; y < height - 1; y++)
//        {
//            // Вместо этого кода должно быть поэлементное умножение матриц sx и полученной из неё sy на окрестность точки (x, y)
//            // Такая операция ещё называется свёрткой (Сonvolution)
//            var gx =
//                -g[x - 1, y - 1] - 2 * g[x, y - 1] - g[x + 1, y - 1]
//                + g[x - 1, y + 1] + 2 * g[x, y + 1] + g[x + 1, y + 1];
//            var gy =
//                -g[x - 1, y - 1] - 2 * g[x - 1, y] - g[x - 1, y + 1]
//                + g[x + 1, y - 1] + 2 * g[x + 1, y] + g[x + 1, y + 1];
//            result[x, y] = Math.Sqrt(gx * gx + gy * gy);
//        }
//    }

//    return result;
//}

/* 
Разберитесь, как работает нижеследующий код (называемый фильтрацией Собеля), 
и какое отношение к нему имеют эти матрицы:

     | -1 -2 -1 |           | -1  0  1 |
Sx = |  0  0  0 |      Sy = | -2  0  2 |
     |  1  2  1 |           | -1  0  1 |

[url]https://ru.wikipedia.org/wiki/%D0%9E%D0%BF%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80_%D0%A1%D0%BE%D0%B1%D0%B5%D0%BB%D1%8F[/url]

Попробуйте заменить фильтр Собеля 3x3 на фильтр Собеля 5x5 или другой аналогичный фильтр и сравните результаты. 
Матрицу для фильтра Собеля 5x5 и другие матрицы можно посмотреть в статье SobelScharrGradients5x5.pdf в архиве с проектом.
Там Sx и Sy названы соответственно ОІ и Оі.

Обобщите код применения фильтра так, чтобы можно было передавать ему любые матрицы, любого нечетного размера.
Фильтры Собеля размеров 3 и 5 должны быть частным случаем. 
После такого обобщения менять фильтр Собеля одного размера на другой должно быть легко.
*/
