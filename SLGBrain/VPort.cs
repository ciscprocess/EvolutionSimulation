using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using LogicIO.Gates;
namespace LogicIO
{
    public class VPort : Panel
    {
        private Color mColor = Color.Red;
        private bool mRawValue;
        private Port mInternalPort;
        private int mId;
        public VPort()
        {
            this.Width = 23;
            this.Height = 23;
            this.Click += new EventHandler(Port_Click);
            this.BackColor = mColor;
            this.mRawValue = false;
            mId = MeshBrain.ID_POS++;
            mInternalPort = new Port(0, this);
        }

        void Port_Click(object sender, EventArgs e)
        {
            SetValueI(!mRawValue);
            mInternalPort.ForceBitState(0.0);
        }

        public void SetValue(double aValue)
        {
            if (aValue > 0.5)
                SetValueI(true);
            else SetValueI(false);

        }


        private void SetValueI(bool aValue)
        {
            mRawValue = aValue;
            
            if (mRawValue == true)
            {
                mColor = Color.Green;
                this.BackColor = mColor;
            }
            else
            {
                mColor = Color.Red;
                this.BackColor = mColor;
            }
        }

        public Port InternalPort
        {
            get { return mInternalPort; }
            set { mInternalPort = value; }
        }

        public int ID
        {
            get { return mId; }
            set { mId = value; }
        }

        public bool BitState
        {
            get { return mRawValue; }
        }
    }
}
