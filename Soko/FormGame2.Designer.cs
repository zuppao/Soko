namespace Soko
{
    partial class FormGame2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame2));
            this.panelGame = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatusCurrentLevel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatusTotalLevels = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatusMoves = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatusPushes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btNewGame = new System.Windows.Forms.ToolStripButton();
            this.btLoad = new System.Windows.Forms.ToolStripButton();
            this.btSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btUndo = new System.Windows.Forms.ToolStripButton();
            this.btRestartLevel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btHelp = new System.Windows.Forms.ToolStripButton();
            this.panelGame.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGame.AutoSize = true;
            this.panelGame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelGame.Controls.Add(this.button1);
            this.panelGame.Location = new System.Drawing.Point(9, 60);
            this.panelGame.Margin = new System.Windows.Forms.Padding(0);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(516, 202);
            this.panelGame.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbStatusCurrentLevel,
            this.lbStatusTotalLevels,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lbStatusMoves,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.lbStatusPushes});
            this.statusStrip1.Location = new System.Drawing.Point(0, 778);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1182, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 20);
            this.toolStripStatusLabel1.Text = "Level:";
            // 
            // lbStatusCurrentLevel
            // 
            this.lbStatusCurrentLevel.Name = "lbStatusCurrentLevel";
            this.lbStatusCurrentLevel.Size = new System.Drawing.Size(25, 20);
            this.lbStatusCurrentLevel.Text = "00";
            // 
            // lbStatusTotalLevels
            // 
            this.lbStatusTotalLevels.Name = "lbStatusTotalLevels";
            this.lbStatusTotalLevels.Size = new System.Drawing.Size(35, 20);
            this.lbStatusTotalLevels.Text = "/ 00";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(55, 20);
            this.toolStripStatusLabel3.Text = "Moves:";
            // 
            // lbStatusMoves
            // 
            this.lbStatusMoves.Name = "lbStatusMoves";
            this.lbStatusMoves.Size = new System.Drawing.Size(57, 20);
            this.lbStatusMoves.Text = "000000";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(56, 20);
            this.toolStripStatusLabel5.Text = "Pushes:";
            // 
            // lbStatusPushes
            // 
            this.lbStatusPushes.Name = "lbStatusPushes";
            this.lbStatusPushes.Size = new System.Drawing.Size(57, 20);
            this.lbStatusPushes.Text = "000000";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNewGame,
            this.btLoad,
            this.btSave,
            this.toolStripSeparator1,
            this.btUndo,
            this.btRestartLevel,
            this.toolStripSeparator2,
            this.btHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1182, 47);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btNewGame
            // 
            this.btNewGame.Image = ((System.Drawing.Image)(resources.GetObject("btNewGame.Image")));
            this.btNewGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNewGame.Name = "btNewGame";
            this.btNewGame.Size = new System.Drawing.Size(43, 44);
            this.btNewGame.Text = "&New";
            this.btNewGame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btLoad
            // 
            this.btLoad.Image = ((System.Drawing.Image)(resources.GetObject("btLoad.Image")));
            this.btLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(46, 44);
            this.btLoad.Text = "&Load";
            this.btLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btSave
            // 
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(44, 44);
            this.btSave.Text = "&Save";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // btUndo
            // 
            this.btUndo.Image = ((System.Drawing.Image)(resources.GetObject("btUndo.Image")));
            this.btUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(49, 44);
            this.btUndo.Text = "&Undo";
            this.btUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
            // 
            // btRestartLevel
            // 
            this.btRestartLevel.Image = ((System.Drawing.Image)(resources.GetObject("btRestartLevel.Image")));
            this.btRestartLevel.ImageTransparentColor = System.Drawing.Color.Black;
            this.btRestartLevel.Name = "btRestartLevel";
            this.btRestartLevel.Size = new System.Drawing.Size(97, 44);
            this.btRestartLevel.Text = "&Restart Level";
            this.btRestartLevel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btRestartLevel.Click += new System.EventHandler(this.btRestartLevel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // btHelp
            // 
            this.btHelp.Image = ((System.Drawing.Image)(resources.GetObject("btHelp.Image")));
            this.btHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btHelp.Name = "btHelp";
            this.btHelp.Size = new System.Drawing.Size(45, 44);
            this.btHelp.Text = "&Help";
            this.btHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btHelp.Click += new System.EventHandler(this.btHelp_Click);
            // 
            // FormGame2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 803);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelGame);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGame2";
            this.Text = "Sokoban";
            this.Load += new System.EventHandler(this.FormGame2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame2_KeyDown);
            this.panelGame.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusCurrentLevel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusMoves;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusPushes;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusTotalLevels;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btRestartLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btHelp;
        private System.Windows.Forms.ToolStripButton btNewGame;
        private System.Windows.Forms.ToolStripButton btLoad;
        private System.Windows.Forms.ToolStripButton btSave;
    }
}