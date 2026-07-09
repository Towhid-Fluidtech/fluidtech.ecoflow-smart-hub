namespace FluidtechSmartHub
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.leftPanel = new System.Windows.Forms.Panel();
            this.assetTreeView = new System.Windows.Forms.TreeView();
            this.accentLinePanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoSubLabel = new System.Windows.Forms.Label();
            this.logoLabel = new System.Windows.Forms.Label();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.centerTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.lblDocPath = new System.Windows.Forms.Label();
            this.buttonContainer = new System.Windows.Forms.Panel();
            this.btnOpenDoc = new System.Windows.Forms.Button();
            this.lblDocInfo = new System.Windows.Forms.Label();
            this.lblDocDesc = new System.Windows.Forms.Label();
            this.lblDocName = new System.Windows.Forms.Label();
            this.previewIconLabel = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.leftPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.containerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.previewPanel.SuspendLayout();
            this.centerTableLayout.SuspendLayout();
            this.cardPanel.SuspendLayout();
            this.buttonContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(44)))), ((int)(((byte)(97)))));
            this.leftPanel.Controls.Add(this.assetTreeView);
            this.leftPanel.Controls.Add(this.accentLinePanel);
            this.leftPanel.Controls.Add(this.logoPanel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(320, 729);
            this.leftPanel.TabIndex = 0;
            // 
            // assetTreeView
            // 
            this.assetTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(44)))), ((int)(((byte)(97)))));
            this.assetTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.assetTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetTreeView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.assetTreeView.ForeColor = System.Drawing.Color.White;
            this.assetTreeView.FullRowSelect = true;
            this.assetTreeView.HideSelection = false;
            this.assetTreeView.HotTracking = true;
            this.assetTreeView.Indent = 16;
            this.assetTreeView.ItemHeight = 35;
            this.assetTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(171)))));
            this.assetTreeView.Location = new System.Drawing.Point(0, 83);
            this.assetTreeView.Name = "assetTreeView";
            this.assetTreeView.ShowLines = false;
            this.assetTreeView.ShowPlusMinus = false;
            this.assetTreeView.ShowRootLines = false;
            this.assetTreeView.Size = new System.Drawing.Size(320, 646);
            this.assetTreeView.TabIndex = 2;
            this.assetTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.assetTreeView_AfterSelect);
            // 
            // accentLinePanel
            // 
            this.accentLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(171)))));
            this.accentLinePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.accentLinePanel.Location = new System.Drawing.Point(0, 80);
            this.accentLinePanel.Name = "accentLinePanel";
            this.accentLinePanel.Size = new System.Drawing.Size(320, 3);
            this.accentLinePanel.TabIndex = 1;
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.logoPanel.Controls.Add(this.logoSubLabel);
            this.logoPanel.Controls.Add(this.logoLabel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(320, 80);
            this.logoPanel.TabIndex = 0;
            // 
            // logoSubLabel
            // 
            this.logoSubLabel.AutoSize = true;
            this.logoSubLabel.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.logoSubLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(171)))));
            this.logoSubLabel.Location = new System.Drawing.Point(16, 46);
            this.logoSubLabel.Name = "logoSubLabel";
            this.logoSubLabel.Size = new System.Drawing.Size(211, 12);
            this.logoSubLabel.TabIndex = 1;
            this.logoSubLabel.Text = "CREATIVE TECHNOLOGY & ENGINEERING";
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(12, 16);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(155, 30);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "FLUIDTECH";
            // 
            // containerPanel
            // 
            this.containerPanel.Controls.Add(this.webView);
            this.containerPanel.Controls.Add(this.previewPanel);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(320, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(944, 729);
            this.containerPanel.TabIndex = 1;
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(944, 729);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // previewPanel
            // 
            this.previewPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.previewPanel.Controls.Add(this.centerTableLayout);
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(0, 0);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(944, 729);
            this.previewPanel.TabIndex = 1;
            this.previewPanel.Visible = false;
            // 
            // centerTableLayout
            // 
            this.centerTableLayout.ColumnCount = 3;
            this.centerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.centerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.centerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.centerTableLayout.Controls.Add(this.cardPanel, 1, 1);
            this.centerTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerTableLayout.Location = new System.Drawing.Point(0, 0);
            this.centerTableLayout.Name = "centerTableLayout";
            this.centerTableLayout.RowCount = 3;
            this.centerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.centerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.centerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.centerTableLayout.Size = new System.Drawing.Size(944, 729);
            this.centerTableLayout.TabIndex = 0;
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.Color.White;
            this.cardPanel.Controls.Add(this.lblDocPath);
            this.cardPanel.Controls.Add(this.buttonContainer);
            this.cardPanel.Controls.Add(this.lblDocInfo);
            this.cardPanel.Controls.Add(this.lblDocDesc);
            this.cardPanel.Controls.Add(this.lblDocName);
            this.cardPanel.Controls.Add(this.previewIconLabel);
            this.cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPanel.Location = new System.Drawing.Point(144, 112);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Padding = new System.Windows.Forms.Padding(25);
            this.cardPanel.Size = new System.Drawing.Size(654, 504);
            this.cardPanel.TabIndex = 0;
            // 
            // lblDocPath
            // 
            this.lblDocPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDocPath.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblDocPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            this.lblDocPath.Location = new System.Drawing.Point(25, 290);
            this.lblDocPath.Name = "lblDocPath";
            this.lblDocPath.Size = new System.Drawing.Size(604, 109);
            this.lblDocPath.TabIndex = 5;
            this.lblDocPath.Text = "File Path...";
            this.lblDocPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonContainer
            // 
            this.buttonContainer.Controls.Add(this.btnOpenDoc);
            this.buttonContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonContainer.Location = new System.Drawing.Point(25, 399);
            this.buttonContainer.Name = "buttonContainer";
            this.buttonContainer.Size = new System.Drawing.Size(604, 80);
            this.buttonContainer.TabIndex = 4;
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpenDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(171)))));
            this.btnOpenDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenDoc.FlatAppearance.BorderSize = 0;
            this.btnOpenDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDoc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOpenDoc.ForeColor = System.Drawing.Color.White;
            this.btnOpenDoc.Location = new System.Drawing.Point(202, 18);
            this.btnOpenDoc.Name = "btnOpenDoc";
            this.btnOpenDoc.Size = new System.Drawing.Size(200, 45);
            this.btnOpenDoc.TabIndex = 0;
            this.btnOpenDoc.Text = "Open Document";
            this.btnOpenDoc.UseVisualStyleBackColor = false;
            this.btnOpenDoc.Click += new System.EventHandler(this.btnOpenDoc_Click);
            // 
            // lblDocInfo
            // 
            this.lblDocInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDocInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDocInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblDocInfo.Location = new System.Drawing.Point(25, 250);
            this.lblDocInfo.Name = "lblDocInfo";
            this.lblDocInfo.Size = new System.Drawing.Size(604, 40);
            this.lblDocInfo.TabIndex = 3;
            this.lblDocInfo.Text = "Format: Document | Size: 0 KB | Modified: Date";
            this.lblDocInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocDesc
            // 
            this.lblDocDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDocDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDocDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblDocDesc.Location = new System.Drawing.Point(25, 175);
            this.lblDocDesc.Name = "lblDocDesc";
            this.lblDocDesc.Size = new System.Drawing.Size(604, 75);
            this.lblDocDesc.TabIndex = 2;
            this.lblDocDesc.Text = "Description of the document goes here. This provides the customer with contextual" +
    " information before launching the external editor.";
            this.lblDocDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDocName
            // 
            this.lblDocName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDocName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblDocName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(44)))), ((int)(((byte)(97)))));
            this.lblDocName.Location = new System.Drawing.Point(25, 125);
            this.lblDocName.Name = "lblDocName";
            this.lblDocName.Size = new System.Drawing.Size(604, 50);
            this.lblDocName.TabIndex = 1;
            this.lblDocName.Text = "Document Name";
            this.lblDocName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewIconLabel
            // 
            this.previewIconLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.previewIconLabel.Font = new System.Drawing.Font("Segoe UI", 48F);
            this.previewIconLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(44)))), ((int)(((byte)(97)))));
            this.previewIconLabel.Location = new System.Drawing.Point(25, 25);
            this.previewIconLabel.Name = "previewIconLabel";
            this.previewIconLabel.Size = new System.Drawing.Size(604, 100);
            this.previewIconLabel.TabIndex = 0;
            this.previewIconLabel.Text = "📊";
            this.previewIconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(320, 707);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(944, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.leftPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fluidtech Smart Hub - Rashni Polyfiber Industries Ltd.";
            this.leftPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.logoPanel.PerformLayout();
            this.containerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.previewPanel.ResumeLayout(false);
            this.centerTableLayout.ResumeLayout(false);
            this.cardPanel.ResumeLayout(false);
            this.buttonContainer.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Label logoSubLabel;
        private System.Windows.Forms.Panel accentLinePanel;
        private System.Windows.Forms.TreeView assetTreeView;
        private System.Windows.Forms.Panel containerPanel;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.TableLayoutPanel centerTableLayout;
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Label previewIconLabel;
        private System.Windows.Forms.Label lblDocName;
        private System.Windows.Forms.Label lblDocDesc;
        private System.Windows.Forms.Label lblDocInfo;
        private System.Windows.Forms.Panel buttonContainer;
        private System.Windows.Forms.Button btnOpenDoc;
        private System.Windows.Forms.Label lblDocPath;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}
