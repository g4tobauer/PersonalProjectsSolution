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
            int x = 6000;
            int y = 6000;

            int cont = 0;

            array = new int[x,y];

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    array[i, j] = cont++;
                }

            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    //Console.WriteLine(array[i, j]);
                }
            Console.WriteLine("OK");
            recursividade2(x - 1, y - 1);
            Console.WriteLine("OK");
            //recursividade(x - 1, y - 1, y - 1);


            //for (int i = x - 1; i >= 0; i--)ss
            //{
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
            //string result = string.Empty;
            if (x == 0)
            {
                //result = array[x, y].ToString();
            }
            else
            {
                //result = array[x, y].ToString();
                recursividade2(x-1, y);
            }
            recursividade3(x, y - 1);
            //Console.WriteLine(result);
        }
        static void recursividade3(int x, int y)
        {
            //string result = string.Empty;
            if (y == 0)
            {
                //result = array[x, y].ToString();
            }
            else
            {
                //result = array[x, y].ToString();
                recursividade3(x, y-1);
            }
            //Console.WriteLine(result);
        }
    }
}
