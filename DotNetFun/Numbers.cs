﻿using System;
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

        public static bool Modulo(int n){
            return Math.DivRem(n, 2, out int res) == 0 ? true : false;

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
        public static int MakeArrayConsecutive2(int[] statues)
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

//Ticket numbers usually consist of an even number of digits.
//A ticket number is considered lucky if the sum of the first half of the digits is equal to the sum of 
//the second half.
//Given a ticket number n, determine if it's lucky or not.
//Example
//For n = 1230, the output should be
//isLucky(n) = true;
//For n = 239017, the output should be
//isLucky(n) = false.

        public static bool IsLucky(int n)
        {
            char[] arr = n.ToString().ToArray();
            int firstHalf = 0;
            int secondHalf = 0;
            for (int i = 0; i < (arr.Length/2); i++)
            {
                firstHalf += arr[i];
                secondHalf += arr[(arr.Length / 2) + i];

            }
            return firstHalf == secondHalf ? true : false;
        }

        /* Example
         * For a = [-1, 150, 190, 170, -1, -1, 160, 180], the output should be
         * sortByHeight(a) = [-1, 150, 160, 170, -1, -1, 180, 190].
         * If a[i] = -1, then the ith position is occupied by a tree. Otherwise a[i] is the height of a 
         * person standing in the ith position.
         */

        public static int[] SortByHeight(int[] a){

            var b = (from v in a orderby v ascending where v != -1 select v).ToList();
            //var b = a.OrderBy(i => i).ToList<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] == -1){
                    b.Insert(i, a[i]);
                }

            }
            return b.ToArray<int>();
        }


        /*
         * Several people are standing in a row and need to be divided into two teams. The first person goes into team 1, 
         * the second goes into team 2, the third goes into team 1 again, the fourth into team 2, and so on.
         * You are given an array of positive integers - the weights of the people. Return an array of two integers, 
         * where the first element is the total weight of team 1, and the second element is the total weight of 
         * team 2 after the division is complete.
         * 
         * Example
         * For a = [50, 60, 60, 45, 70], the output should be
         * alternatingSums(a) = [180, 105].
         */

        public static int[] AlternatingSums(int[] a)
        {
            int oddCounter = 0;
            int evenCounter = 0;


            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 0)
                {
                    oddCounter += a[i];
                }
                else{
                     evenCounter += a[i];
                    }
                }
            int[] weights = {oddCounter, evenCounter};

            return weights;

           }
        /*Two arrays are called similar if one can be obtained from another by swapping at most one pair of elements in one of the arrays.
         *Given two arrays a and b, check whether they are similar.
         *Example
         * For a = [1, 2, 3] and b = [1, 2, 3], the output should be
         * areSimilar(a, b) = true.
         * The arrays are equal, no need to swap any elements.
         * For a = [1, 2, 3] and b = [2, 1, 3], the output should be
         * areSimilar(a, b) = true.
         * We can obtain b from a by swapping 2 and 1 in b.
         * For a = [1, 2, 2] and b = [2, 1, 1], the output should be
         * areSimilar(a, b) = false.
         * Any swap of any two elements either in a or in b won't make a and b equal.
         * 
         * a: [2, 3, 9]
         * b: [10, 3, 2] 
         a: [4, 6, 3]
         b: [3, 4, 6]
         a: [1, 2, 3]
         b: [1, 10, 2]
         //int[] a = {905, 944, 570, 567, 880, 147, 791, 201, 829, 727, 687, 988, 691, 768, 726, 731, 666, 646, 621, 340, 372, 920, 473, 606, 721, 228, 984, 218, 948, 197, 87, 94, 425, 719, 293, 888, 610, 331, 67, 812, 107, 976, 724, 721, 459, 147, 201, 586, 611, 153, 93, 627, 358, 810, 459, 55, 317, 652, 726, 558, 302, 285, 370, 812, 866, 435, 266, 733, 578, 597, 13, 778, 453, 654, 297, 408, 257, 277, 503, 919, 874, 83, 566, 904, 866, 896, 462, 915, 124, 240, 947, 961, 724, 386, 870, 354, 122, 756, 103, 626, 741, 385, 267, 986, 639, 144, 605, 736, 130, 766, 584, 748, 58, 503, 813, 538, 934, 638, 70, 698, 808, 407, 314, 281, 12, 463, 395, 145, 724, 381, 323, 151, 42, 658, 686, 483, 414, 517, 213, 281, 714, 204, 493, 346, 88, 955, 922, 710, 870, 59, 553, 153, 565, 362, 317, 162, 960, 133, 798, 805, 211, 611, 532, 249, 438, 205, 998, 560, 225, 855, 994, 266, 640, 757, 853, 708, 542, 259, 640, 962, 951, 952, 694, 425, 406, 823, 775, 514, 807, 61, 393, 995, 394, 700, 80, 643, 877, 572, 87, 330, 529, 127, 966, 124, 500, 687, 945, 534, 409, 71, 310, 72, 315, 942, 806, 395, 367, 30, 237, 460, 744, 340, 903, 780, 904, 894, 414, 672, 822, 84, 976, 761, 921, 8, 535, 490, 419, 803, 998, 848, 105, 128, 615, 585, 970, 400, 798, 506, 714, 930, 461, 647, 951, 424, 481, 193, 303, 232, 88, 66, 794, 471, 803, 929, 203, 916, 200, 307, 268, 734, 456, 529, 329, 885, 609, 440, 569, 80, 720, 129, 862, 621, 730, 869, 426, 37, 402, 3, 300, 28, 432, 972, 633, 735, 967, 945, 588, 77, 871, 1, 884, 281, 454, 995, 474, 575, 480, 926, 216, 434, 715, 75, 635, 413, 949, 111, 263, 899, 84, 203, 676, 175, 597, 41, 42, 152, 675, 315, 721, 283, 61, 564, 454, 250, 461, 392, 238, 316, 29, 27, 98, 225, 802, 909, 124, 633, 833, 317, 579, 32, 192, 36, 299, 23, 790, 416, 366, 1000, 740, 529, 551, 924, 375, 448, 513, 327, 209, 312, 858, 557, 635, 326, 752, 555, 34, 296, 685, 907, 401, 971, 799, 630, 974, 589, 558, 65, 850, 353, 792, 628, 805, 601, 279, 644, 943, 897, 332, 487, 318, 257, 714, 992, 666, 522, 112, 133, 967, 978, 481, 660, 607, 766, 918, 767, 262, 142, 518, 507, 649, 359, 836, 753, 534, 669, 415, 323, 701, 545, 60, 214, 427, 964, 229, 236, 640, 685, 464, 962, 595, 196, 305, 36, 69, 658, 405, 972, 872, 331, 782, 413, 291, 149, 281, 801, 105, 309, 844, 352, 367, 957, 363, 740, 228, 650, 60, 330, 306, 946, 276, 498, 996, 653, 250, 309, 173, 443, 202, 461, 440, 173, 721, 278, 837, 98, 456, 133, 102, 609, 581, 403, 89, 650, 657, 315, 999, 645, 286, 66, 712, 383, 641, 820, 648, 429, 618, 311, 456, 709, 763, 10, 778, 470, 371, 97, 855, 735, 817, 700, 499, 965, 645, 489, 391, 685, 721, 23, 478, 49, 654, 698, 176, 346, 792, 853, 186, 560, 347, 118, 392, 107, 853, 853, 345, 245, 801, 176, 72, 208, 534, 144, 558, 832, 892, 822, 673, 650, 554, 124, 797, 800, 733, 479, 878, 424, 536, 550, 725, 177, 169, 445, 585, 517, 827, 447, 766, 769, 881, 336, 916, 574, 949, 256, 437, 290, 612, 35, 502, 543, 28, 446, 356, 978, 721, 27, 35, 231, 388, 688, 686, 983, 920, 703, 940, 387, 334, 110, 758, 246, 966, 215, 735, 360, 659, 631, 806, 802, 116, 872, 845, 296, 356, 143, 28, 848, 733, 535, 788, 130, 350, 383, 607, 281, 571, 271, 876, 403, 612, 968, 85, 964, 621, 752, 783, 18, 546, 314, 54, 778, 707, 685, 354, 559, 173, 994, 98, 985, 945, 675, 748, 260, 648, 140, 255, 596, 557, 865, 163, 808, 43, 881, 454, 678, 25, 912, 834, 189, 852, 968, 995, 517, 589, 380, 820, 629, 320, 361, 691, 429, 730, 366, 821, 744, 349, 786, 682, 914, 437, 24, 286, 499, 710, 316, 40, 303, 157, 784, 286, 119, 299, 746, 127, 419, 474, 935, 520, 433, 308, 218, 893, 680, 928, 561, 810, 440, 362, 326, 348, 318, 329, 773, 386, 312, 811, 321, 171, 900, 72, 759, 41, 367, 594, 85, 213, 790, 711, 815, 436, 519, 817, 951, 849, 698, 797, 913, 575, 793, 255, 738, 666, 774, 974, 225, 68, 838, 133, 125, 382, 645, 277, 575, 991, 557, 613, 75, 720, 807, 378, 359, 370, 812, 949, 528, 408, 302, 363, 669, 751, 232, 115, 790, 324, 167, 253, 243, 670, 166, 988, 902, 992, 707, 45, 876, 101, 805, 584, 782, 676, 18, 170, 154, 939, 895, 108, 921, 530, 920, 252, 376, 508, 732, 531, 484, 537, 582, 622, 838, 290, 577, 578, 681, 362, 1, 896, 598, 730, 39, 839, 417, 294, 558, 550, 97, 372, 175, 394, 557, 844, 935, 575, 720, 553, 567, 250, 186, 68, 949, 227, 776, 578, 49, 192, 94, 15, 210, 947, 913, 337, 898, 367, 740, 201, 436, 86, 348, 47, 319, 498, 714, 152, 873, 60, 841, 573, 820, 747, 852, 862, 449, 90, 391, 761, 21, 595, 23, 773, 547, 401, 772, 5, 10, 50, 745, 398, 753, 976, 820, 780, 616, 807, 53, 424, 66, 325, 365, 936, 781, 168, 611, 122, 848, 572, 846, 351, 397, 765, 810, 255, 531, 699, 181, 477, 49, 710, 886, 83, 228, 476, 196, 236, 406, 389, 133, 945, 436, 147, 256, 848, 276, 690, 18, 669, 407, 73, 691, 356, 844, 183, 525, 559, 484, 883, 450, 109, 367, 58, 223, 612, 776, 565, 229, 77, 410, 150, 477, 243, 314, 955, 795, 356, 995, 550, 579, 875, 652, 851, 847, 797, 562, 848, 607, 2, 499, 606, 500, 967, 431, 592, 690, 88, 217};
         //int[] b = {905, 944, 570, 567, 880, 147, 791, 201, 829, 727, 687, 988, 691, 768, 726, 731, 666, 646, 621, 340, 372, 920, 473, 606, 721, 228, 984, 218, 948, 197, 87, 94, 425, 719, 293, 888, 610, 331, 67, 812, 107, 976, 724, 721, 459, 147, 201, 586, 611, 153, 93, 627, 358, 810, 459, 55, 317, 652, 726, 558, 302, 285, 370, 812, 866, 435, 266, 733, 578, 597, 13, 778, 952, 654, 297, 408, 257, 277, 503, 919, 874, 83, 566, 904, 866, 896, 462, 915, 124, 240, 947, 961, 724, 386, 870, 354, 122, 756, 103, 626, 741, 385, 267, 986, 639, 144, 605, 736, 130, 766, 584, 748, 58, 503, 813, 538, 934, 638, 70, 698, 808, 407, 314, 281, 12, 463, 395, 145, 724, 381, 323, 151, 42, 658, 686, 483, 414, 517, 213, 281, 714, 204, 493, 346, 88, 955, 922, 710, 870, 59, 553, 153, 565, 362, 317, 162, 960, 133, 798, 805, 211, 611, 532, 249, 438, 205, 998, 560, 225, 855, 994, 266, 640, 757, 853, 708, 542, 259, 640, 962, 951, 453, 694, 425, 406, 823, 775, 514, 807, 61, 393, 995, 394, 700, 80, 643, 877, 572, 87, 330, 529, 127, 966, 124, 500, 687, 945, 534, 409, 71, 310, 72, 315, 942, 806, 395, 367, 30, 237, 460, 744, 340, 903, 780, 904, 894, 414, 672, 822, 84, 976, 761, 921, 8, 535, 490, 419, 803, 998, 848, 105, 128, 615, 585, 970, 400, 798, 506, 714, 930, 461, 647, 951, 424, 481, 193, 303, 232, 88, 66, 794, 471, 803, 929, 203, 916, 200, 307, 268, 734, 456, 529, 329, 885, 609, 440, 569, 80, 720, 129, 862, 621, 730, 869, 426, 37, 402, 3, 300, 28, 432, 972, 633, 735, 967, 945, 588, 77, 871, 1, 884, 281, 454, 995, 474, 575, 480, 926, 216, 434, 715, 75, 635, 413, 949, 111, 263, 899, 84, 203, 676, 175, 597, 41, 42, 152, 675, 315, 721, 283, 61, 564, 454, 250, 461, 392, 238, 316, 29, 27, 98, 225, 802, 909, 124, 633, 833, 317, 579, 32, 192, 36, 299, 23, 790, 416, 366, 1000, 740, 529, 551, 924, 375, 448, 513, 327, 209, 312, 858, 557, 635, 326, 752, 555, 34, 296, 685, 907, 401, 971, 799, 630, 974, 589, 558, 65, 850, 353, 792, 628, 805, 601, 279, 644, 943, 897, 332, 487, 318, 257, 714, 992, 666, 522, 112, 133, 967, 978, 481, 660, 607, 766, 918, 767, 262, 142, 518, 507, 649, 359, 836, 753, 534, 669, 415, 323, 701, 545, 60, 214, 427, 964, 229, 236, 640, 685, 464, 962, 595, 196, 305, 36, 69, 658, 405, 972, 872, 331, 782, 413, 291, 149, 281, 801, 105, 309, 844, 352, 367, 957, 363, 740, 228, 650, 60, 330, 306, 946, 276, 498, 996, 653, 250, 309, 173, 443, 202, 461, 440, 173, 721, 278, 837, 98, 456, 133, 102, 609, 581, 403, 89, 650, 657, 315, 999, 645, 286, 66, 712, 383, 641, 820, 648, 429, 618, 311, 456, 709, 763, 10, 778, 470, 371, 97, 855, 735, 817, 700, 499, 965, 645, 489, 391, 685, 721, 23, 478, 49, 654, 698, 176, 346, 792, 853, 186, 560, 347, 118, 392, 107, 853, 853, 345, 245, 801, 176, 72, 208, 534, 144, 558, 832, 892, 822, 673, 650, 554, 124, 797, 800, 733, 479, 878, 424, 536, 550, 725, 177, 169, 445, 585, 517, 827, 447, 766, 769, 881, 336, 916, 574, 949, 256, 437, 290, 612, 35, 502, 543, 28, 446, 356, 978, 721, 27, 35, 231, 388, 688, 686, 983, 920, 703, 940, 387, 334, 110, 758, 246, 966, 215, 735, 360, 659, 631, 806, 802, 116, 872, 845, 296, 356, 143, 28, 848, 733, 535, 788, 130, 350, 383, 607, 281, 571, 271, 876, 403, 612, 968, 85, 964, 621, 752, 783, 18, 546, 314, 54, 778, 707, 685, 354, 559, 173, 994, 98, 985, 945, 675, 748, 260, 648, 140, 255, 596, 557, 865, 163, 808, 43, 881, 454, 678, 25, 912, 834, 408, 852, 968, 995, 517, 589, 380, 820, 629, 320, 361, 691, 429, 730, 366, 821, 744, 349, 786, 682, 914, 437, 24, 286, 499, 710, 316, 40, 303, 157, 784, 286, 119, 299, 746, 127, 419, 474, 935, 520, 433, 308, 218, 893, 680, 928, 561, 810, 440, 362, 326, 348, 318, 329, 773, 386, 312, 811, 321, 171, 900, 72, 759, 41, 367, 594, 85, 213, 790, 711, 815, 436, 519, 817, 951, 849, 698, 797, 913, 575, 793, 255, 738, 666, 774, 974, 225, 68, 838, 133, 125, 382, 645, 277, 575, 991, 557, 613, 75, 720, 807, 378, 359, 370, 812, 949, 528, 189, 302, 363, 669, 751, 232, 115, 790, 324, 167, 253, 243, 670, 166, 988, 902, 992, 707, 45, 876, 101, 805, 584, 782, 676, 18, 170, 154, 939, 895, 108, 921, 530, 920, 252, 376, 508, 732, 531, 484, 537, 582, 622, 838, 290, 577, 578, 681, 362, 1, 896, 598, 730, 39, 839, 417, 294, 558, 550, 97, 372, 175, 394, 557, 844, 935, 575, 720, 553, 567, 250, 186, 68, 949, 227, 776, 578, 49, 192, 94, 15, 210, 947, 913, 337, 898, 367, 740, 201, 436, 86, 348, 47, 319, 498, 714, 152, 873, 60, 841, 573, 820, 747, 852, 862, 449, 90, 391, 761, 21, 595, 23, 773, 547, 401, 772, 5, 10, 50, 745, 398, 753, 976, 820, 780, 616, 807, 53, 424, 66, 325, 365, 936, 781, 168, 611, 122, 848, 572, 846, 351, 397, 765, 810, 255, 531, 699, 181, 477, 49, 710, 886, 83, 228, 476, 196, 236, 406, 389, 133, 945, 436, 147, 256, 848, 276, 690, 18, 669, 407, 73, 691, 356, 844, 183, 525, 559, 484, 883, 450, 109, 367, 58, 223, 612, 776, 565, 229, 77, 410, 150, 477, 243, 314, 955, 795, 356, 995, 550, 579, 875, 652, 851, 847, 797, 562, 848, 607, 2, 499, 606, 500, 967, 431, 592, 690, 88, 217};
         // int[] a = {1, 4, 2, 5, 3, 7, 4, 8, 4, 2, 25};
        // int[] b = {1, 4, 2, 5, 3, 3, 7, 8, 4, 2, 25};

         */
        public static bool AreSimilier(int[] a, int[] b)
        {
            int orderCount = 0;
            var orderedA = a.OrderByDescending(x => x);
            var orderedB = b.OrderByDescending(x => x);
            var sumA = 0;
            var sumB = 0;

            var nonIntersect = orderedA.Except(orderedB).Union(orderedB.Except(orderedA));

            if (a.Length != b.Length){
                return false;
            }
            else{
                for (int i = 0; i < a.Length; i++){
                    sumA+=a[i];
                    sumB+=b[i];
                    if (b[i] != a[i]){
                        orderCount++;
                    }
                }
                if (orderCount > 2 || nonIntersect.Any() || sumA != sumB)
                {
                        return false;
                    }else{
                        return true;
                }
            }
        }

        /*
        You are given an array of integers. On each move you are allowed to increase exactly one of its element by one. Find the minimal number of moves required to obtain a strictly increasing sequence from the input.
        Example
        For inputArray = [1, 1, 1], the output should be
        arrayChange(inputArray) = 3
        The minimal number of moves needed to obtain a strictly increasing sequence from inputArray.
        It's guaranteed that for the given test cases the answer always fits signed 32-bit integer type.
         */

         public static int arrayChange(int[] inputArray){

            // int last = inputArray[0] - 1;
            // return inputArray.Sum(_ => (last = Math.Max(last + 1, _)) - _);
            
            int moveCount = 0;

             for (int i = 0; i < inputArray.Length -1; i++)
             {
                 while (inputArray[i+1] < inputArray[i] || inputArray[i+1] == inputArray[i])
                 {
                     inputArray[i+1] = inputArray[i+1] + 1;
                     moveCount++;
                 }
             }
             foreach (var item in inputArray.ToList())
             {
                 System.Console.WriteLine(item);
             }

             return moveCount;
         }



    }
}
