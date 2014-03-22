using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicIO
{
    [Serializable]
    public class Port : IFireable
    {
        [NonSerialized]
        private VPort mComponent;
        
        private List<RootNode> mOutputs;
        private double mRawValue;
        private int mParentId;
        private int mIndex = 0;
        private int mId;

        private static int ID_POS;

        public Port(int cIndex)
        {
            mIndex = cIndex;
            mOutputs = new List<RootNode>();
            this.mId = ID_POS++;
        }

        public Port(int cIndex, VPort cComponent) : this(cIndex)
        {
            mComponent = cComponent;
            mParentId = mComponent.ID;
        }

        public double BitState
        {
            get { return mRawValue; }
            set 
            {
                mRawValue = value;
                if (mComponent != null)
                    mComponent.SetValue(mRawValue);

                foreach (RootNode lNode in mOutputs)
                {
                    lNode.BitState = mRawValue;
                }
            }
        }

        public void ForceBitState(double aValue)
        {
            mRawValue = aValue;
        }

        public List<RootNode> Outputs
        {
            get { return mOutputs; }
        }

        public VPort Component
        {
            get { return mComponent; }
            set { this.mComponent = value; }
        }

        public int ParentID
        {
            get { return this.mParentId; }
        }
    }
}
