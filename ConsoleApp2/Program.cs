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
            var xy = new double[4,3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 },{ 10, 11, 12 } };
            //PrintArray(xy);
            //xy = GetTranponMatrix(xy);
            //PrintArray(xy);
            PrintArray(xy);
            PrintLine(xy);

            var arr = Recognizer.SobelFilterTask.SobelFilter(xy, xy);

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
