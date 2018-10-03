using Soko.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Soko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //FormGame fGame = new FormGame();
            ////foreach (string lvPath in Directory.GetFiles("Levels"))
            ////{
            ////    fGame.LevelsPath.Add(lvPath);
            ////}
            //this.Visible = false;
            //fGame.ShowDialog();
            //this.Close();
            //Control[] ctrls = this.panel1.Controls.Find("imgPlayer", true);
            //ctrls[0].BringToFront();

            FormGame2 fGame = new FormGame2();
            this.Visible = false;
            fGame.ShowDialog();
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    this.imgPlayer.Location = new Point(this.imgPlayer.Location.X + 15, this.imgPlayer.Location.Y);
                    break;
                case Keys.Left:
                    this.imgPlayer.Location = new Point(this.imgPlayer.Location.X - 15, this.imgPlayer.Location.Y);
                    break;
                case Keys.Up:
                    this.imgPlayer.Location = new Point(this.imgPlayer.Location.X, this.imgPlayer.Location.Y - 15);
                    break;
                case Keys.Down:
                    this.imgPlayer.Location = new Point(this.imgPlayer.Location.X, this.imgPlayer.Location.Y + 15);
                    break;
                default:
                    break;
            }



        }
    }
}
