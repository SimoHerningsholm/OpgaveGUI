using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace CLValidator
{
    public class FieldChecker
    {
        //formålet med denne klasse er at tjekke specifikt input indhold på felter der allerede har passet datatype tjekker
        public async Task<bool> checkForbinddenStringCharacters(List<char> inChars, string inStr)
        {
            if(inStr.Any(strChar => inChars.Any(charSymbol => charSymbol == strChar)))
            {
                return false;
            }
            return true;
        }
        public async Task<bool> checkDateInterval(DateTime date, DateTime lowDate, DateTime highDate)
        {
            if(date >= lowDate && date <= highDate)
            {
                return false;
            }
            return true;
        }

    }
}
