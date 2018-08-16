using System;
using System.Collections.Generic;
using System.Text;

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
                    if(c != inputChars[l -1])
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
    }
}
