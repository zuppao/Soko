using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Soko.Models
{
    class Box : BlockBase
    {
        public Box(Point _startPosition) : base("box.jpg", _startPosition, "box")
        {
            this.rigidBody = true;
        }
    }
}
