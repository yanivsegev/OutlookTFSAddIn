using Microsoft.TeamFoundation.WorkItemTracking.Client;
using OutlookTFSAddIn.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookTFSAddIn
{
    public partial class WorkItemDetails : MetroFramework.Forms.MetroForm
    {
        Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem _newWorkItem;
        public WorkItemDetails(Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem newWorkItem)
        {
            InitializeComponent();
            _newWorkItem = newWorkItem;
            this.Text = $"{newWorkItem.Type.Name} Details";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _newWorkItem.FieldChanged += _newWorkItem_FieldChanged;
            var fields = Settings.Default.Fields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string fieldStr in fields)
            {
                var fieldValues = fieldStr.Split(':');

                if (_newWorkItem.Fields.Contains(fieldValues[0]))
                {
                    var field = _newWorkItem.Fields[fieldValues[0]];
                    if (field.IsEditable)
                    {
                        if (fieldValues.Length > 1)
                        {
                            field.Value = fieldValues[1];
                        }
                        var x = new WorkItemDetail(field);
                        x.Dock = DockStyle.Top;
                        fieldsPanel.Controls.Add(x);
                        x.BringToFront();
                    }
                }
            }

            var fieldNames = fields.Select(x => x.Split(':')[0]).ToList();
            foreach (Field field in _newWorkItem.Fields)
            {
                if (!fieldNames.Contains(field.Name))
                {
                    if (field.IsEditable && !field.IsValid)
                    {
                        var x = new WorkItemDetail(field);
                        x.Dock = DockStyle.Top;
                        fieldsPanel.Controls.Add(x);
                        x.BringToFront();
                    }
                }
            }

        }

        private void _newWorkItem_FieldChanged(object sender, WorkItemEventArgs e)
        {
            CreateBtn.Enabled = _newWorkItem.IsValid();
        }

    }
}
