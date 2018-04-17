namespace OutlookTFSAddIn
{
    partial class WorkItemDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateBtn = new MetroFramework.Controls.MetroButton();
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.fieldsPanel = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // CreateBtn
            // 
            this.CreateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CreateBtn.Location = new System.Drawing.Point(464, 400);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateBtn.TabIndex = 1;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseSelectable = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(545, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseSelectable = true;
            // 
            // fieldsPanel
            // 
            this.fieldsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsPanel.AutoScroll = true;
            this.fieldsPanel.HorizontalScrollbar = true;
            this.fieldsPanel.HorizontalScrollbarBarColor = true;
            this.fieldsPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.fieldsPanel.HorizontalScrollbarSize = 10;
            this.fieldsPanel.Location = new System.Drawing.Point(11, 73);
            this.fieldsPanel.Name = "fieldsPanel";
            this.fieldsPanel.Size = new System.Drawing.Size(609, 321);
            this.fieldsPanel.TabIndex = 3;
            this.fieldsPanel.VerticalScrollbar = true;
            this.fieldsPanel.VerticalScrollbarBarColor = true;
            this.fieldsPanel.VerticalScrollbarHighlightOnWheel = false;
            this.fieldsPanel.VerticalScrollbarSize = 10;
            // 
            // WorkItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 435);
            this.Controls.Add(this.fieldsPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CreateBtn);
            this.MinimumSize = new System.Drawing.Size(553, 418);
            this.Name = "WorkItemDetails";
            this.Text = "Work Item Details";
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton CreateBtn;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroPanel fieldsPanel;
    }
}