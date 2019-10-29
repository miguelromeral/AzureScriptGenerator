using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Statements
{
    public class Assignment : Command
    {
        public Variable Variable { get; set; }
        public Command AssignmentCommand { get; set; }
        public string Value { get; set; }

        public Assignment(string variablename, string value)
        {
            Variable = new Variable(variablename);
            Value = value;
        }

        public Assignment(string variablename, Command command)
        {
            Variable = new Variable(variablename);
            AssignmentCommand = command;
        }


        public override string ToString()
        {
            string text = PrintComment();

            text += IdentText() + Variable + " = ";
            if (String.IsNullOrEmpty(Value))
            {
                text += AssignmentCommand;
            }
            else
            {
                text += Value;
            }
            return text;
        }
    }
}
