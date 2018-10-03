using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Soko.Classes
{
    public class BoxPlace: System.Windows.Forms.PictureBox
    {
        #region INFORMACOES
        //########################################################################
        // cada box tem 30x30 px
        // a tela tem 25x15 boxes (750x450 px)
        // a numeracao do POSITION segue o exemplo abaixo:
        //  1  2  3  4  5  6  7  8
        //  9 10 11 12 13 14 15 16
        // 17 18 19 20 21 22 23 24 
        //########################################################################
        #endregion

        private bool rigidBody;
        private short position;
        private BoxTypeEnum boxType;
        //private bool canMoveUp, canMoveDown, canMoveLeft, canMoveRight;

        public static Point ZeroMark = new Point(0, 0);

        public bool RigidBody
        {
            get { return this.rigidBody; }

            set { this.rigidBody = value; }
        }
        public short Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public BoxTypeEnum BoxType
        {
            get { return this.boxType; }
            set { this.boxType = value; }
        }

        public BoxPlace(short _position, Image _image, BoxTypeEnum _boxType, bool _rigidBody)
        {
            this.position = _position;
            this.DefineLocation();
            this.Image = _image;
            this.Size = new Size(this.Image.Width, this.Image.Height);
            this.boxType = _boxType;
            this.rigidBody = _rigidBody;
            
        }
        public BoxPlace()
        {

        }
        
        private void DefineLocation()
        {//todo:corrigir esse algoritmo
            for (int i = 1; i <= 15; i++)
            {
                for (int j = 1; j <= 25; j++)
                {

                    if (this.position == ((i - 1) * 25) + j)
                    {
                        this.Location = new Point((30 * j - 1) + ZeroMark.X,
                                                  (30 * i - 1) + ZeroMark.Y);
                        break;
                    }
                }
            }

        }


        internal void MoveUp()
        {
            this.position -= 25;
        }
        internal void MoveDown()
        {
            this.position += 25;
        }
        internal void MoveLeft()
        {
            this.position--;
        }
        internal void MoveRight()
        {
            this.position++;
        }
    }
}
