namespace OutlookTFSAddIn
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon1));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.TFS = this.Factory.CreateRibbonGroup();
            this.bugBtn = this.Factory.CreateRibbonButton();
            this.PBIbtn = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.TFS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabMail";
            this.tab1.Groups.Add(this.TFS);
            this.tab1.Label = "TabMail";
            this.tab1.Name = "tab1";
            // 
            // TFS
            // 
            this.TFS.DialogLauncher = ribbonDialogLauncherImpl1;
            this.TFS.Items.Add(this.bugBtn);
            this.TFS.Items.Add(this.PBIbtn);
            this.TFS.Label = "TFS";
            this.TFS.Name = "TFS";
            this.TFS.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TFS_DialogLauncherClick);
            // 
            // bugBtn
            // 
            this.bugBtn.Label = "Create Bug";
            this.bugBtn.Name = "bugBtn";
            this.bugBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bugBtn_Click);
            // 
            // PBIbtn
            // 
            this.PBIbtn.Label = "Create PBI";
            this.PBIbtn.Name = "PBIbtn";
            this.PBIbtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.PBIbtn_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = resources.GetString("$this.RibbonType");
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.TFS.ResumeLayout(false);
            this.TFS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup TFS;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bugBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton PBIbtn;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
