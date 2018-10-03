using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Soko.Models
{
    class Player : BlockBase
    {
        int movesCount;
        short increment;
        //public Position playerPos;
        //public System.Windows.Forms.TextBox playerObj;

        public Player(short _increment) : base("player.jpg",new Point(0,0), "player")
        {
            this.increment = _increment;
            this.movesCount = 0;
            this.rigidBody = true;

        }

        public void SetStartPosition(Point _startPosition)
        {
            this.Picture.Location = _startPosition;
            //this.playerPos = new Position((short)(_startPosition.X / 30),
            //                              (short)(_startPosition.Y / 30));

        }
        internal override void MoveUP()
        {
            base.MoveUP();
            //this.playerObj.Location = new Point(this.playerObj.Location.X,
            //                                    this.playerObj.Location.Y - this.increment);
            this.movesCount++;
            //this.playerPos.MoveVertical((float)-0.5);

        }
        internal override void MoveDown()
        {
            base.MoveDown();
            //this.playerObj.Location = new Point(this.playerObj.Location.X,
            //                                    this.playerObj.Location.Y + this.increment);
            this.movesCount++;
            //this.playerPos.MoveVertical((float)0.5);
        }
        internal override void MoveLeft()
        {
            base.MoveLeft();
            //this.playerObj.Location = new Point(this.playerObj.Location.X - this.increment,
            //                                    this.playerObj.Location.Y);
            this.movesCount++;
            //this.playerPos.MoveHorizontal((float)-0.5);
        }
        internal override void MoveRight()
        {
            base.MoveRight();
            //this.playerObj.Location = new Point(this.playerObj.Location.X + this.increment,
            //                                    this.playerObj.Location.Y);
            this.movesCount++;
            //this.playerPos.MoveHorizontal((float)0.5);
        }
    }

    //internal class Position
    //{
    //    float x, y;//0 based
    //    public float X
    //    {
    //        get { return this.x; }
    //    }
    //    public float Y
    //    {
    //        get { return this.y; }
    //    }
    //    public Position(short _x, short _y)
    //    {
    //        this.x = _x;
    //        this.y = _y;
    //    }

    //    internal void MoveHorizontal(float _inc)
    //    {
    //        this.x += _inc;
    //    }
    //    internal void MoveVertical(float _inc)
    //    {
    //        this.y += _inc;
    //    }

    //    // essa funcao incrementa/diminui 0,5 quando for movimento horizontal
    //    // e incrementa/diminui 0,5 quando for movimento vertical.
    //}
}
