using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Cmdlet : Command
    {
        private string _variable;
        public string Variable { get { return HasVariable ? "$" + _variable : String.Empty; } set { _variable = value; } }

        public string Comment { get; set; }

        public bool HasVariable { get { return !String.IsNullOrEmpty(_variable); } }

        public string Command { get; set; }

        public string Value { get; set; }

        public List<Argument> Arguments { get; set; }



        public Cmdlet(string command)
        {
            Command = command;
            Arguments = new List<Argument>();
        }
        public Cmdlet(string command, string value)
        {
            Command = command;
            Value = value;
            Arguments = new List<Argument>();
        }


        public void AddArgument(Argument arg)
        {
            Arguments.Add(arg);
        }




        public override string ToString()
        {
            string text = IdentText();
            if (!String.IsNullOrEmpty(Comment))
            {
                text += Comment + Script.NL + IdentText(Ident);
            }
            text += Command;
            if (!String.IsNullOrEmpty(Value))
            {
                text += " " + Value;
            }
            if (HasVariable)
            {
                text += " " + Variable + " = ";
            }
            text += PrintArguments();

            return text;
        }

        public string PrintArguments()
        {
            string text = "";
            foreach(var arg in Arguments)
            {
                text += " " + arg.Variable;
                if(arg.HasValue)
                    text += " " + arg.Value;
            }
            return text;
        }
    }
}