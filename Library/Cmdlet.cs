﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum Cmdlet
    {
        [Cmdlet(Command= "Install-Module")]
        InstallModule,
        
        [Cmdlet(Command= "Write-Host")]
        WriteHost,
        

        // ------------------- RESOURCES GROUPS ---------------------------
        [Cmdlet(Command= "New-AzureRmResourceGroup")]
        CreateRG,
        [Cmdlet(Command = "Get-AzureRmResourceGroup")]
        ReadRG,
        [Cmdlet(Command = "Remove-AzureRmResourceGroup")]
        DeleteRG,
    }
}
