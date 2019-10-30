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
        [LocationAttribute(Description = "East Asia")]
        eastasia,
        [LocationAttribute(Description = "Southeast Asia")]
        southeastasia,
        [LocationAttribute(Description = "Central US")]
        centraulus,
        [LocationAttribute(Description = "East US")]
        eastus,
        [LocationAttribute(Description = "East US 2")]
        eastus2,
        [LocationAttribute(Description = "West US")]
        westus,
        [LocationAttribute(Description = "North Central US")]
        northcentralus,
        [LocationAttribute(Description = "South Central US")]
        southcentralus,
        [LocationAttribute(Description = "North Europe")]
        northeurope,
        [LocationAttribute(Description = "West Europe")]
        westeurope,
        [LocationAttribute(Description = "Japan West")]
        japanwest,
        [LocationAttribute(Description = "Japan East")]
        japaneast,
        [LocationAttribute(Description = "Brazil South")]
        brazilsouth,
        [LocationAttribute(Description = "Australia East")]
        australiaeast,
        [LocationAttribute(Description = "Australia Southeast")]
        australiasoutheast,
        [LocationAttribute(Description = "South India")]
        southindia,
        [LocationAttribute(Description = "Central India")]
        centralindia,
        [LocationAttribute(Description = "West India")]
        westindia,
        [LocationAttribute(Description = "Canada Central")]
        canadacentral,
        [LocationAttribute(Description = "Canada East")]
        canadaeast,
        [LocationAttribute(Description = "UK South")]
        uksouth,
        [LocationAttribute(Description = "UK West")]
        ukwest,
        [LocationAttribute(Description = "West Central US")]
        westcentralus,
        [LocationAttribute(Description = "West US 2")]
        westus2,
        [LocationAttribute(Description = "Korea Central")]
        koreacentral,
        [LocationAttribute(Description = "Korea South")]
        koreasouth,
        [LocationAttribute(Description = "France Central")]
        francecentral,
        [LocationAttribute(Description = "France South")]
        francesouth,
        [LocationAttribute(Description = "Australia Central")]
        australiacentral,
        [LocationAttribute(Description = "Australia Central 2")]
        australiacentral2,
        [LocationAttribute(Description = "South Africa North")]
        southafricanorth,
        [LocationAttribute(Description = "South Africa West")]
        southafricawest,
    }
}
