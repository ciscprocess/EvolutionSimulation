using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicIO.Gates;
namespace LogicIO
{
    [Serializable]
    public class RootNode : IFireable, ICloneable
    {
        private Brain mBrain;
        private double mBitState = 0.0;
        private List<IFireable> mNodes;
        private int mId;
        private bool mPrimed;
        public static int M_ID_POS = 0;

        public RootNode()
        {

        }

        public RootNode(Brain cBrain)
        {
            mBrain = cBrain;
            mNodes = new List<IFireable>();
            mId = M_ID_POS++;
        }

        public void Fire()
        {
            foreach (IFireable lNode in mNodes)
            {
                lNode.BitState = mBitState;
            }
        }

        public void AddRecepient(IFireable aRecipient)
        {
            mNodes.Add(aRecipient);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public RootNode CloneWithBrain(MeshBrain aBrain)
        {
            /*
            RootNode newRoot = new RootNode();
            newRoot.mBitState = mBitState;
            newRoot.mId = mId;
            newRoot.mNodes = new List<IFireable>();
            newRoot.mBrain = aBrain;
            foreach (IFireable lFire in mNodes)
            {
                if (lFire is ReceptorNode)
                {
                    ReceptorNode lNode = (ReceptorNode)lFire;
                    if (!mBrain.ReceptorNodeDictionary.ContainsKey(lNode.ID))
                    {
                        LinkedMeshGate newParent;
                        if (!mBrain.GateDictionary.ContainsKey(lNode.Parent.ID))
                        {
                            newParent = lNode.Parent.CloneWithBrain(aBrain);
                            mBrain.GateDictionary.Add(newParent.ID, newParent);
                        }
                        else newParent = mBrain.GateDictionary[lNode.Parent.ID];
                        ReceptorNode newNode = (ReceptorNode)lNode.CloneWithGate(newParent);
                        newRoot.mNodes.Add(newNode);
                        if (!mBrain.ReceptorNodeDictionary.ContainsKey(newNode.ID)) mBrain.ReceptorNodeDictionary.Add(newNode.ID, newNode);
                    }
                    else newRoot.mNodes.Add(mBrain.ReceptorNodeDictionary[lNode.ID]);
                }
                else if (lFire is Port)
                {
                    newRoot.mNodes.Add(lFire);
                }
            }*/

            return null;
        }

        public double BitState
        {
            get 
            { 
                mPrimed = false; 
                return mBitState; 
            }
            set 
            { 
                mPrimed = true; 
                mBitState = value; 
                Fire(); 
            }
        }

        public int ID
        {
            get { return mId; }
        }

        public List<IFireable> Outputs
        {
            get { return mNodes; }
        }

        public bool Primed
        {
            get { return mPrimed; }
        }
    }
}
