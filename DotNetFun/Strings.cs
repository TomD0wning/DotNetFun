using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public static string ReverseParentheses(string s)
        {

            //var b = (from v in a orderby v ascending where v != -1 select v).ToList();

            StringBuilder sb = new StringBuilder();


            string[] c = s.Split('(', ')');

            
            for (int i = 0; i < c.Length -1; i++)
            {

                Console.WriteLine(c[i]);
            }


            return "a";

        }

    }
}
 