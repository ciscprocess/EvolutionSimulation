using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicIO
{
    [Serializable]
    public abstract class Brain : ICloneable, IMutator<Brain>
    {
        protected static double META_RATE = 0.05;
        protected double mRate = 0.12;
        protected Port[] mOutputs;
        protected Port[] mInputs;
        protected List<RootNode> mRootNodes;
        protected int mId = 0;
        protected long mStep = 0;
        public static int ID_POS = 0;

        /// <summary>
        /// Default constructor for brain -- mainly used for smart cloning.
        /// </summary>
        public Brain()
        {
            mId = ID_POS++;
        }

        public Brain(int cInputs, int cOutputs) : this()
        {
            mOutputs = new Port[cOutputs];
            mInputs = new Port[cInputs];

            for (int i = 0; i < mOutputs.Length; i++)
                mOutputs[i] = new Port(i);

            for (int i = 0; i < mInputs.Length; i++)
                mInputs[i] = new Port(i);

            mRootNodes = new List<RootNode>();

            for (int forIndex = 0; forIndex < cInputs; forIndex++)
            {
                RootNode tNode = new RootNode(this);
                mRootNodes.Add(tNode);
                mInputs[forIndex].Outputs.Add(tNode);
            }
        }

        public abstract Brain Mutate();

        public abstract Object Clone();

        public virtual void ForwardProp()
        {
        }

        /// <summary>
        /// Resets the port data, so it doesn't accumulate, eventually leading to false positives
        /// </summary>
        public void ResetPorts()
        {
            foreach (Port tport in Outputs)
            {
                tport.BitState = 0.0;
            }
        }

        public int ID
        {
            get { return mId; }
            set { mId = value; }
        }

        public long Step
        {
            get { return mStep; }
            set { mStep = value; }
        }

        public Port[] Inputs
        {
            get { return mInputs; }
        }

        public Port[] Outputs
        {
            get { return mOutputs; }
        }
    }
}
