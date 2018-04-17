using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace OutlookTFSAddIn
{
    public partial class WorkItemDetail : UserControl
    {
        private Field field;

        public WorkItemDetail()
        {
            InitializeComponent();
        }

        public WorkItemDetail(Field field)
        {
           InitializeComponent();
            this.field = field;
            label1.Text = field.Name;

            if (field.HasAllowedValuesList)
            {
                textBox1.Hide();
                foreach(var x in field.AllowedValues)
                {
                    comboBox1.Items.Add(x);
                }
                comboBox1.Text = field.Value?.ToString() ?? string.Empty;
            }
            else
            {
                comboBox1.Hide();
                textBox1.Text = field.Value?.ToString() ?? string.Empty;

            }

            IsValid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                field.Value = textBox1.Text;
                IsValid();
                textBox1.BackColor = Color.White;
            }
            catch
            {
                textBox1.BackColor = Color.LightPink;
            }
        }

        private void IsValid()
        {
            if ( field.IsValid)
            {
                textBox1.ForeColor = Color.Black;
                comboBox1.ForeColor = Color.Black;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
                comboBox1.ForeColor = Color.Red;
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                field.Value = comboBox1.Text;
                IsValid();
                comboBox1.BackColor = Color.White;
            }
            catch
            {
                comboBox1.BackColor = Color.LightPink;
            }
        }
    }
}
