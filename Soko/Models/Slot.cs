using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Soko.Models 
{
    class Slot : BlockBase
    {

        public Slot(Point _startPosition) : base("slot.png", _startPosition, "S")
        {
        }
    }
}
