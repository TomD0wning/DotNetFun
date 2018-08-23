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

            //List<string> outputList = new List<string>();
            //int stringLength = int.MinValue;

            //foreach (string s in inputArray)
            //{
            //    if (s.Length > stringLength)
            //        stringLength = s.Length;
            //}

            //foreach (string ss in inputArray)
            //{
            //    if (ss.Length == stringLength)
            //        outputList.Add(ss);

            //}

            //return outputList.ToArray<string>();

        }

        public static int CommonCharacterCount(string s1, string s2)
        {
            //not quite right - only counts common instances of a char, not how many of the common char there are.
            var res = s1.ToList<char>().Intersect(s2.ToList<char>()).Count<char>();
            Console.WriteLine(res);

            return res;
            }
    }
}