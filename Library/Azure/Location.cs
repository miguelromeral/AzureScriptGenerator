using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Azure
{
    /// <summary>
    /// https://github.com/Azure/azure-cli/issues/1520
    /// <code>az account list -locations -o table</code>
    /// </summary>
    public enum Location
    {
        [Display(Description="East Asia")]
        eastasia,
        [Display(Description="Southeast Asia")]
        southeastasia,
        [Display(Description="Central US")]
        centraulus,
        [Display(Description="East US")]
        eastus,
        [Display(Description="East US 2")]
        eastus2,
        [Display(Description="West US")]
        westus,
        [Display(Description="North Central US")]
        northcentralus,
        [Display(Description="South Central US")]
        southcentralus,
        [Display(Description="North Europe")]
        northeurope,
        [Display(Description="West Europe")]
        westeurope,
        [Display(Description="Japan West")]
        japanwest,
        [Display(Description="Japan East")]
        japaneast,
        [Display(Description="Brazil South")]
        brazilsouth,
        [Display(Description="Australia East")]
        australiaeast,
        [Display(Description="Australia  Southeast")]
        australiasoutheast,
        [Display(Description="South India")]
        southindia,
        [Display(Description="Central India")]
        centralindia,
        [Display(Description="West India")]
        westindia,
        [Display(Description="Canada Central")]
        canadacentral,
        [Display(Description="Canada East")]
        canadaeast,
        [Display(Description="UK South")]
        uksouth,
        [Display(Description="UK West")]
        ukwest,
        [Display(Description="West Central US")]
        westcentralus,
        [Display(Description="West US 2")]
        westus2,
        [Display(Description="Korea Central")]
        koreacentral,
        [Display(Description="Korea South")]
        koreasouth,
        [Display(Description="France Central")]
        francecentral,
        [Display(Description="France South")]
        francesouth,
        [Display(Description="Australia Central")]
        australiacentral,
        [Display(Description="Australia Central 2")]
        australiacentral2,
        [Display(Description="South Africa North")]
        southafricanorth,
        [Display(Description="South Africa West")]
        southafricawest,
    }
}
