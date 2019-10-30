using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Helper
    {
        public static string AddQuotes(string text)
        {
            return String.Format("\"{0}\"", text);
        }
    }
}
