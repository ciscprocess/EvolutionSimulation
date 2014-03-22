using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using LogicIO.Gates;
using System.Windows.Forms;

namespace LogicIO
{
    
    /// <summary>
    /// DualGate represents a gate with two ReceptorNodes. Kinda stupid at this point, I know.
    /// It used to be a NAND Gate implementation, so this used to make sense.
    /// </summary>z
    [Serializable]
    public class LinkedMeshGate : Gate
    {
        protected ReceptorNode mInputA;
        protected ReceptorNode mInputB;
        protected List<IFireable> mOutputs;

        /// <summary>
        /// Default constructor for DualGate. 
        /// </summary>
        public LinkedMeshGate()
        {

        }

        /// <summary>
        /// Constructor for DualGate that sets it to a specific brain. What you'll usually want to use, 
        /// unless cloning.
        /// </summary>
        /// <param name="cBrain"></param>
        public LinkedMeshGate(MeshBrain cBrain) : base(cBrain)
        {
            mOutputs = new List<IFireable>();
            mInputA = new ReceptorNode(this);
            mInputB = new ReceptorNode(this);
        }

        public void addOutput(ReceptorNode aOutput)
        {
            mOutputs.Add(aOutput);
            aOutput.Pointers++;
            aOutput.Primed = false;
        }

        private double sigmoid(double aVal)
        {
            return (1 / (1 + Math.Pow(Math.E, -aVal)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double Fire()
        {
            double tFireVal = mFireValue + Toolbox.NORM.NextDouble();

            // MISFIFAAAA!!
            if (Toolbox.RAND.NextDouble() < 0.0000001)
                tFireVal *= 2;
            
            foreach (IFireable tNode in mOutputs)
            {
                tNode.BitState += tFireVal; //+ (Toolbox.NORM.NextDouble());
            }

            return mFireValue;
        }

        public void Notify()
        {
            if (mInputA.Primed)
            {
                if (mInputA.BitState >= mThreshold)
                {    
                    Fire();
                }

                mInputA.ForceBitState(0);
                mInputA.Primed = false;
                mInputB.ForceBitState(0);
                mInputB.Primed = false;
            }
            
        }
        
        private bool IsLooped(LinkedMeshGate reference, LinkedMeshGate toCheck)
        {
            if (reference.mId == toCheck.mId)
                return true;

            foreach (IFireable lFire in toCheck.mOutputs)
            {
                if (lFire is ReceptorNode)
                {
                    bool val = IsLooped(reference, ((ReceptorNode)lFire).Parent);
                    if (val == true)
                        return true;
                }
            }

            return false;
        }

        /*private bool IsLooped(LinkedMeshGate reference, LinkedMeshGate toCheck)
        {
            if (reference.mId == toCheck.mId)
                return true;

            HashSet<ReceptorNode> visited = new HashSet<ReceptorNode>();
            Queue<ReceptorNode> structure = new Queue<ReceptorNode>();

            structure.Enqueue(reference.InputA);
            structure.Enqueue(reference.InputB);
            
            while (structure.Count > 0)
            {
                ReceptorNode current = structure.Dequeue();
                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                if (current.Parent.mId == toCheck.mId)
                    return true;

                foreach (IFireable lNode in current.Parent.Outputs)
                {
                    if (lNode is ReceptorNode)
                    {
                        ReceptorNode node2 = (ReceptorNode)lNode;
                        node2.Primed = true;
                        node2.BitState = 0.0;
                        structure.Enqueue(node2);
                    }

                }
            }
            
            return false;
        }*/

        public override Gate Mutate()
        {
            LinkedMeshGate cloned = this;

            // Mutate the mutation rate
            if (Toolbox.RAND.NextDouble() <= META_RATE)
            {
                RATE += (double)Toolbox.RAND.Next(-10, 10) / 1000.0;
                if (RATE < 0) 
                    RATE = 0.0;
            }

            if (Toolbox.RAND.NextDouble() <= RATE)
            {
                int type = Toolbox.RAND.Next(3);

                // 0 -- Add a new Random link
                if (type < 1)
                {
                    ReceptorNode newLink;

                    List<LinkedMeshGate> moddedList = new List<LinkedMeshGate>(((MeshBrain)mParent).RootGates);
                    DateTime start = DateTime.Now;

                    for (int forIndex = 0; forIndex < moddedList.Count; forIndex++)
                    {
                        if (IsLooped(this, moddedList[forIndex]))
                        {
                            moddedList.RemoveAt(forIndex);
                            forIndex--;
                        }
                    }

                    TimeSpan span = DateTime.Now.Subtract(start);
                    TIME_SCAN += span.TotalSeconds;

                    if (moddedList.Count == 0)
                        return cloned;

                    ADD_COUNT++;

                    int newIndex = Toolbox.RAND.Next(moddedList.Count);

                    LinkedMeshGate tGate = moddedList[newIndex];
                    int choice = Toolbox.RAND.Next(2);
                    if (choice == 0)
                    {
                        newLink = tGate.InputA;
                    }
                    else
                        newLink = tGate.InputB;

                    if (!mOutputs.Contains(newLink))
                        this.addOutput(newLink);
                }
                // 1 -- remove a Random link
                else if (type < 2)
                {
                    REM_COUNT++;
                    int remIndex = Toolbox.RAND.Next(mOutputs.Count);
                    if (mOutputs.Count > 0 && mOutputs[remIndex] is ReceptorNode)
                    {
                        ((ReceptorNode)cloned.mOutputs[remIndex]).Pointers--;
                        cloned.mOutputs.RemoveAt(remIndex);
                    }
                }
                // 2 -- mutate threshold or firevalue
                else if (type < 3)
                {
                    int choicie = Toolbox.RAND.Next(3);
                    if (choicie < 1)
                    {
                        mFireValue += (((double)Toolbox.RAND.Next(-100, 100)) / 1000);
                        if (mFireValue < 0) mFireValue = 0.0;
                    }
                    else if (choicie < 2)
                    {
                        mThreshold += (((double)Toolbox.RAND.Next(-100, 100)) / 1000);
                    }
                    else
                    {
                        this.mInhibitThresh += (((double)Toolbox.RAND.Next(-100, 100)) / 1000);
                    }
                }

            }

            return cloned;
        }

        public ReceptorNode InputA
        {
            get { return mInputA; }
        }

        public ReceptorNode InputB
        {
            get { return mInputB; }
        }

        public List<IFireable> Outputs
        {
            get { return mOutputs; }
        }

        public LinkedMeshGate CloneWithBrain(MeshBrain aBrain)
        {
            LinkedMeshGate newGate = new LinkedMeshGate();
            newGate.mParent = aBrain;
            newGate.mId = mId;
            newGate.mThreshold = mThreshold;
            newGate.mFireValue = mFireValue;
            newGate.mOutputs = new List<IFireable>();
            MeshBrain tParent = (MeshBrain)mParent;
            if (!tParent.ReceptorNodeDictionary.ContainsKey(InputA.ID))
            {
                ReceptorNode newNode = (ReceptorNode)InputA.CloneWithGate(newGate);
                newGate.mInputA = newNode;
                tParent.ReceptorNodeDictionary.Add(newNode.ID, newNode);
            }
            else
                newGate.mInputA = tParent.ReceptorNodeDictionary[InputA.ID];

            if (!tParent.ReceptorNodeDictionary.ContainsKey(InputB.ID))
            {
                ReceptorNode newNode = (ReceptorNode)InputB.CloneWithGate(newGate);
                newGate.mInputB = newNode;
                tParent.ReceptorNodeDictionary.Add(newNode.ID, newNode);
            }
            else
                newGate.mInputB = tParent.ReceptorNodeDictionary[InputB.ID];

            foreach (IFireable lFire in mOutputs)
            {
                if (lFire is ReceptorNode)
                {
                    ReceptorNode lNode = (ReceptorNode)lFire;
                    if (!tParent.ReceptorNodeDictionary.ContainsKey(lNode.ID))
                    {
                        LinkedMeshGate newerGate;
                        if (!tParent.GateDictionary.ContainsKey(lNode.Parent.ID))
                        {
                            newerGate = lNode.Parent.CloneWithBrain(aBrain);
                            if (!tParent.GateDictionary.ContainsKey(newerGate.ID))
                                tParent.GateDictionary.Add(newerGate.ID, newerGate);
                        }
                        else
                            newerGate = tParent.GateDictionary[lNode.Parent.ID];

                        ReceptorNode newNode = (ReceptorNode)lNode.CloneWithGate(newerGate);
                        newGate.mOutputs.Add(newNode);
                        if (!tParent.ReceptorNodeDictionary.ContainsKey(newNode.ID))
                            tParent.ReceptorNodeDictionary.Add(newNode.ID, newNode);
                    }
                    else newGate.mOutputs.Add(tParent.ReceptorNodeDictionary[lNode.ID]);
                }
                else if (lFire is Port)
                {
                    newGate.mOutputs.Add(lFire);
                }
            }

            return newGate;
        }
    }
}
