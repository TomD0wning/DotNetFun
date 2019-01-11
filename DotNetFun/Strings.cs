using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Net;

namespace DotNetFun
{
    class Strings
    {

        /*Checks that do not use ReferenceEquals specifically will compare the strings not the object reference*/

        public static bool AreStringsEqualOp(string x, string y)
        {
            return x == y;
        }

        public static bool AreStringsEqualMethod(string x, string y)
        {


            return x.Equals(y);
        }

        public static bool AreStringsEqualRef(string x, string y)
        {
            return ReferenceEquals(x, y);
        }


        public static bool CheckPalindrome(string inputString)
        {
            int l = inputString.Length;

            char[] inputChars = inputString.ToCharArray();

            foreach (char c in inputChars)
            {
                if (c != inputChars[l - 1])
                {
                    return false;
                }
                else
                {
                    l--;
                    continue;
                }
            }
            return true;
        }



        public static string[] AllLongestStrings(string[] inputArray)
        {

            int stringLength = int.MinValue;

            foreach (string s in inputArray)
            {
                if (s.Length > stringLength)
                    stringLength = s.Length;
            }

            var lengths = from v in inputArray
                          where v.Length == stringLength
                          select v;

            return lengths.ToArray<string>();

        }

        public static int CommonCharacterCount(string s1, string s2)
        {
            int common = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        s2 = s2.Remove(j, 1);
                        common++;
                        break;
                    }
                }
            }

            return common;
        }

        /*
         * You have a string s that consists of English letters, punctuation marks, whitespace characters, and brackets. It is guaranteed that the parentheses in s form a regular bracket sequence.
         * Your task is to reverse the strings contained in each pair of matching parentheses, starting from the innermost pair. The results string should not contain any parentheses.
         * Example
         * For string s = "a(bc)de", the output should be
         * reverseParentheses(s) = "acbde".
         */

        public static string ReverseParentheses(string inputString)
        {
            while(inputString.Contains("("))
            {
            int i = inputString.LastIndexOf("(");
            var s = new string(inputString.Skip(i + 1).TakeWhile(x => x != ')').Reverse().ToArray());
            var t = "(" + new string(s.Reverse().ToArray()) + ")";
            inputString = inputString.Replace(t, s);
            }
            return inputString;
            }

        /*
         * Given a rectangular matrix of characters, add a border of asterisks(*) to it.
         * Example - For picture = ["abc",
         *                          "ded"]
         * the output should be
         * addBorder(picture) = ["*****",
         *                       "*abc*",
         *                       "*ded*",
         *                       "*****"]
         */
        //picture: ["abcde",
        // "fghij",
        // "klmno",
        // "pqrst",
        // "uvwxy"]
        //        Output:

        //["*******",
        //"*abcde*",
        //"*fghij*",
        //"*klmno*",
        //"*pqrst*",
        //"*uvwxy*",
        //"*******"]
        public static string[] AddBorder(string[] picture)
        {
            String[] pictureBorder = new String[picture.Length + 2];
            pictureBorder[0] = "";
            pictureBorder[pictureBorder.Length - 1] = "";

            for (int i = 0; i < picture[0].Length + 2; i++)
            {
                pictureBorder[0] += '*';
                pictureBorder[pictureBorder.Length - 1] += '*';

            }
            for (int i = 1; i < pictureBorder.Length - 1; i++)
            {
                pictureBorder[i] = "*" + picture[i - 1] + "*";
            }
                return pictureBorder;
        }

        public static void ShortestPassword(string keyFile)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(keyFile)))
            {
                var keyArray = sr.ReadToEnd().Split("\n\r");

                var found = false;
                var index = 10000000; // I chose this as a starting point because I can see the count of unique numbers
                var answer = "";
                while (!found)
                {
                    answer = (index++).ToString();

                    // The Linq All method takes advantage of short-circuit evaluation.
                    // As soon as any number is matched the while will progress
                    found = keyArray.All(x =>
                    answer.IndexOf(x[0]) != -1 &&
                    answer.IndexOf(x[1]) != -1 &&
                    answer.IndexOf(x[2]) != -1 &&

                    answer.IndexOf(x[0]) < answer.IndexOf(x[1]) &&
                    answer.IndexOf(x[1]) < answer.IndexOf(x[2])
                );
                }

                Console.WriteLine(answer);
                Console.Read();
            }
        }

        /*
        Given a string, find out if its characters can be rearranged to form a palindrome.
        Example
        For inputString = "aabb", the output should be
        palindromeRearranging(inputString) = true.
        We can rearrange "aabb" to make "abba", which is a palindrome.
        A string consisting of lowercase English letters.
        Must read the same forwards & backwards - all letters i.e. bob, dad etc...

        Guaranteed constraints:
        1 ≤ inputString.length ≤ 50.
        [output] boolean
        true if the characters of the inputString can be rearranged to form a palindrome, false otherwise.
        */
       public static bool palindromeRearranging(string inputString) 
        {
            var charGroups = inputString.GroupBy(x => x);
            var charCount = new int[charGroups.Count()];
            for (var i = 0; i < charCount.Length; i++) {
                charCount[i] = inputString.ToArray().Count(x => x == charGroups.Skip(i).FirstOrDefault()?.Key);
            }
            return charCount.Count(x => x % 2 == 1) < 2;
        }

        /*
            An IP address is a numerical label assigned to each device (e.g., computer, printer) participating in a computer network that uses the Internet Protocol for communication. There are two versions of the Internet protocol, and thus two versions of addresses. One of them is the IPv4 address.
            IPv4 addresses are represented in dot-decimal notation, which consists of four decimal numbers, each ranging from 0 to 255 inclusive, separated by dots, e.g., 172.16.254.1.
            Given a string, find out if it satisfies the IPv4 address naming rules.

            For inputString = "172.16.254.1", the output should be
            isIPv4Address(inputString) = true;

            For inputString = "172.316.254.1", the output should be
            isIPv4Address(inputString) = false.
            316 is not in range [0, 255].

            For inputString = ".254.255.0", the output should be
            isIPv4Address(inputString) = false.
            There is no first number.
         */

         public static bool isIPv4Address(string inputString) {
        
             //using regex
            Regex r = new Regex("^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            return r.IsMatch(inputString);

            //non regex
            //  var ipArray = inputString.Split('.');
            //  if(ipArray.Length != 4)
            //  return false;

            //  for (int i = 0; i < ipArray.Length; i++)
            //  {
            //      if(int.Parse(ipArray[i]) < 0 && int.Parse(ipArray[i]) > 255)
            //      return false;
            //  }
            //  return true;
        }


    }
}
 