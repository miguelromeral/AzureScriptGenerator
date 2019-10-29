using System;
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
        
        [Cmdlet(Command= "New-AzureRmResourceGroup")]
        NewRG,
    }
}
