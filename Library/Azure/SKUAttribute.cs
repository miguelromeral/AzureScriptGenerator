using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Azure
{
    public class SKUAttribute : Attribute
    {
        public virtual string Description { get; set; }

        public SKUAttribute(string description)
        {
            Description = description;
        }
    }
}
