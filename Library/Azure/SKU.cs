using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Azure
{
    public enum SKU
    {
        [SKUAttribute("Locally-redundant storage")]
        Standard_LRS,
        [SKUAttribute("Zone-redundant storage")]
        Standard_ZRS,
        [SKUAttribute("Geo-redundant storage")]
        Standard_GRS,
        [SKUAttribute("Read access geo-redundant storage")]
        Standard_RAGRS,
        [SKUAttribute("Premium locally-redundant storage")]
        Premium_LRS
    }
}
