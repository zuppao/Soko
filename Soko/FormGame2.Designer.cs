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
            this.panelGame = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPlayer = new System.Windows.Forms.Label();
            this.tbCurrentRigid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.Location = new System.Drawing.Point(16, 15);
            this.panelGame.Margin = new System.Windows.Forms.Padding(4);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(1000, 554);
            this.panelGame.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1057, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player";
            // 
            // lbPlayer
            // 
            this.lbPlayer.AutoSize = true;
            this.lbPlayer.Location = new System.Drawing.Point(1136, 42);
            this.lbPlayer.Name = "lbPlayer";
            this.lbPlayer.Size = new System.Drawing.Size(57, 17);
            this.lbPlayer.TabIndex = 2;
            this.lbPlayer.Text = "location";
            // 
            // tbCurrentRigid
            // 
            this.tbCurrentRigid.Enabled = false;
            this.tbCurrentRigid.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurrentRigid.Location = new System.Drawing.Point(1060, 234);
            this.tbCurrentRigid.Multiline = true;
            this.tbCurrentRigid.Name = "tbCurrentRigid";
            this.tbCurrentRigid.ReadOnly = true;
            this.tbCurrentRigid.Size = new System.Drawing.Size(350, 335);
            this.tbCurrentRigid.TabIndex = 3;
            // 
            // FormGame2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 666);
            this.Controls.Add(this.tbCurrentRigid);
            this.Controls.Add(this.lbPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelGame);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGame2";
            this.Text = "FormGame2";
            this.Load += new System.EventHandler(this.FormGame2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame2_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPlayer;
        private System.Windows.Forms.TextBox tbCurrentRigid;
    }
}