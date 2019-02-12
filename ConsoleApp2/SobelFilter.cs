using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {


        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var sy = GetTranponMatrix(sx);
            var width = g.GetLength(0);
            var height = g.GetLength(1);

            var result = new double[width, height];
            if (width == 1)
            {
                result[0, 0] = Math.Sqrt(sx[0, 0] * g[0, 0] * sx[0, 0] * g[0, 0] + sx[0, 0] * g[0, 0] * sx[0, 0] * g[0, 0]);
            }
            var lenSx = sx.GetLength(0);
            for (int x = (int)(lenSx / 2); x < width - (int)(lenSx / 2); x++)
            {
                for (int y = (int)(lenSx / 2); y < height - (int)(lenSx / 2); y++)
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

        
    }
}
