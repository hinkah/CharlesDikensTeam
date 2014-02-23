using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public class InvalidPowerValueException : ApplicationException
    {
        public InvalidPowerValueException(string msg)
            : base(msg)
        {
        }

        public InvalidPowerValueException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }

    }
}

