using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_GA
{
    class BitwiseGA
    {

        private int[] crossPerms = new int[16] { 1, 6, 3, 8, 5, 9, 10, 7, 2, 4, 15, 13, 14, 11, 12, 0 };

        private int[][] pop;
        private int[][] tempCont;
        private int popSize = 100;
        private int geneSize = 10;

        private int bitSize = 4;
        private int bitMask = 0;

        private int currPerm = 0;
        private int currCross = 0;

        public BitwiseGA()
        {
            pop = new int[popSize][];
            tempCont = new int[2][];

            tempCont[0] = new int[geneSize];
            tempCont[1] = new int[geneSize];

            for(int i = 0; i < geneSize; i++)
            {
                pop[i] = new int[geneSize];
            }

        }

        public int GetCrossVal()
        {
            currPerm = (currPerm + 1) - (currPerm & 0x10);
            currCross = crossPerms[currPerm - 1];
            currCross -= currCross & 0x08;
            return currCross;
        }

        public int[][] CrossPop()
        {
            for(int i = 0; i < popSize; i+=2)
            {
                tempCont[0] = pop[i];
                tempCont[1] = pop[i + 1];
                tempCont = Cross(tempCont);
                pop[i] = tempCont[0];
                pop[i + 1] = tempCont[1];
            }
            return pop;
        }

        public int[][] Cross(int[][] inp)
        {
            int flip = 0;
            int currIndex = 0;
            int c1 = GetCrossVal();
            int c2 = GetCrossVal() + c1;

            int[][] output = new int[2][];
            output[0] = new int[inp[0].Length];
            output[1] = new int[inp[0].Length];

            for (int i = 0; i < inp[0].Length; i++)
            {
                for(int n = 0; n < bitSize; n++)
                {
                    currIndex = (i * bitSize) + n;
                    if((currIndex == c1) || (currIndex == c2))
                        flip ^= 1;
                    bitMask = 1 << ((bitSize - 1) - n);
                    output[0][i] |= (inp[flip][i] & bitMask);
                    output[1][i] |= (inp[flip^1][i] & bitMask);
                }
            }
            return output;
        }



        private int FloatToInt(float x)
        {
            return (int)(x * 1000000f);
        }
    }
}
