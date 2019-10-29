﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum Cmdlet
    {
        [Description("Install-Module")]
        InstallModule,

        [Description("Write-Host")]
        WriteHost,

        [Description("New-AzureRmResourceGroup")]
        NewRG,
    }
}
