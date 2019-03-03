namespace Stock_managemt
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.stsTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.mnsFix = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsStock = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsProductout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsReport_Stock = new System.Windows.Forms.ToolStripMenuItem();
            this.ອອກຈາກໂປແກຣມToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timTime = new System.Windows.Forms.Timer(this.components);
            this.stsStatus.SuspendLayout();
            this.mnsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsStatus
            // 
            this.stsStatus.AutoSize = false;
            this.stsStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsTitle,
            this.toolStripStatusLabel1,
            this.stsTime});
            this.stsStatus.Location = new System.Drawing.Point(0, 428);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(800, 22);
            this.stsStatus.TabIndex = 0;
            this.stsStatus.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // stsTitle
            // 
            this.stsTitle.Name = "stsTitle";
            this.stsTitle.Size = new System.Drawing.Size(60, 17);
            this.stsTitle.Text = "KhomSoft";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(300, 17);
            this.toolStripStatusLabel1.Text = "Admin";
            // 
            // stsTime
            // 
            this.stsTime.AutoSize = false;
            this.stsTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stsTime.ForeColor = System.Drawing.Color.Red;
            this.stsTime.Name = "stsTime";
            this.stsTime.Size = new System.Drawing.Size(200, 17);
            // 
            // mnsMenu
            // 
            this.mnsMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnsMenu.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsFix,
            this.mnsDoc,
            this.mnsReport,
            this.ອອກຈາກໂປແກຣມToolStripMenuItem,
            this.toolStripMenuItem1});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Size = new System.Drawing.Size(800, 33);
            this.mnsMenu.TabIndex = 1;
            this.mnsMenu.Text = "menuStrip1";
            // 
            // mnsFix
            // 
            this.mnsFix.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsUser,
            this.mnsUnit,
            this.mnsStock,
            this.mnsProduct});
            this.mnsFix.Name = "mnsFix";
            this.mnsFix.Size = new System.Drawing.Size(79, 29);
            this.mnsFix.Text = "ກຳນົດຄ່າ";
            this.mnsFix.Click += new System.EventHandler(this.mnsFix_Click);
            // 
            // mnsUser
            // 
            this.mnsUser.Image = global::Stock_managemt.Properties.Resources.users;
            this.mnsUser.Name = "mnsUser";
            this.mnsUser.Size = new System.Drawing.Size(180, 30);
            this.mnsUser.Text = "ກຳນົດສິດຜູ້ໃຊ້";
            this.mnsUser.Click += new System.EventHandler(this.mnsUser_Click);
            // 
            // mnsUnit
            // 
            this.mnsUnit.Image = ((System.Drawing.Image)(resources.GetObject("mnsUnit.Image")));
            this.mnsUnit.Name = "mnsUnit";
            this.mnsUnit.Size = new System.Drawing.Size(180, 30);
            this.mnsUnit.Text = "ຫົວໜ່ວຍສີ້ນຄ້າ";
            // 
            // mnsStock
            // 
            this.mnsStock.Image = ((System.Drawing.Image)(resources.GetObject("mnsStock.Image")));
            this.mnsStock.Name = "mnsStock";
            this.mnsStock.Size = new System.Drawing.Size(180, 30);
            this.mnsStock.Text = "ສາງສີ້ນຄ້າ";
            // 
            // mnsProduct
            // 
            this.mnsProduct.Image = ((System.Drawing.Image)(resources.GetObject("mnsProduct.Image")));
            this.mnsProduct.Name = "mnsProduct";
            this.mnsProduct.Size = new System.Drawing.Size(180, 30);
            this.mnsProduct.Text = "ສີ້ນຄ້າ";
            // 
            // mnsDoc
            // 
            this.mnsDoc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsInvoice,
            this.mnsProductout});
            this.mnsDoc.Name = "mnsDoc";
            this.mnsDoc.Size = new System.Drawing.Size(126, 29);
            this.mnsDoc.Text = "ກຳກັບເອກະສານ";
            this.mnsDoc.Click += new System.EventHandler(this.mnsDoc_Click);
            // 
            // mnsInvoice
            // 
            this.mnsInvoice.Image = ((System.Drawing.Image)(resources.GetObject("mnsInvoice.Image")));
            this.mnsInvoice.Name = "mnsInvoice";
            this.mnsInvoice.Size = new System.Drawing.Size(148, 30);
            this.mnsInvoice.Text = "ຮັບສີ້ນຄ້າ";
            this.mnsInvoice.Click += new System.EventHandler(this.mnsInvoice_Click);
            // 
            // mnsProductout
            // 
            this.mnsProductout.Image = ((System.Drawing.Image)(resources.GetObject("mnsProductout.Image")));
            this.mnsProductout.Name = "mnsProductout";
            this.mnsProductout.Size = new System.Drawing.Size(148, 30);
            this.mnsProductout.Text = "ເບີກສີ້ນຄ້າ";
            // 
            // mnsReport
            // 
            this.mnsReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsReport_Stock});
            this.mnsReport.Name = "mnsReport";
            this.mnsReport.Size = new System.Drawing.Size(75, 29);
            this.mnsReport.Text = "ລາຍງານ";
            // 
            // mnsReport_Stock
            // 
            this.mnsReport_Stock.Image = ((System.Drawing.Image)(resources.GetObject("mnsReport_Stock.Image")));
            this.mnsReport_Stock.Name = "mnsReport_Stock";
            this.mnsReport_Stock.Size = new System.Drawing.Size(278, 30);
            this.mnsReport_Stock.Text = "ລາຍງານສະຫຼຸບສີ້ນຄ້າຄ້າງໃນສາງ";
            // 
            // ອອກຈາກໂປແກຣມToolStripMenuItem
            // 
            this.ອອກຈາກໂປແກຣມToolStripMenuItem.Name = "ອອກຈາກໂປແກຣມToolStripMenuItem";
            this.ອອກຈາກໂປແກຣມToolStripMenuItem.Size = new System.Drawing.Size(144, 29);
            this.ອອກຈາກໂປແກຣມToolStripMenuItem.Text = "ອອກຈາກໂປແກຣມ";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 29);
            // 
            // timTime
            // 
            this.timTime.Enabled = true;
            this.timTime.Interval = 1000;
            this.timTime.Tick += new System.EventHandler(this.timTime_Tick);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.mnsMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsMenu;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "khomStock1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.Timer timTime;
        private System.Windows.Forms.ToolStripMenuItem mnsFix;
        private System.Windows.Forms.ToolStripMenuItem mnsUser;
        private System.Windows.Forms.ToolStripMenuItem mnsUnit;
        private System.Windows.Forms.ToolStripMenuItem mnsStock;
        private System.Windows.Forms.ToolStripMenuItem mnsProduct;
        private System.Windows.Forms.ToolStripMenuItem mnsDoc;
        private System.Windows.Forms.ToolStripMenuItem mnsInvoice;
        private System.Windows.Forms.ToolStripMenuItem mnsProductout;
        private System.Windows.Forms.ToolStripMenuItem mnsReport;
        private System.Windows.Forms.ToolStripMenuItem mnsReport_Stock;
        private System.Windows.Forms.ToolStripMenuItem ອອກຈາກໂປແກຣມToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel stsTitle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel stsTime;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

