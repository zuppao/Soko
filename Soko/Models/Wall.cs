using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Soko.Models
{
    class Wall : BlockBase
    {


        public Wall(Point _startPosition) : base("wall.jpg", _startPosition, "#")
        {
            this.rigidBody = true;
        }



    }
}
