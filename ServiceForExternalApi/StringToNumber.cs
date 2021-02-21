using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class StringToNumber
    {
        public int Convert(String value)
        {
            try
            {
                int i = Int32.Parse(value);
                return i;
            }
            catch (FormatException e)
            {
                if (value.Contains("%"))
                {
                    return Int32.Parse(value.ToString().Replace("%", ""));
                }
                else if(value == "")
                {
                    return 0;
                }
                else
                {
                    Console.WriteLine("Check StringToNumber class");
                    throw e;
                }
            }
        }
    }
}

