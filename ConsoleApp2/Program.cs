using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Recognizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var sx = new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            var g = new double[,] { { } };
            //PrintArray(xy);
            //xy = GetTranponMatrix(xy);
            //PrintArray(xy);
            PrintArray(sx);
            PrintLine(sx);

            var arr = Recognizer.SobelFilterTask.SobelFilter(sx, sx);

        }
        static void PrintLine(double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine(arr[i, j]);
                }
            }
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

        static void PrintArray(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
