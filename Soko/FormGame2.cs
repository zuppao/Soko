using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
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
        Models.BlockBase lastBoxMoved;
        List<Point> slotPositionList;
        List<Models.BlockBase> boxList;
        short slotNumber;
        short increment;
        ushort currentLevel;
        int pushes;

        public FormGame2()
        {
            InitializeComponent();
        }

        private void FormGame2_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Save"))
                Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Save");

            this.increment = 30;
            Models.BlockBase.Increment = this.increment;
            this.lbStatusTotalLevels.Text = Directory.GetFiles(System.Environment.CurrentDirectory + "\\Levels", "Level***.txt").Length.ToString("/ 00");
            this.btNewGame_Click(null, new EventArgs());
        }

        private void LoadLevel(string[] _lineBlocks)
        {
            this.slotPositionList.Clear();
            this.boxList.Clear();
            this.panelGame.Controls.Clear();
            Models.BlockBase newBlock;
            List<Control> slotBlocks = new List<Control>();
            char[] blocks;

            if (_lineBlocks == null)//load new level
            {
                _lineBlocks = File.ReadAllLines(System.Environment.CurrentDirectory + "\\Levels\\Level" + this.currentLevel.ToString("000") + ".txt");
                this.pushes = 0;
                this.player.ResetMovesCount();
                this.currentLevel_Rigid = new Models.BlockBase[25, 17];
                this.lbStatusCurrentLevel.Text = this.currentLevel.ToString("00");
            }

            for (int y = 0; y < _lineBlocks.Length; y++)
            {
                blocks = _lineBlocks[y].ToCharArray();
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
                            this.slotPositionList.Add(newBlock.Picture.Location);
                            break;
                        case 'B':
                            newBlock = new Models.Box(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(newBlock.Picture);
                            this.boxList.Add(newBlock);
                            break;
                        case 'X'://box and slot
                            newBlock = new Models.Slot(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(newBlock.Picture);
                            slotBlocks.Add(this.panelGame.Controls[this.panelGame.Controls.Count - 1]);
                            this.slotPositionList.Add(newBlock.Picture.Location);
                            this.currentLevel_Rigid[x, y] = newBlock;

                            newBlock = new Models.Box(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(newBlock.Picture);
                            this.boxList.Add(newBlock);
                            break;
                        case 'Y'://player and slot
                            newBlock = new Models.Slot(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(newBlock.Picture);
                            slotBlocks.Add(this.panelGame.Controls[this.panelGame.Controls.Count - 1]);
                            this.slotPositionList.Add(newBlock.Picture.Location);
                            this.currentLevel_Rigid[x, y] = newBlock;

                            newBlock = new Models.BlockBase();
                            this.player.SetStartPosition(new Point(30 * x, 30 * y));
                            this.panelGame.Controls.Add(this.player.Picture);
                            this.panelGame.Controls[this.panelGame.Controls.Count - 1].BringToFront();
                            break;
                        case 'P':
                            newBlock = new Models.BlockBase();
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
                        this.lastBoxMoved = null;
                    }
                    else
                    {//rigid
                        if (this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y].Picture.Tag.Equals("B") &&
                            !this.currentLevel_Rigid[this.player.Position.X + 2, this.player.Position.Y].RigidBody)
                        {
                            this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y].MoveRight();
                            this.lastBoxMoved = this.currentLevel_Rigid[this.player.Position.X + 1, this.player.Position.Y];
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
                        this.lastBoxMoved = null;
                    }
                    else
                    {//rigid
                        if (this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y].Picture.Tag.Equals("B") &&
                            !this.currentLevel_Rigid[this.player.Position.X - 2, this.player.Position.Y].RigidBody)
                        {
                            this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y].MoveLeft();
                            this.lastBoxMoved = this.currentLevel_Rigid[this.player.Position.X - 1, this.player.Position.Y];
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
                        this.lastBoxMoved = null;
                    }
                    else
                    {//rigid
                        if (this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1].Picture.Tag.Equals("B") &&
                            !this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 2].RigidBody)
                        {
                            this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1].MoveUP();
                            this.lastBoxMoved = this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y - 1];
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
                        this.lastBoxMoved = null;
                    }
                    else
                    {//rigid
                        if (this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1].Picture.Tag.Equals("B") &&
                            !this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 2].RigidBody)
                        {
                            this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1].MoveDown();
                            this.lastBoxMoved = this.currentLevel_Rigid[this.player.Position.X, this.player.Position.Y + 1];
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
            this.UpdateStatus();

        }

        private void CheckSlots()
        {
            for (short i = 0; i < this.boxList.Count; i++)
            {
                if (!this.slotPositionList.Contains(this.boxList[i].Picture.Location))
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
            this.LoadLevel(null);
        }



        private void btUndo_Click(object sender, EventArgs e)
        {
            this.player.Undo();
            if (this.lastBoxMoved != null)
            {
                Point lastBoxPosition = ((Models.Box)this.lastBoxMoved).Position;
                ((Models.Box)this.lastBoxMoved).Undo();
                Point currentBoxPosition = ((Models.Box)this.lastBoxMoved).Position;

                this.currentLevel_Rigid[currentBoxPosition.X, currentBoxPosition.Y] = this.currentLevel_Rigid[lastBoxPosition.X, lastBoxPosition.Y];
                this.currentLevel_Rigid[lastBoxPosition.X, lastBoxPosition.Y] = new Models.BlockBase();

                this.pushes++;
                this.lastBoxMoved = null;
            }
            this.UpdateStatus();
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            FormAbout formHelp = new FormAbout();
            formHelp.ShowDialog();
        }

        private void UpdateStatus()
        {
            this.lbStatusMoves.Text = this.player.MovesCount.ToString("000000");
            this.lbStatusPushes.Text = this.pushes.ToString("000000");
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (this.slotNumber == -1)
            {
                Slots slotsForm = new Slots();
                slotsForm.SetTitles("Save", SaveLoad.Save);
                if (slotsForm.ShowDialog() != DialogResult.OK)
                    return;

                this.slotNumber = slotsForm.SlotNumber;
            }

            try
            {
                string[,] currentLevelStateIndividual = new string[this.currentLevel_Rigid.GetUpperBound(0) + 1, this.currentLevel_Rigid.GetUpperBound(1) + 1];

                for (int y = 0; y < this.currentLevel_Rigid.GetUpperBound(1) + 1; y++)
                {
                    for (int x = 0; x < this.currentLevel_Rigid.GetUpperBound(0) + 1; x++)
                    {
                        if (this.currentLevel_Rigid[x, y].Picture != null)
                        {
                            if (this.currentLevel_Rigid[x, y].Picture.Tag.ToString() == "B" && this.slotPositionList.Contains(new Point(x * this.increment, y * this.increment)))
                            {
                                currentLevelStateIndividual[x, y] = "X";
                            }
                            else
                            {
                                currentLevelStateIndividual[x, y] = this.currentLevel_Rigid[x, y].Picture.Tag.ToString();
                            }
                        }
                        else
                        {
                            currentLevelStateIndividual[x, y] = " ";
                        }
                    }
                }

                if (this.slotPositionList.Contains(this.player.Picture.Location))
                {
                    currentLevelStateIndividual[this.player.Position.X, this.player.Position.Y] = "Y";
                }
                else
                {
                    currentLevelStateIndividual[this.player.Position.X, this.player.Position.Y] = this.player.Picture.Tag.ToString();
                }

                StringBuilder sb = new StringBuilder();
                string[] currentLevelStateFinal = new string[currentLevelStateIndividual.GetUpperBound(1) + 1];
                for (int y = 0; y < this.currentLevel_Rigid.GetUpperBound(1) + 1; y++)
                {
                    for (int x = 0; x < this.currentLevel_Rigid.GetUpperBound(0) + 1; x++)
                    {
                        sb.Append(currentLevelStateIndividual[x, y]);
                    }
                    currentLevelStateFinal[y] = sb.ToString();
                    sb.Clear();
                }
                //File.WriteAllText("levelTest.txt", sb.ToString());
                sb = null;

                StateGameData gameData = new StateGameData(this.currentLevel, this.player.MovesCount, this.pushes);
                gameData.CurrentLevelState = currentLevelStateFinal;

                IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Stream stream = new FileStream(System.Environment.CurrentDirectory + "\\Save\\Save" + this.slotNumber + ".bin", FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, gameData);
                stream.Close();
                MessageBox.Show("Game successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Game could not be saved: " + ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            Slots slotsForm = new Slots();
            slotsForm.SetTitles("Load", SaveLoad.Load);
            if (slotsForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (MessageBox.Show("All your current progress will be lost. Are you sure?", "Load", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            this.slotNumber = slotsForm.SlotNumber;


            try
            {
                IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Stream stream = new FileStream(System.Environment.CurrentDirectory + "\\Save\\Save" + this.slotNumber + ".bin", FileMode.Open, FileAccess.Read);
                object obj = formatter.Deserialize(stream);
                stream.Close();

                StateGameData gameData = (StateGameData)obj;
                this.currentLevel = gameData.CurrentLevel;
                this.player.MovesCount = gameData.Moves;
                this.pushes = gameData.Pushes;
                this.UpdateStatus();
                this.LoadLevel(gameData.CurrentLevelState);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The game could not be loaded: " + ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error)

            }
        }

        private void btRestartLevel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to restart the Level? All your current progress will be lost.", "Restart Level", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.LoadLevel(null);
                this.UpdateStatus();
            }
        }

        private void btNewGame_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (MessageBox.Show("Are you sure to start a new game? All your current progress will be lost.", "New Game", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
            }

            this.slotNumber = -1;
            this.currentLevel = 1;
            this.slotPositionList = new List<Point>();
            this.boxList = new List<Models.BlockBase>();
            this.player = new Models.Player(this.increment);
            this.LoadLevel(null);
            this.UpdateStatus();
        }
    }

    [Serializable]
    public class StateGameData
    {
        ushort currentLevel;
        int moves, pushes;
        string[] currentLevelState;

        public ushort CurrentLevel
        {
            get { return this.currentLevel; }
        }
        public int Moves
        {
            get { return this.moves; }
        }
        public int Pushes
        {
            get { return this.pushes; }
        }
        public string[] CurrentLevelState
        {
            get { return this.currentLevelState; }
            set { this.currentLevelState = value; }
        }

        public StateGameData(ushort _currentLevel, int _moves, int _pushes)
        {
            this.currentLevel = _currentLevel;
            this.moves = _moves;
            this.pushes = _pushes;
        }
    }
}
