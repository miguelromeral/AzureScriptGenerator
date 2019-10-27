using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Command
    {
        public int Ident { get; set; }
        
        public int blockID { get; set; }


        public static string IdentText(int level)
        {
            string text = "";
            for (int i = 0; i < level; i++)
            {
                text += "    ";
            }
            return text;
        }
        
        public string IdentText()
        {
            return IdentText(Ident);
        }

        public string NewLine()
        {
            return Script.NL + IdentText();
        }
    }
}
