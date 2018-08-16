using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetFun
{
    class Dates
    {


        int CenturyFromYear(int year)
        {

            int rem;
            int res = Math.DivRem(year, 100, out rem);

            if (rem > 0)
            {
                return res += 1;
            }

            return res;

        }

    }
}
