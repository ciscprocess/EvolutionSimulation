using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicIO.Gates
{
    [Serializable]
    public class ReceptorNode : IFireable, ICloneable
    {
        public static int M_ID_POS = 0;
        protected LinkedMeshGate mGate;
        protected double mBitState = 0.0;
        protected bool mPrimed = true;
        protected int mId;
        private int mPointers = 0;

        public int Pointers
        {
            get { return mPointers; }
            set { mPointers = value; }
        }
        private int mPrimerPosition = 0;

        public int PrimerPosition
        {
            get { return mPrimerPosition; }
            set { mPrimerPosition = value; }
        }

        public ReceptorNode()
        {

        }

        public ReceptorNode(LinkedMeshGate cGate)
        {
            mGate = cGate;
            mId = M_ID_POS++;
        }

        public double BitState
        {
            get
            {
                return mBitState;
            }
            set
            {
                mBitState = value;
                Flush();
            }
        }

        public void Flush()
        {
            mPrimerPosition++;
            if (mPrimerPosition >= mPointers)
            {
                mPrimed = true;
                mPrimerPosition = 0;
            }

            mGate.Notify();
        }

        public void ForceBitState(double aBitState)
        {
            mBitState = aBitState;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public ReceptorNode CloneWithGate(LinkedMeshGate aGate)
        {
            ReceptorNode newNode = new ReceptorNode();
            newNode.mGate = aGate;
            newNode.mBitState = mBitState;
            newNode.mPrimed = mPrimed;
            newNode.mId = mId;
            return newNode;
        }

        public int ID
        {
            get { return mId; }
        }

        public bool Primed
        {
            get { return mPrimed; }
            set { mPrimed = value; }
        }

        public LinkedMeshGate Parent
        {
            get { return mGate; }
        }

    }
}
