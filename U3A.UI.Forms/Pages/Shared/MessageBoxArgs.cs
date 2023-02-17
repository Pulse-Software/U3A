using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.UI.Forms
{
    public class MessageBoxArgs
    {
        public MessageBoxArgs() {
            Caption = String.Empty;
            Message = String.Empty;
            OKButtonText = "Ok";
            CancelButtonText = "Cancel";
            ShowCancelButton = true;
            ShowOkButton = true;
        }

        public string Caption { get; set; }
        public string Message { get; set; }
        public string OKButtonText { get; set; }
        public string CancelButtonText { get; set; }
        public bool ShowCancelButton { get; set; }
        public bool ShowOkButton { get; set; }
    }
}
