using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Script
    {
        public string Author { get; set; }
        
        private string _description;
        public string Description { get { return String.IsNullOrEmpty(_description) ? "Script generated using AzureScriptGenerator." : _description; } set { _description = value; } }
        
        public List<Command> Content { get; set; }
        

        public Script()
        {
            Author = "MiguelRomeral";
            Content = new List<Command>();
        }
        
        public void AddCommand(Command cmdlet)
        {
            Content.Add(cmdlet);
        }
        


        public static string NL { get { return Environment.NewLine; } }

        private static string Separator { get { return "########################################################"; } }


        private string Header {
            get
            {
                string text = Separator + NL;
                text += "# Author: " + Author + NL;
                text += "# DateTime: " + DateTime.Now + NL;
                text += "# Description:" + NL + "# " + Description + NL;
                text += Separator + NL;
                return text;
            }
        }

        public override string ToString()
        {
            string text = Header + NL;

            foreach(var cl in Content)
            {
                text += cl + NL;
            }

            text += NL + "# End of the Script." + NL + Separator;
            return text;
        }
    }
}
