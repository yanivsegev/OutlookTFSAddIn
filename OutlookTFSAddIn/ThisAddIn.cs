using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Text.RegularExpressions;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using OutlookTFSAddIn.Properties;

namespace OutlookTFSAddIn
{
    public partial class ThisAddIn
    {
        private void InternalStartup()
        {
            Helper.Instance = new Helper(this);
        }

    }
}