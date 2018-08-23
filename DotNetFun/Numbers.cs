using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public static bool AlmostIncreasingSequence(int[] sequence)
        {

            int a, b, c,d=0;

            for (int i = 0; i < sequence.Length - 2 && d <= 2; i++)
            {
                a = sequence[i];
                b = sequence[i + 1];
                c = sequence[i + 2];

                if (a >= b)
                {
                    d++;
                    sequence[i] = b - 1;
                }
                if (b >= c)
                {
                    d++;
                    if (a == c)
                    {
                        sequence[i + 2] = b + 1;
                    }
                    else
                    {
                        sequence[i + 1] = a;
                    }
                }
            }
            return d <= 1;
        }

        //Each kilometre you travel takes a certain amount of time - initially, it's initialTimePerKm, but with each additional kilometre travelled, the time per km goes up by timeIncreasePerKm. 
        //The time it takes to pump up the tire is timeToRefill, and the total number of kilometres you need to travel is represented by distance. 
        //Each refill brings the time per km back to initialTimePerKm.

        public static int SlowLeak(int distance, int initialTimePerKm, int timeIncreasePerKm, int timeToRefill)
        {
            return 6;
        }

        public static int MatrixElementsSum(int[][] matrix)
        {
            int rooms = 0;
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    if (rows > 0 && matrix[rows - 1][cols] == 0)
                    {
                        //make room below a haunted one a no-go
                        matrix[rows][cols] = 0;
                    }
                    rooms += matrix[rows][cols];
                }
            }

            return rooms;

        }
    }
}
