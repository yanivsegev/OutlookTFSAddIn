using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using OutlookTFSAddIn.Properties;

namespace OutlookTFSAddIn
{
    public partial class Ribbon1
    {

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
        }

       
        private void CreateWorkItemBtn_Click(object sender, RibbonControlEventArgs e)
        {

        }
        
        private void PBIbtn_Click(object sender, RibbonControlEventArgs e)
        {
            Helper.Instance.SaveCurrentEmailToTFS("Product Backlog Item");
        }

        private void bugBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Helper.Instance.SaveCurrentEmailToTFS("BUG");
        }

        private void TFS_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            if (new SettingsForm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.Reload();
            }
        }
    }
}
