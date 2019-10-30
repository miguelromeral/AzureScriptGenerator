using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Argument
    {
        public static string FORCE = "-Force";
        public static string LOCATION = "-Location";

        public string Variable { get; set; }

        private string _value;
        public string Value { get { return HasValue ? _value : String.Empty; } set { _value = value; } }
        

        public bool HasValue { get { return !String.IsNullOrEmpty(_value); } }


        public Argument(string variable)
        {
            Variable = variable;
        }
        public Argument(string variable, string value)
        {
            Variable = variable;
            Value = value;
        }


        public override string ToString()
        {
            return Variable + " " + Value;
        }
    }
}
