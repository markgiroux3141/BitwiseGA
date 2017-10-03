using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_GA
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            BitwiseGA GA = new BitwiseGA();
            int[] num1 = new int[4] { 5, 3, 6, 4};
            int[] num2 = new int[4] { 2, 9, 1, 6};

            int[][] num = new int[2][];
            num[0] = num1;
            num[1] = num2;

            sw.Start();

            int[][] outp;
            
            outp = GA.Cross(num);
            
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
