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

            int[] a = {50, 60, 60, 45, 70};
            Console.WriteLine(Numbers.AlternatingSums(a));

            Console.ReadLine();
        }
    }
}
