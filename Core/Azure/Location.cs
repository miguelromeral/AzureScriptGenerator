using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Azure
{
    /// <summary>
    /// https://github.com/Azure/azure-cli/issues/1520
    /// <code>az account list -locations -o table</code>
    /// </summary>
    public enum Location
    {
        [Description("East Asia")]
        eastasia,
        [Description("Southeast Asia")]
        southeastasia,
        [Description("Central US")]
        centraulus,
        [Description("East US")]
        eastus,
        [Description("East US 2")]
        eastus2,
        [Description("West US")]
        westus,
        [Description("North Central US")]
        northcentralus,
        [Description("South Central US")]
        southcentralus,
        [Description("North Europe")]
        northeurope,
        [Description("West Europe")]
        westeurope,
        [Description("Japan West")]
        japanwest,
        [Description("Japan East")]
        japaneast,
        [Description("Brazil South")]
        brazilsouth,
        [Description("Australia East")]
        australiaeast,
        [Description("Australia  Southeast")]
        australiasoutheast,
        [Description("South India")]
        southindia,
        [Description("Central India")]
        centralindia,
        [Description("West India")]
        westindia,
        [Description("Canada Central")]
        canadacentral,
        [Description("Canada East")]
        canadaeast,
        [Description("UK South")]
        uksouth,
        [Description("UK West")]
        ukwest,
        [Description("West Central US")]
        westcentralus,
        [Description("West US 2")]
        westus2,
        [Description("Korea Central")]
        koreacentral,
        [Description("Korea South")]
        koreasouth,
        [Description("France Central")]
        francecentral,
        [Description("France South")]
        francesouth,
        [Description("Australia Central")]
        australiacentral,
        [Description("Australia Central 2")]
        australiacentral2,
        [Description("South Africa North")]
        southafricanorth,
        [Description("South Africa West")]
        southafricawest,
    }
}
