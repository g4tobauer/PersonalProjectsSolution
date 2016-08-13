using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursividade
{
    class Program
    {
        private static int[,] array;
        static void Main(string[] args)
        {
            int x = 3;
            int y = 3;

            int cont = 0;

            array = new int[x,y];

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    array[i, j] = cont++;
                }

            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            //for (int i = 0; i < x; i++)
            //    for (int j = 0; j < y; j++)
            //    {
            //        //Console.WriteLine(array[i, j]);
            //    }
            //recursividade(x - 1, y - 1, y - 1);


            //for (int i = x - 1; i >= 0; i--)
            //{
                recursividade2(x-1, y - 1);
            //}
            Console.ReadKey();
        }

        static int contador = 0;
        static string recursividade(int x, int y, int size)
        {
            if (x==0 && y==0)
            {
                var result = array[x, y].ToString() + "\n";
                return result;
            }
            else if(x!=0 && y<0)
            {
                return recursividade(x-1, size, size);
            }
            else
            {
                var result = array[x, y].ToString() +  recursividade(x, y - 1, size);
                //Console.WriteLine(result);
                return result;
            }
        }

        static void recursividade2(int x, int y)
        {
            if (x == 0)
            {
                Console.WriteLine(array[x, y].ToString());
            }
            else
            {
                Console.WriteLine(array[x, y].ToString());
                recursividade2(x-1, y);
            }
            recursividade3(x, y - 1);
        }
        static void recursividade3(int x, int y)
        {
            if (y == 0)
            {
                Console.WriteLine(array[x, y].ToString());
            }
            else
            {
                Console.WriteLine(array[x, y].ToString());
                recursividade3(x, y-1);
            }
        }
    }
}
