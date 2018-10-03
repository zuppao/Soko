using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soko
{
    public partial class FormGame2 : Form
    {
        //25 columns (750px)
        //15 lines (450px)
        //30x30 px each image
        char[,] currentLevel_Blocks;
        Models.BlockBase[,] currentLevel_Rigid;
        Models.Player player;
        short increment;

        public FormGame2()
        {
            InitializeComponent();

        }

        private void FormGame2_Load(object sender, EventArgs e)
        {
            this.increment = 30;
            Models.BlockBase.Increment = this.increment;
            this.LoadLevel(1);
        }



        private void LoadLevel(short _level)
        {

            string[] lineBlocks = File.ReadAllLines(System.Environment.CurrentDirectory + "\\Levels\\Level" + _level.ToString("000") + ".txt");
            this.currentLevel_Blocks = new char[25, 15];
            this.currentLevel_Rigid = new Models.BlockBase[25, 15];

            Models.BlockBase newBlock;
            for (int y = 0; y < lineBlocks.Length; y++)
            {
                char[] blocks = lineBlocks[y].ToCharArray();
                for (int x = 0; x < blocks.Length; x++)
                {
                    this.currentLevel_Blocks[x, y] = blocks[x];
                    newBlock = null;
                    switch (blocks[x])
                    {
                        case '#':
                            newBlock = new Models.Wall(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(newBlock.Picture);
                            break;
                        case 'S':
                            newBlock = new Models.Slot(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(newBlock.Picture);
                            this.panelGame.Controls[this.panelGame.Controls.Count - 1].SendToBack();
                            break;
                        case 'B':
                            newBlock = new Models.Box(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(newBlock.Picture);
                            break;
                        case 'P':
                            this.player = new Models.Player(this.increment);
                            this.player.SetStartPosition(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(this.player.Picture);
                            this.panelGame.Controls[this.panelGame.Controls.Count - 1].BringToFront();
                            this.lbPlayer.Text = this.player.Position.ToString();
                            break;
                        default:
                            break;
                    }

                    if (newBlock != null)
                    {
                        //this.panelGame.Controls.Add(newBlock.Picture);
                        //if (blocks[x] == 'S')
                        //    this.panelGame.Controls[this.panelGame.Controls.Count-1].SendToBack();
                        this.currentLevel_Rigid[x, y] = newBlock;
                    }
                }


            }



            #region CURRENT LEVEL
            /* the current level will be like this...
             *   [0][1][2][3][4][5][6][7][8][9][10] ... [25]
             *[0] #  #  #  #  #  #  #  #  #  #  #   ...  #
             *[1] #  #  #  #  #  #  #  #  #  #  #   ...  #
             *[2] #  #  #  #  #  #  #  #  0  0  0   ...  #
             *[3] #  #  #  #  #  #  #  #  B  0  0   ...  #
             *[4] #  #  #  #  #  #  #  0  0  0  B   ...  #
             * f r e  r   
             */
            #endregion
        }

        private void FormGame2_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y] == null ||
                       !this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y].RigidBody)
                    {
                        this.player.MoveRight();
                    }
                    else
                    {
                        ;//rigid
                    }

                    break;
                case Keys.Left:
                    if (this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y] == null ||
                       !this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y].RigidBody)
                    {
                        this.player.MoveLeft();
                    }
                    else
                    {
                        ;//rigid
                    }

                    break;
                case Keys.Up:
                    if (this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1] == null ||
                       !this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1].RigidBody)
                    {
                        this.player.MoveUP();
                    }
                    else
                    {
                        ;//rigid
                    }

                    break;
                case Keys.Down:
                    if (this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1] == null ||
                       !this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1].RigidBody)
                    {
                        this.player.MoveDown();
                    }
                    else
                    {
                        ;//rigid
                    }

                    break;
                default:
                    break;
            }

            this.lbPlayer.Text = this.player.Position.ToString();
        }

    }
}
