using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EvoGame
{
    public partial class EntitiesView : Form
    {
        GameState mState;
        public EntitiesView(GameState cState)
        {
            InitializeComponent();
            mState = cState;
            foreach (AIEntity lEnt in mState.mEntities)
                aIEntityBindingSource.Add(lEnt);
            aiData.Click += new EventHandler(aiData_Click);
            brainStrip.ItemClicked += new ToolStripItemClickedEventHandler(brainStrip_ItemClicked);
        }

        void brainStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        void aiData_Click(object sender, EventArgs e)
        {
            MouseEventArgs args  = (MouseEventArgs)e;

            if (args.Button == MouseButtons.Right)
            {
                brainStrip.Show();
                brainStrip.Left = this.Left + args.X;
                brainStrip.Top = this.Top + args.Y + 30;
            }
        }

    }
}
