using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace Universal.Classes
{
    public static class PageHelper
    {
        public static bool CopyContent(string text)
        {
            try
            {
                var dataPackage = new DataPackage();
                dataPackage.SetText(text);
                Clipboard.SetContent(dataPackage);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

    }
}
