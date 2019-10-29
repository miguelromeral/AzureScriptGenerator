using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Statement : Command
    {   
        public string Command { get; set; }

        public string Value { get; set; }

        public List<Argument> Arguments { get; set; }



        public Statement(string command)
        {
            Command = command;
            Arguments = new List<Argument>();
        }
        public Statement(string command, string value)
        {
            Command = command;
            Value = value;
            Arguments = new List<Argument>();
        }


        public void AddArgument(Argument arg)
        {
            Arguments.Add(arg);
        }
        public void AddArgument(string variable, string value = null)
        {
            Arguments.Add(new Argument(variable, value));
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