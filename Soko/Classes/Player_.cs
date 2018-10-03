using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Soko.Classes
{
    public class Player_ : BoxPlace
    {
        private int moves;

        public int Moves
        {
            get { return this.moves; }
        }

        public Player_(short _position, Image _image, BoxTypeEnum _boxType, bool _rigidBody)
            : base(_position, _image, _boxType, _rigidBody)
        {

        }
        public Player_()
        {

        }

        public new void  MoveUp()
        {
            base.MoveUp();
        }
        public new void MoveDown()
        {
            base.MoveUp();
        }
        public new void MoveLeft()
        {
            base.MoveUp();
        }
        public new void MoveRight()
        {
            base.MoveUp();
        }
    }
}
