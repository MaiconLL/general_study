using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Domain.Exception
{
    internal class DataInvalidException : System.Exception
    {
        public DataInvalidException(string message) : base(message)
        {
        }
    }
}
