using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Soko.Models
{
    [Serializable]
    class Player : BlockBase
    {
        private int movesCount;
        private short increment;
        Point lastPlayerLocation;
        internal int MovesCount
        {
            get { return this.movesCount; }
            set { this.movesCount = value; }
        }
        
        public Player(short _increment) : base("player.jpg", new Point(0, 0), "P")
        {
            this.increment = _increment;
            this.movesCount = 0;
            this.rigidBody = true;

        }

        public void SetStartPosition(Point _startPosition)
        {
            this.Picture.Location = _startPosition;
            this.lastPlayerLocation = _startPosition;
        }
        internal void ResetMovesCount()
        {
            this.movesCount = 0;
        }
        internal void Undo()
        {
            if (this.Picture.Location != this.lastPlayerLocation)
            {
                this.SetStartPosition(this.lastPlayerLocation);
                this.movesCount++;
            }
        }

        internal override void MoveUP()
        {
            this.lastPlayerLocation = this.Picture.Location;
            base.MoveUP();
            this.movesCount++;

        }
        internal override void MoveDown()
        {
            this.lastPlayerLocation = this.Picture.Location;
            base.MoveDown();
            this.movesCount++;
        }
        internal override void MoveLeft()
        {
            this.lastPlayerLocation = this.Picture.Location;
            base.MoveLeft();
            this.movesCount++;
        }
        internal override void MoveRight()
        {
            this.lastPlayerLocation = this.Picture.Location;
            base.MoveRight();
            this.movesCount++;
        }
    }

    
}
