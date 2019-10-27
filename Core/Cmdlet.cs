using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Cmdlet
    {
        private string _variable;
        public string Variable { get { return HasVariable ? "$" + _variable : String.Empty; } set { _variable = value; } }

        public string Comment { get; set; }

        public bool HasVariable { get { return !String.IsNullOrEmpty(_variable); } }

        public string Command { get; set; }

        public string Value { get; set; }

        public List<Argument> Arguments { get; set; }


        public Cmdlet()
        {
            Arguments = new List<Argument>();
        }


        public override string ToString()
        {
            string text = Comment + Script.NL;
            if (HasVariable)
            {
                text += Variable + " = ";
            }
            text += Command + " " + Value + " " + PrintArguments();

            return text;
        }

        public string PrintArguments()
        {
            string text = "";
            foreach(var arg in Arguments)
            {
                text += arg.Variable;
                if(arg.HasValue)
                    text += "=" + arg.Value;
                text += " ";
            }
            return text;
        }
    }
}