using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Soko.Models
{
    class Box : BlockBase
    {
        Point lastBoxLocation;
        public Box(Point _startPosition) : base("box.jpg", _startPosition, "B")
        {
            this.rigidBody = true;
            this.lastBoxLocation = _startPosition;
        }

        internal void Undo()
        {
            if (this.Picture.Location != this.lastBoxLocation)
            {
                this.Picture.Location = this.lastBoxLocation;
            }
        }


        internal override void MoveUP()
        {
            this.lastBoxLocation = this.Picture.Location;
            base.MoveUP();
        }
        internal override void MoveDown()
        {
            this.lastBoxLocation = this.Picture.Location;
            base.MoveDown();
        }
        internal override void MoveLeft()
        {
            this.lastBoxLocation = this.Picture.Location;
            base.MoveLeft();
        }
        internal override void MoveRight()
        {
            this.lastBoxLocation = this.Picture.Location;
            base.MoveRight();
        }

    }
}
