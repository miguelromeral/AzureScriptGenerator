using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Universal.ViewModels
{
    public class ResourceGroupViewModel : NotificationBase
    {
        Command _command;
        public Command Command
        {
            get { return _command; }
            set { if (SetProperty(ref _command, value)) RaisePropertyChanged(nameof(Command)); }
        }

        public ResourceGroupViewModel()
        {
        }

    }
}
