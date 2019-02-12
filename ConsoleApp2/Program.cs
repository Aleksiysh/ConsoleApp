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
            var sx = new double[,] {    {1,  4,  6,  4,  1},
                                        {2,  8,  12, 8,  2},
                                        {0,  0,  0,  0,  0},
                                        {2,  8,  12, 8,  2},
                                        {1,  4,  6  ,4,  1}
                    };
            var sx1 = new double[,] {    { -1, -2, -1 },
                                        {  0,  0,  0 },
                                        {  1,  2,  1 }
                                    };
            var g = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 }, { 13, 14, 15 } };
            //PrintArray(xy);
            //xy = GetTranponMatrix(xy);
            //PrintArray(xy);
            //var g1 = SobelFilterTask.CreatExpandArr(g);
            //var arr1 = SobelFilter1(g, sx);
            //var arr1 = SobelFilter1(new double[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }, new double[,]{ { 2} });



            PrintArray(SobelFilterTask.SobelFilter(g, sx1));




            Console.ReadKey();
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

        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            var lenSx = sx.GetLength(0);
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    // Вместо этого кода должно быть поэлементное умножение матриц sx и полученной из неё sy на окрестность точки (x, y)
                    // Такая операция ещё называется свёрткой (Сonvolution)
                    var gx = 0.0;
                    var gy = 0.0;
                    for (int k = 0; k < lenSx; k++)
                    {
                        for (int l = 0; l < lenSx; l++)
                        {
                            gx += sx[l - (int)(lenSx / 2), k - (int)(lenSx / 2)];
                            gy += sx[k - (int)(lenSx / 2), l - (int)(lenSx / 2)];
                        }
                    }
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                    //var gx =
                    //    -g[x - 1, y - 1] - 2 * g[x, y - 1] - g[x + 1, y - 1]
                    //    + g[x - 1, y + 1] + 2 * g[x, y + 1] + g[x + 1, y + 1];
                    //var gy =
                    //    -g[x - 1, y - 1] - 2 * g[x - 1, y] - g[x - 1, y + 1]
                    //    + g[x + 1, y - 1] + 2 * g[x + 1, y] + g[x + 1, y + 1];
                    //result[x, y] = Math.Sqrt(gx * gx + gy * gy);
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
                    Console.Write("{0:0.###}\t", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }
    }
}
//Error on: Image 3x3
//sx:
//1	2	1	
//0	0	0	
//-1	-2	-1	

//Image pixels:
//1	1	1	
//1	1	0	
//1	0	0	

//Image[0, 1] should be 0, but was 1.4142135623731

//Exception on: Image 6x7
//sx:
//1	4	6	4	1	
//2	8	12	8	2	
//0	0	0	0	0	
//2	8	12	8	2	
//1	4	6	4	1	

//Image pixels:
//0.1	0.3	0.8	0.7	0.4	0.2	0.1	
//0.1	0.9	0.2	0.9	0	0.9	0.9	
//1	0.8	0.5	1	0.6	0.8	1	
//0.1	0.3	0.6	0.8	0.3	0.2	0.9	
//0.7	0.3	0.5	0.8	0.2	0.4	0	
//0	0.3	0.9	1	0.5	1	0.5	

//Index was outside the bounds of the array.