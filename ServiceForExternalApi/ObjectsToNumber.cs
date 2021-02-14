using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class ObjectsToNumber
    {
        public int Convert(Object value)
        {
            try
            {
                int i = (int)value;
            }
            catch(FormatException e)
            {
                if (value.ToString().Contains("%"))
                {
                    return Int32.Parse(value.ToString().Replace("%", ""));
                }
                else
                {
                    throw e;
                }
            }
            return -1;
        }
    }
}
