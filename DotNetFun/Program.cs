using System;




namespace DotNetFun
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, lets look at some basics");

            //Console.WriteLine("\n--------Equality--------");

            //Food banana = new Food("Banana", "Yellow");
            //Food bananas = new Food("Banana", "Brown");
            //Food apple = new Food("Apple");

            ////!= cos they ref different objs in mem
            //Console.WriteLine(banana.Equals(bananas));

            //Console.WriteLine("\n----int----Equality--------");

            //Console.WriteLine("Using Operators: " + Numbers.AreIntEqualOp(15,15));
            //Console.WriteLine("Equality method: " + Numbers.AreIntsEqualMethod(15,15));
            //Console.WriteLine("Using Reference: " + Numbers.ReferenceEquals(15,15));

            //Console.WriteLine("\n----string----Equality--------");

            //string x = "Hello";
            //string y = string.Copy(x);

            //Console.WriteLine("Using Operators: " + Strings.AreStringsEqualOp(x,y));
            //Console.WriteLine("Equality method: " + Strings.AreStringsEqualMethod(x, y));
            //Console.WriteLine("Using Reference: " + Strings.AreStringsEqualRef(x, y));

            //Console.WriteLine("\nIs 'aba' a palindrome? " + Strings.CheckPalindrome("aba"));
            //Console.WriteLine("\nIs 'bacca' a palindrome? " + Strings.CheckPalindrome("bacca"));
            //Console.WriteLine("\nIs 'acca' a palindrome? " + Strings.CheckPalindrome("acca"));
            //Console.WriteLine("\nIs 'z' a palindrome? " + Strings.CheckPalindrome("z"));

            //Console.WriteLine("\n----You're a Wizard Harry-----");

            //Wizard Harry = new Wizard("Harry", 2);
            //Console.WriteLine(Harry.CastSpell(1));


            #region codingChallenges
            //int[] inputArray = { -23, 4, -3, 8, -12 };
            //Numbers.AdjacentElementsProduct(inputArray);

            //int[] statueArray = {10, 101};
            //Console.WriteLine(Numbers.makeArrayConsecutive2(statueArray));


            //int[] seq = { 10, 1, 2, 3, 4, 5 };
            //int[] seq2 = { 0, -2, 5, 6 };
            //int[] seq3 = { 123, -17, -5, 1, 2, 3, 12, 43, 45 };
            //Console.WriteLine(Numbers.AlmostIncreasingSequence(seq3));

            //string s1s = "aabcc";
            //string s2 = "adcaa";

            //Strings.CommonCharacterCount(s1s, s2);

            //Console.WriteLine(Numbers.IsLucky(1230));

            //Console.WriteLine(Strings.ReverseParentheses("a(bc)de"));

            //int[] a = {50, 60, 60, 45, 70};
            //Console.WriteLine(Numbers.AlternatingSums(a));

            //string[] b = { "abc", "ded" };
            //Console.WriteLine(Strings.AddBorder(b));

            // int[] a = {1, 4, 2, 5, 3, 7, 4, 8, 4, 2, 25};
            // int[] b = {1, 4, 2, 5, 3, 3, 7, 8, 4, 2, 25};
            // Console.WriteLine(Numbers.AreSimilier(a, b));


            // int[] inputArray = {1,1,1};
            // System.Console.WriteLine($"\nMoveCount: {Numbers.arrayChange(inputArray)}");
            
            //Strings.ShortestPassword("../keylogger.txt");

            // string stringToRearrange = "aabb";
            // System.Console.WriteLine(Strings.palindromeRearranging(stringToRearrange));
            
            // int yourLeft = 10;
            // int yourRight = 5; 
            // int friendsLeft = 5; 
            // int friendsRight = 9;
            // System.Console.WriteLine(Numbers.areEquallyStrong(yourLeft, yourRight,friendsLeft,friendsRight));

            // int[] arrayMaxDifference = {2, 4, 1, 0};
            // System.Console.WriteLine(Numbers.arrayMaximalAdjacentDifference(arrayMaxDifference));

            string ipAddress = "192.168.0.1";
            System.Console.WriteLine(Strings.isIPv4Address(ipAddress));


            #endregion

            // Console.ReadLine();
        }
    }
}
