using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Soko.Models
{
    abstract class BlockBase : System.Windows.Forms.Control
    {
        internal bool rigidBody;
        public static short Increment = 0;


        private System.Windows.Forms.PictureBox pictureBox;

        public System.Windows.Forms.PictureBox Picture
        {
            get { return this.pictureBox; }
        }

        public bool RigidBody
        {
            get { return this.rigidBody; }
        }


        public BlockBase(string _imgName, Point _startPosition, string _tag)
        {
            this.rigidBody = false;
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Resources\\" + _imgName);
            this.pictureBox.Size = new Size(30, 30);
            this.pictureBox.Location = _startPosition;
            this.pictureBox.Tag = _tag;
        }

        internal virtual void MoveUP()
        {
            this.pictureBox.Location = new Point(this.pictureBox.Location.X,
                                                this.pictureBox.Location.Y - BlockBase.Increment);
        }
        internal virtual void MoveDown()
        {
            this.pictureBox.Location = new Point(this.pictureBox.Location.X,
                                                this.pictureBox.Location.Y + BlockBase.Increment);
        }
        internal virtual void MoveLeft()
        {
            this.pictureBox.Location = new Point(this.pictureBox.Location.X - BlockBase.Increment,
                                                this.pictureBox.Location.Y);
        }
        internal virtual void MoveRight()
        {
            this.pictureBox.Location = new Point(this.pictureBox.Location.X + BlockBase.Increment,
                                                this.pictureBox.Location.Y);
        }

    }
}
