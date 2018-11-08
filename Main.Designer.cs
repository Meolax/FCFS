namespace FCFS
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
        private void InitializeComponent ()
        {
            this.dataGridMain = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Te = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExectTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridAvgTime = new System.Windows.Forms.DataGridView();
            this.Tw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMain)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAvgTime)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridMain
            // 
            this.dataGridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Tc,
            this.Te,
            this.WaitingTime,
            this.ExectTime});
            this.dataGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridMain.Location = new System.Drawing.Point(0, 28);
            this.dataGridMain.Name = "dataGridMain";
            this.dataGridMain.RowTemplate.Height = 24;
            this.dataGridMain.Size = new System.Drawing.Size(683, 495);
            this.dataGridMain.TabIndex = 0;
            this.dataGridMain.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // Tc
            // 
            this.Tc.HeaderText = "Tc";
            this.Tc.Name = "Tc";
            // 
            // Te
            // 
            this.Te.HeaderText = "Te";
            this.Te.Name = "Te";
            // 
            // WaitingTime
            // 
            this.WaitingTime.HeaderText = "WaitingTime";
            this.WaitingTime.Name = "WaitingTime";
            this.WaitingTime.ReadOnly = true;
            // 
            // ExectTime
            // 
            this.ExectTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ExectTime.HeaderText = "Exect Time";
            this.ExectTime.Name = "ExectTime";
            this.ExectTime.ReadOnly = true;
            this.ExectTime.Width = 106;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.checkTableToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(683, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // checkTableToolStripMenuItem
            // 
            this.checkTableToolStripMenuItem.Name = "checkTableToolStripMenuItem";
            this.checkTableToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.checkTableToolStripMenuItem.Text = "Check Table";
            this.checkTableToolStripMenuItem.Click += new System.EventHandler(this.checkTableToolStripMenuItem_Click);
            // 
            // dataGridAvgTime
            // 
            this.dataGridAvgTime.AllowUserToAddRows = false;
            this.dataGridAvgTime.AllowUserToDeleteRows = false;
            this.dataGridAvgTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAvgTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tw,
            this.Tex});
            this.dataGridAvgTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridAvgTime.Location = new System.Drawing.Point(0, 523);
            this.dataGridAvgTime.Name = "dataGridAvgTime";
            this.dataGridAvgTime.ReadOnly = true;
            this.dataGridAvgTime.RowTemplate.Height = 24;
            this.dataGridAvgTime.Size = new System.Drawing.Size(683, 65);
            this.dataGridAvgTime.TabIndex = 2;
            // 
            // Tw
            // 
            this.Tw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tw.Frozen = true;
            this.Tw.HeaderText = "<Tw>";
            this.Tw.Name = "Tw";
            this.Tw.ReadOnly = true;
            this.Tw.Width = 71;
            // 
            // Tex
            // 
            this.Tex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tex.Frozen = true;
            this.Tex.HeaderText = "<Tex>";
            this.Tex.Name = "Tex";
            this.Tex.ReadOnly = true;
            this.Tex.Width = 76;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 588);
            this.Controls.Add(this.dataGridMain);
            this.Controls.Add(this.dataGridAvgTime);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMain)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAvgTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkTableToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Te;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExectTime;
        private System.Windows.Forms.DataGridView dataGridAvgTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tw;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tex;
    }
}

