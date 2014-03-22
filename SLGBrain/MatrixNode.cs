using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicIO.Gates
{
    class MatrixNode : Gate, IFireable
    {
        private double mBitstate;

        private int mOutIndex;


        public MatrixNode(MatrixBrain cParent, int cOutIndex) : this(cParent)
        {
            mOutIndex = cOutIndex;
        }

        public MatrixNode(MatrixBrain cParent) : base(cParent)
        {
            mOutIndex = -1;
        }

        public override double Fire()
        {
            double tFireVal = mFireValue;

            // MISFIFAAAA!!
            if (Toolbox.RAND.NextDouble() < 0.0000001)
                tFireVal *= 2;

            return tFireVal + Toolbox.NORM.NextDouble();
        }

        public override Gate Mutate()
        {
            // Mutate the mutation rate
            if (Toolbox.RAND.NextDouble() <= META_RATE)
            {
                RATE += (double)Toolbox.RAND.Next(-10, 10) / 1000.0;
                if (RATE < 0) RATE = 0.0;
            }

            if (Toolbox.RAND.NextDouble() <= RATE)
            {
                int choicie = Toolbox.RAND.Next(2);
                if (choicie < 1)
                {
                    mFireValue += (((double)Toolbox.RAND.Next(-100, 100)) / 1000);
                    if (mFireValue < 0) mFireValue = 0.0;
                }
                else
                {
                    mThreshold += (((double)Toolbox.RAND.Next(-100, 100)) / 1000);
                }
            }

            return this;
        }

        public double BitState
        {
            get { return mBitstate; }
            set { mBitstate = value; }
        }
    }
}
