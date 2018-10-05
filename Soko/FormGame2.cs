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
        //17 lines (510px)
        //30x30 px each image
        Models.BlockBase[,] currentLevel_Rigid;
        Models.Player player;
        List<Point> slotList;
        List<Models.BlockBase> boxList;
        short increment;
        ushort currentLevel;
        int pushes;
        public FormGame2()
        {
            InitializeComponent();
        }

        private void FormGame2_Load(object sender, EventArgs e)
        {
            this.increment = 30;
            Models.BlockBase.Increment = this.increment;
            this.currentLevel = 1;
            this.pushes = 0;
            this.lbStatusTotalLevels.Text = Directory.GetFiles(System.Environment.CurrentDirectory + "\\Levels", "Level***.txt").Length.ToString("/ 00");

            this.slotList = new List<Point>();
            this.boxList = new List<Models.BlockBase>();
            this.LoadLevel();
        }



        private void LoadLevel()
        {
            this.panelGame.Controls.Clear();
            this.currentLevel_Rigid = new Models.BlockBase[25, 17];
            this.slotList.Clear();
            this.boxList.Clear();
            this.lbStatusCurrentLevel.Text = this.currentLevel.ToString("00");
            Models.BlockBase newBlock;
            List<Control> slotBlocks = new List<Control>();
            char[] blocks;

            string[] lineBlocks = File.ReadAllLines(System.Environment.CurrentDirectory + "\\Levels\\Level" + this.currentLevel.ToString("000") + ".txt");
            for (int y = 0; y < lineBlocks.Length; y++)
            {
                blocks = lineBlocks[y].ToCharArray();
                for (int x = 0; x < blocks.Length; x++)
                {
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
                            slotBlocks.Add(this.panelGame.Controls[this.panelGame.Controls.Count - 1]);
                            this.slotList.Add(newBlock.Picture.Location);
                            break;
                        case 'B':
                            newBlock = new Models.Box(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(newBlock.Picture);
                            this.boxList.Add(newBlock);
                            break;
                        case 'P':
                            newBlock = new Models.BlockBase();
                            this.player = new Models.Player(this.increment);
                            this.player.SetStartPosition(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(this.player.Picture);
                            this.panelGame.Controls[this.panelGame.Controls.Count - 1].BringToFront();
                            break;
                        default:
                            newBlock = new Models.BlockBase();
                            break;
                    }

                    this.currentLevel_Rigid[x, y] = newBlock;
                }



            }

            foreach (var slot in slotBlocks)
            {//just to send all 'slot' blocks to the back of the panel
                slot.SendToBack();
            }

            slotBlocks = null;
            newBlock = null;
            blocks = null;

            GC.Collect();
        }

        private void FormGame2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (!this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y].RigidBody)
                    {
                        this.player.MoveRight();
                    }
                    else
                    {//rigid
                        if (this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y].Picture.Tag.Equals("B") &&
                            !this.currentLevel_Rigid[this.player.Position.X + 2, this.player.Position.Y].RigidBody)
                        {
                            this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y].MoveRight();
                            this.currentLevel_Rigid[this.player.Position.X + 2, this.player.Position.Y] = this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y];
                            this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y] = new Models.BlockBase();
                            this.player.MoveRight();
                            this.pushes++;
                            this.CheckSlots();
                        }
                    }
                    break;
                case Keys.Left:
                    if (!this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y].RigidBody)
                    {
                        this.player.MoveLeft();
                    }
                    else
                    {//rigid
                        if (this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y].Picture.Tag.Equals("B") &&
                            !this.currentLevel_Rigid[this.player.Position.X - 2, this.player.Position.Y].RigidBody)
                        {
                            this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y].MoveLeft();
                            this.currentLevel_Rigid[this.player.Position.X - 2, this.player.Position.Y] = this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y];
                            this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y] = new Models.BlockBase();
                            this.player.MoveLeft();
                            this.pushes++;
                            this.CheckSlots();
                        }
                    }
                    break;
                case Keys.Up:
                    if (!this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1].RigidBody)
                    {
                        this.player.MoveUP();
                    }
                    else
                    {//rigid
                        if (this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1].Picture.Tag.Equals("B") &&
                            !this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 2].RigidBody)
                        {
                            this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1].MoveUP();
                            this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 2] = this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1];
                            this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1] = new Models.BlockBase();
                            this.player.MoveUP();
                            this.pushes++;
                            this.CheckSlots();
                        }
                    }
                    break;
                case Keys.Down:
                    if (!this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1].RigidBody)
                    {
                        this.player.MoveDown();
                    }
                    else
                    {//rigid
                        if (this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1].Picture.Tag.Equals("B") &&
                            !this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 2].RigidBody)
                        {
                            this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1].MoveDown();
                            this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 2] = this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1];
                            this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1] = new Models.BlockBase();
                            this.player.MoveDown();
                            this.pushes++;
                            this.CheckSlots();
                        }
                    }
                    break;
                default:
                    break;
            }
            this.lbStatusMoves.Text = this.player.MovesCount.ToString("000000");
            this.lbStatusPushes.Text = this.pushes.ToString("000000");
        }

        private void CheckSlots()
        {
            for (short i = 0; i < this.boxList.Count; i++)
            {
                if (!this.slotList.Contains(this.boxList[i].Picture.Location))
                {
                    return;
                }
            }
            this.LevelEnd();
        }

        private void LevelEnd()
        {
            MessageBox.Show("You WON!");
            this.currentLevel++;
            this.LoadLevel();
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            FormHelp formHelp = new FormHelp();
            formHelp.ShowDialog();
        }
    }
}
