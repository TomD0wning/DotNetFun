using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetFun
{
    public static class Numbers
    {

        public static bool AreIntEqualOp(int x, int y)
        {
            return x == y;
        }

        public static bool AreIntsEqualMethod(int x, int y)
        {
            return x.Equals(y);
        }

        public static int AdjacentElementsProduct(int[] inputArray)
        {
            //Find the largest product of adjacent elements from an input array.

            int i = 0;
            int res = int.MinValue;
            for (int j = 0; j < inputArray.Length - 1; j++)
            {
                if ((inputArray[j] * inputArray[i + 1]) > res)
                {
                    res = (inputArray[j] * inputArray[i + 1]);
                }
                i++;
            }
            return res;
        }

        public static int ShapeArea(int n)
        {
            //n1=1
            //n2=5 (n1+4)
            //n3=13 (n2+7)
            //n4=25 (n3+12)
            return (n * n) + (n - 1) * (n - 1);
        }


        //Ratiorg got statues of different sizes as a present from CodeMaster for his birthday, each statue having an non-negative integer size.
        //Since he likes to make things perfect, he wants to arrange them from smallest to largest so that each statue will be bigger than the previous one exactly by 1. 
        //He may need some additional statues to be able to accomplish that.Help him figure out the minimum number of additional statues needed.

        //Example
        //For statues = [6, 2, 3, 8], the output should be
        //2,3,6,8
        //makeArrayConsecutive2(statues) = 3.
        //Ratiorg needs statues of sizes 4, 5 and 7.
        public static int makeArrayConsecutive2(int[] statues)
        {

            List<int> statueList = new List<int>();

            statueList.AddRange(statues);

            statueList.Sort();
            

            int[] newStatues = statueList.ToArray();
            
            int count = 0;

            for (int i = 0; i < newStatues.Length-1; i++)
            {
                if((newStatues[i+1]-(newStatues[i])) > 1 )
                {
                    count+= ((newStatues[i + 1] - (newStatues[i]))-1);
                }
            }
            return count;
        }
    }
}
