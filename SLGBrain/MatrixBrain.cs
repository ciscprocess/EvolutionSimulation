using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicIO.Gates;
namespace LogicIO
{
    [Serializable]
    public class MatrixBrain : Brain
    {
        private int mNodes;
        private MatrixNode[ , ] mMatrixMap;

        public MatrixBrain(int cInputs, int cOutputs) : base(cInputs, cOutputs)
        {
            mMatrixMap = new MatrixNode[cInputs * 2, cInputs * 3];
            new MatrixNode(this);

        }

        public override Brain Mutate()
        {
            throw new NotImplementedException();
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
