using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using OutlookTFSAddIn.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookTFSAddIn
{
    class Helper
    {
        private ThisAddIn _addin;
        public Helper(ThisAddIn addin)
        {
            _addin = addin;
        }

        public static Helper Instance { get; set; }

        public void SaveCurrentEmailToTFS(string workItemType)
        {
            try
            {

                Outlook.Selection mySelection = _addin.Application.ActiveExplorer().Selection;
                Outlook.MailItem mailitem = null;

                foreach (Object obj in mySelection)
                {
                    if (obj is Outlook.MailItem)
                    {
                        mailitem = (Outlook.MailItem) obj;

                        // Remove special characters from the file name and make sure it is not longer than 100 characters
                        string strFileName = Regex.Replace(mailitem.ConversationTopic,
                            "[\\/\\\\\\:\\?\\*\\<\\>\\|\\\"]", "");
                        strFileName = strFileName.Substring(0, Math.Min(100, strFileName.Length)) + ".msg";

                        //// The full path will place the email in the user's temporary folder
                        string strTmpPath = System.IO.Path.GetTempPath() + strFileName;

                        //// Save the email to the user's temp folder and convert it to a .MSG
                        mailitem.SaveAs(strTmpPath, Outlook.OlSaveAsType.olMSG);

                        CreateWit(strTmpPath, mailitem.ConversationTopic, workItemType);

                        System.IO.File.Delete(strTmpPath);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.ToString()}", $"Exeption: {e.Message}");
                Console.WriteLine(e);
            }
        }

        private void CreateWit(string strTmpPath, string title, string workItemTypeStr)
        {
            var TeamProjectName = Settings.Default.TeamProjectName;
            // create TfsTeamProjectCollection instance using default credentials
            using (TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(Settings.Default.CollectionUri)))
            {
                // get the WorkItemStore service
                WorkItemStore workItemStore = tpc.GetService<WorkItemStore>();

                // get the project context for the work item store
                Project workItemProject = workItemStore.Projects[TeamProjectName];
                WorkItemType workItemType = workItemProject.WorkItemTypes[workItemTypeStr];

                var newWorkItem = workItemType.NewWorkItem();
                newWorkItem.Title = title;
                newWorkItem.Attachments.Add(new Attachment(strTmpPath));

                var detailsForm = new WorkItemDetails(newWorkItem);
                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    newWorkItem.Save(SaveFlags.MergeAll);

                    var link = $"{tpc.Uri.ToString()}/{TeamProjectName}/_workitems/edit/{newWorkItem.Id}";
                    AddHyperlinkToClipboard(link,$"{workItemType.Name} {newWorkItem.Id}", $"{newWorkItem.Title}");

                    MessageBox.Show($"{workItemType.Name} {newWorkItem.Id}: {newWorkItem.Title}", $"New {workItemType.Name} Created.");
                }
            }
        }

        public void AddHyperlinkToClipboard(string link, string id, string title)
        {
            string vbCrLf = System.Environment.NewLine;
            string sContextStart = "<HTML><BODY><!--StartFragment -->";
            string sContextEnd = "<!--EndFragment --></BODY></HTML>";
            string m_sDescription = "Version:1.0" + vbCrLf + "StartHTML:aaaaaaaaaa" + vbCrLf + "EndHTML:bbbbbbbbbb" + vbCrLf + "StartFragment:cccccccccc" + vbCrLf + "EndFragment:dddddddddd" + vbCrLf;

            string sHtmlFragment = $"<A HREF=\"{link}\">{id}</A>: {title}";

            string sData = m_sDescription + sContextStart + sHtmlFragment + sContextEnd;
            sData = sData.Replace("aaaaaaaaaa", m_sDescription.Length.ToString().PadLeft(10, '0'));
            sData = sData.Replace("bbbbbbbbbb", sData.Length.ToString().PadLeft(10, '0'));
            sData = sData.Replace("cccccccccc", (m_sDescription + sContextStart).Length.ToString().PadLeft(10, '0'));
            sData = sData.Replace("dddddddddd", (m_sDescription + sContextStart + sHtmlFragment).Length.ToString().PadLeft(10, '0'));
            Clipboard.SetDataObject(new DataObject(DataFormats.Html, sData), true);
        }

    }
}
