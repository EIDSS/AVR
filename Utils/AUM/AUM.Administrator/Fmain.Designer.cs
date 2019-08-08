namespace AUM.Administrator
{
    partial class Fmain
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fmain));
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.panelLeft = new System.Windows.Forms.Panel();
      this.tvComputers = new System.Windows.Forms.TreeView();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsbSortByCompName = new System.Windows.Forms.ToolStripButton();
      this.tspSortByStatus = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbLaunchUpdate = new System.Windows.Forms.ToolStripButton();
      this.panelRight = new System.Windows.Forms.Panel();
      this.gbLogContent = new System.Windows.Forms.GroupBox();
      this.tbLogContent = new AUM.Administrator.RichEditWithSmartCursorAndScroll();
      this.pUpdateInfo = new System.Windows.Forms.Panel();
      this.lDatetime = new System.Windows.Forms.Label();
      this.lStatus = new System.Windows.Forms.Label();
      this.gbTotalUpdates = new System.Windows.Forms.GroupBox();
      this.tvTotalUpdates = new System.Windows.Forms.TreeView();
      this.gbCommon = new System.Windows.Forms.GroupBox();
      this.lbReplicationStatus = new System.Windows.Forms.Label();
      this.bReplicate = new System.Windows.Forms.Button();
      this.cbAutoRefresh = new System.Windows.Forms.CheckBox();
      this.labelComputer = new System.Windows.Forms.Label();
      this.bRefresh = new System.Windows.Forms.Button();
      this.labelCountry = new System.Windows.Forms.Label();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.timerAutoRefresh = new System.Windows.Forms.Timer(this.components);
      this.panelLeft.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.panelRight.SuspendLayout();
      this.gbLogContent.SuspendLayout();
      this.pUpdateInfo.SuspendLayout();
      this.gbTotalUpdates.SuspendLayout();
      this.gbCommon.SuspendLayout();
      this.SuspendLayout();
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "Server Online.png");
      this.imageList1.Images.SetKeyName(1, "Server Error.png");
      this.imageList1.Images.SetKeyName(2, "Server Help.png");
      // 
      // panelLeft
      // 
      this.panelLeft.Controls.Add(this.tvComputers);
      this.panelLeft.Controls.Add(this.toolStrip1);
      resources.ApplyResources(this.panelLeft, "panelLeft");
      this.panelLeft.Name = "panelLeft";
      // 
      // tvComputers
      // 
      resources.ApplyResources(this.tvComputers, "tvComputers");
      this.tvComputers.ImageList = this.imageList1;
      this.tvComputers.Name = "tvComputers";
      this.tvComputers.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnTvComputersNodeMouseClick);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSortByCompName,
            this.tspSortByStatus,
            this.toolStripSeparator1,
            this.tsbLaunchUpdate});
      resources.ApplyResources(this.toolStrip1, "toolStrip1");
      this.toolStrip1.Name = "toolStrip1";
      // 
      // tsbSortByCompName
      // 
      this.tsbSortByCompName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.tsbSortByCompName, "tsbSortByCompName");
      this.tsbSortByCompName.Name = "tsbSortByCompName";
      this.tsbSortByCompName.Click += new System.EventHandler(this.tsbSortByCompName_Click);
      // 
      // tspSortByStatus
      // 
      this.tspSortByStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.tspSortByStatus, "tspSortByStatus");
      this.tspSortByStatus.Name = "tspSortByStatus";
      this.tspSortByStatus.Click += new System.EventHandler(this.tspSortByStatus_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // tsbLaunchUpdate
      // 
      this.tsbLaunchUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.tsbLaunchUpdate, "tsbLaunchUpdate");
      this.tsbLaunchUpdate.Name = "tsbLaunchUpdate";
      this.tsbLaunchUpdate.Click += new System.EventHandler(this.tsbLaunchUpdate_Click);
      // 
      // panelRight
      // 
      this.panelRight.Controls.Add(this.gbLogContent);
      this.panelRight.Controls.Add(this.pUpdateInfo);
      this.panelRight.Controls.Add(this.gbTotalUpdates);
      this.panelRight.Controls.Add(this.gbCommon);
      resources.ApplyResources(this.panelRight, "panelRight");
      this.panelRight.Name = "panelRight";
      // 
      // gbLogContent
      // 
      this.gbLogContent.Controls.Add(this.tbLogContent);
      resources.ApplyResources(this.gbLogContent, "gbLogContent");
      this.gbLogContent.Name = "gbLogContent";
      this.gbLogContent.TabStop = false;
      // 
      // tbLogContent
      // 
      this.tbLogContent.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.tbLogContent, "tbLogContent");
      this.tbLogContent.Name = "tbLogContent";
      this.tbLogContent.ReadOnly = true;
      // 
      // pUpdateInfo
      // 
      this.pUpdateInfo.Controls.Add(this.lDatetime);
      this.pUpdateInfo.Controls.Add(this.lStatus);
      resources.ApplyResources(this.pUpdateInfo, "pUpdateInfo");
      this.pUpdateInfo.Name = "pUpdateInfo";
      // 
      // lDatetime
      // 
      resources.ApplyResources(this.lDatetime, "lDatetime");
      this.lDatetime.Name = "lDatetime";
      this.lDatetime.Visible = false;

      // 
      // lStatus
      // 
      resources.ApplyResources(this.lStatus, "lStatus");
      this.lStatus.Name = "lStatus";
      // 
      // gbTotalUpdates
      // 
      this.gbTotalUpdates.Controls.Add(this.tvTotalUpdates);
      resources.ApplyResources(this.gbTotalUpdates, "gbTotalUpdates");
      this.gbTotalUpdates.Name = "gbTotalUpdates";
      this.gbTotalUpdates.TabStop = false;
      // 
      // tvTotalUpdates
      // 
      resources.ApplyResources(this.tvTotalUpdates, "tvTotalUpdates");
      this.tvTotalUpdates.ImageList = this.imageList1;
      this.tvTotalUpdates.Name = "tvTotalUpdates";
      this.tvTotalUpdates.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTvTotalUpdatesAfterSelect);
      // 
      // gbCommon
      // 
      this.gbCommon.Controls.Add(this.lbReplicationStatus);
      this.gbCommon.Controls.Add(this.bReplicate);
      this.gbCommon.Controls.Add(this.cbAutoRefresh);
      this.gbCommon.Controls.Add(this.labelComputer);
      this.gbCommon.Controls.Add(this.bRefresh);
      this.gbCommon.Controls.Add(this.labelCountry);
      resources.ApplyResources(this.gbCommon, "gbCommon");
      this.gbCommon.Name = "gbCommon";
      this.gbCommon.TabStop = false;
      // 
      // lbReplicationStatus
      // 
      resources.ApplyResources(this.lbReplicationStatus, "lbReplicationStatus");
      this.lbReplicationStatus.Name = "lbReplicationStatus";
      this.lbReplicationStatus.Click += new System.EventHandler(this.lbReplicationStatus_Click);
      // 
      // bReplicate
      // 
      resources.ApplyResources(this.bReplicate, "bReplicate");
      this.bReplicate.Name = "bReplicate";
      this.bReplicate.UseVisualStyleBackColor = true;
      this.bReplicate.Click += new System.EventHandler(this.bReplicate_Click);
      // 
      // cbAutoRefresh
      // 
      resources.ApplyResources(this.cbAutoRefresh, "cbAutoRefresh");
      this.cbAutoRefresh.Checked = true;
      this.cbAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbAutoRefresh.Name = "cbAutoRefresh";
      this.cbAutoRefresh.UseVisualStyleBackColor = true;
      this.cbAutoRefresh.CheckedChanged += new System.EventHandler(this.cbAutoRefresh_CheckedChanged);
      // 
      // labelComputer
      // 
      resources.ApplyResources(this.labelComputer, "labelComputer");
      this.labelComputer.Name = "labelComputer";
      // 
      // bRefresh
      // 
      resources.ApplyResources(this.bRefresh, "bRefresh");
      this.bRefresh.Name = "bRefresh";
      this.bRefresh.UseVisualStyleBackColor = true;
      this.bRefresh.Click += new System.EventHandler(this.OnBRefreshClick);
      // 
      // labelCountry
      // 
      resources.ApplyResources(this.labelCountry, "labelCountry");
      this.labelCountry.Name = "labelCountry";
      // 
      // splitter1
      // 
      resources.ApplyResources(this.splitter1, "splitter1");
      this.splitter1.Name = "splitter1";
      this.splitter1.TabStop = false;
      // 
      // timerAutoRefresh
      // 
      this.timerAutoRefresh.Tick += new System.EventHandler(this.timerAutoRefresh_Tick);
      // 
      // Fmain
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.panelRight);
      this.Controls.Add(this.panelLeft);
      this.Name = "Fmain";
      this.panelLeft.ResumeLayout(false);
      this.panelLeft.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.panelRight.ResumeLayout(false);
      this.gbLogContent.ResumeLayout(false);
      this.pUpdateInfo.ResumeLayout(false);
      this.pUpdateInfo.PerformLayout();
      this.gbTotalUpdates.ResumeLayout(false);
      this.gbCommon.ResumeLayout(false);
      this.gbCommon.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TreeView tvComputers;
        private System.Windows.Forms.ToolStripButton tsbSortByCompName;
        private System.Windows.Forms.ToolStripButton tspSortByStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLaunchUpdate;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox gbLogContent;
        private AUM.Administrator.RichEditWithSmartCursorAndScroll tbLogContent;
        private System.Windows.Forms.Panel pUpdateInfo;
        private System.Windows.Forms.Label lDatetime;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.GroupBox gbTotalUpdates;
        private System.Windows.Forms.TreeView tvTotalUpdates;
        private System.Windows.Forms.GroupBox gbCommon;
        private System.Windows.Forms.Label labelComputer;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.CheckBox cbAutoRefresh;
        private System.Windows.Forms.Timer timerAutoRefresh;
        private System.Windows.Forms.Button bReplicate;
        private System.Windows.Forms.Label lbReplicationStatus;
    }
}

