using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace LogicIO.Gates
{
    [Serializable]
    public abstract class Gate : IMutator<Gate>, ICloneable
    {
        
        public static double TIME_SCAN = 0.0;
        private static int ID_POS = 0;
        public static int ADD_COUNT = 0;
        public static int REM_COUNT = 0;

        protected double META_RATE = 0.10;
        protected double RATE = 0.01;
        protected double mFireValue = 0.0;
        protected double mThreshold;
        protected double mInhibitThresh;

        protected int mId = 0;
        protected Brain mParent;

        protected Gate()
        {

        }

        protected Gate(Brain cParent)
        {
            mParent = cParent;

            mId = ID_POS++;
            mFireValue = ((double)Toolbox.RAND.Next(-500, 1500)) / 1000;
            mThreshold = ((double)Toolbox.RAND.Next(-150, 200)) / 1000;
            mInhibitThresh = ((double)Toolbox.RAND.Next(1000, 1600)) / 1000;
        }

        public abstract Gate Mutate();
        
        public abstract double Fire();

        public object Clone()
        {
            throw new NotImplementedException();
        }

        //public abstract Gate CloneWithBrain(MeshBrain aBrain);

        public long ID
        {
            get { return mId; }
        }

        public double Threshold
        {
            get { return mThreshold; }
        }
    }
}
