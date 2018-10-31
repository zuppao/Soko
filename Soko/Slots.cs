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
    public partial class Slots : Form
    {
        short slotNumber;
        SaveLoad saveLoad;

        internal short SlotNumber
        {
            get { return this.slotNumber; }
        }

        public Slots()
        {
            InitializeComponent();
        }

        private void Slots_Load(object sender, EventArgs e)
        {
            this.slotNumber = 0;
            this.listOptions.Items.Clear();
            for (short i = 0; i < 3; i++)
            {
                if (File.Exists(System.Environment.CurrentDirectory + "\\Save\\Save" + i + ".bin"))
                    this.listOptions.Items.Add("Save" + i);
                else
                    this.listOptions.Items.Add("Empty");
            }
        }
        private void Slots_Shown(object sender, EventArgs e)
        {
            if (this.saveLoad == SaveLoad.Save)
            {
                this.lbAction.Text = "Choose a slot to Save:";
            }
            else
                this.lbAction.Text = "Choose a save to Load:";
        }


        public void SetTitles(string _title, SaveLoad _saveLoad)
        {
            this.Text = _title;
            this.saveLoad = _saveLoad;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (this.listOptions.SelectedIndex < 0)
                MessageBox.Show("Please, select an slot!", "Save/Load", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
            {
                this.slotNumber = (short)this.listOptions.SelectedIndex;
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public enum SaveLoad
    {
        Save,
        Load
    }
}
