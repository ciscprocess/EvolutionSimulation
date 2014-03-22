using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LogicIO.Gates;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LogicIO
{
    /// <summary>
    /// MeshBrain represents an interconnected mesh of Gates which have behavior somewhat akin to
    /// organic brain neurons.
    /// </summary>
    [Serializable]
    public class MeshBrain : Brain
    {
        private List<LinkedMeshGate> mRootGates;
        private Dictionary<long, LinkedMeshGate> mGateDict;
        private Dictionary<int, ReceptorNode> mRecptDict;
        private Dictionary<int, RootNode> mRootDict;


        /// <summary>
        /// Main constructor for brain -- this is the overload you want to use if you're creating a
        /// brain from scratch.
        /// </summary>
        /// <param name="cInputs">The number of inputs this brain shall have.</param>
        /// <param name="cOutputs">The number of outputs this brain shall have.</param>
        public MeshBrain(int cInputs, int cOutputs) : base(cInputs, cOutputs)
        {
            
            mRootGates = new List<LinkedMeshGate>();

            for (int forIndex2 = 0; forIndex2 < Math.Max(cOutputs, cInputs); forIndex2++)
            {
                LinkedMeshGate tGate = new LinkedMeshGate(this);
                mRootGates.Add(tGate);
                mRootNodes[forIndex2].AddRecepient(tGate.InputA);
                mRootNodes[forIndex2].AddRecepient(tGate.InputB);

                LinkedMeshGate tGate2 = new LinkedMeshGate(this);
                mRootGates.Add(tGate2);
                tGate.addOutput(tGate2.InputA);
                if (Toolbox.RAND.NextDouble() < 0.5)
                    tGate.addOutput(tGate2.InputB);

                Console.WriteLine(forIndex2 % mOutputs.Length);
                tGate2.Outputs.Add(mOutputs[forIndex2 % mOutputs.Length]);
                
                //mRootNodes[forIndex2].Fire();
            }
        }

        /// <summary>
        /// Fires all of the inputs in the brain.
        /// </summary>
        public void FireRootNodes()
        {
            foreach (RootNode lRoot in mRootNodes)
                lRoot.Fire();
        }

        /// <summary>
        /// Clones this brain. It currently uses the slower serialization method.
        /// </summary>
        /// <returns>The cloned brain. Preserves Gate individuality.</returns>
        public override Object Clone()
        {
            // O.o NONONONONO (Serialization. Slow.):
            MeshBrain newBrain;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                newBrain = (MeshBrain)formatter.Deserialize(stream);
            }

            return newBrain;
            
            /*
            mGateDict = new Dictionary<long, Gate>();
            mRootDict = new Dictionary<int, RootNode>();
            mRecptDict = new Dictionary<int, ReceptorNode>();

            SLGBrain newBrain = new SLGBrain();
            newBrain.mRootNodes = new List<RootNode>();
            newBrain.mRootGates = new List<Gate>();

            foreach (RootNode lRoot in mRootNodes)
            {
                if (!mRootDict.ContainsKey(lRoot.ID))
                {
                    RootNode newRoot = (RootNode)lRoot.CloneWithBrain(newBrain);
                    newBrain.mRootNodes.Add(newRoot);
                    mRootDict.Add(newRoot.ID, newRoot);
                }
                else newBrain.mRootNodes.Add(mRootDict[lRoot.ID]);
            }

            foreach (Gate lGate in mRootGates)
            {
                if (!mGateDict.ContainsKey(lGate.ID))
                {
                    Gate newGate = (Gate)lGate.CloneWithBrain(newBrain);
                    newBrain.mRootGates.Add(newGate);
                    mGateDict.Add(newGate.ID, newGate);
                }
                else newBrain.mRootGates.Add(mGateDict[lGate.ID]);
            }

            newBrain.mOutputs = mOutputs;

            return newBrain;
            */
        }

        /// <summary>
        /// Mutates this brain by mutating all the gates, and with a chance of mRate of adding a new gate.
        /// </summary>
        /// <returns>The current brain, NOT a mutated clone.</returns>
        public override Brain Mutate()
        {
            if (Toolbox.RAND.NextDouble() < META_RATE)
            {
                mRate += (double)Toolbox.RAND.Next(-5, 5) / 1000.0;
                if (mRate < 0) mRate = 0.0;
            }

            if (Toolbox.RAND.NextDouble() < mRate)
            {
                int choice = 0;
                if (choice < 1)
                    mRootGates.Add(new LinkedMeshGate(this));
                else if (choice < 2 && mRootGates.Count > 10)
                    mRootGates.RemoveAt(Toolbox.RAND.Next(mOutputs.Length, mRootGates.Count));
            }

            foreach (Gate lGate in mRootGates)
                lGate.Mutate(); 

            return this;
        }

        public List<LinkedMeshGate> RootGates
        {
            get { return mRootGates; }
        }

        public List<RootNode> RootNodes
        {
            get { return mRootNodes; } 
        }

        public Dictionary<long, LinkedMeshGate> GateDictionary
        {
            get { return mGateDict; }
            set { mGateDict = value; }
        }


        public Dictionary<int, ReceptorNode> ReceptorNodeDictionary
        {
            get { return mRecptDict; }
            set { mRecptDict = value; }
        }

        public Dictionary<int, RootNode> RootNodeDictionary
        {
            get { return mRootDict; }
            set { mRootDict = value; }
        }

        
    }
}
