using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Statements
{
    public class ConditionalIf : Command
    {
        public bool Negate { get; set; }
        public Command Statement { get; set; }
        public List<Command> TrueStatements { get; set; }
        public List<Command> FalseStatements { get; set; }

        public ConditionalIf(Command statement)
        {
            Statement = statement;
            TrueStatements = new List<Command>();
            FalseStatements = new List<Command>();
        }

        public ConditionalIf(Command statement, List<Command> truestatements)
        {
            Statement = statement;
            TrueStatements = truestatements;
            FalseStatements = new List<Command>();
        }

        public ConditionalIf(Command statement, List<Command> truestatements, List<Command> falsestatements)
        {
            Statement = statement;
            TrueStatements = truestatements;
            FalseStatements = falsestatements;
        }


        public void AddTrueStatement(Command command)
        {
            TrueStatements.Add(command);
        }
        public void AddFalseStatement(Command command)
        {
            FalseStatements.Add(command);
        }


        private string PrintStatements(List<Command> statements)
        {
            string text = "";
            foreach(var s in statements)
            {
                s.Ident += 1;
                text += s + Script.NL;
            }
            return text;
        }

        public override string ToString()
        {
            string text = "if(";
            if (Negate)
            {
                text += "-not (";
            }
            text += Statement + ")";
            if (Negate)
            {
                text += ")";
            }
            text += NewLine();
            text += "{" + NewLine();
            text += PrintStatements(TrueStatements);
            text += "}";
            if(FalseStatements.Count != 0)
            {
                text += NewLine();
                text += "else" + NewLine();
                text += "{" + NewLine();
                text += PrintStatements(FalseStatements);
                text += "}";
            }
            return text;
        }
    }
}
