using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Neuro;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace LogicIO
{
   [Serializable]
   public class NNBrain : Brain
    {
        private ActivationNetwork mNetwork;
        public NNBrain(int cInputs, int cOutputs) : base(cInputs, cOutputs)
        {
            mNetwork = new ActivationNetwork(new BipolarSigmoidFunction(0.04), cInputs, cInputs * 2, cInputs*3, cInputs*3, cInputs/2, cOutputs);
            mNetwork.Randomize();
            Mutate();
            Mutate();
            Mutate();
            Mutate();
            Mutate();
            Mutate();
            Mutate();
            Mutate();

        }

        public override void ForwardProp()
        {
            double[] inputs = new double[mInputs.Length];
            for (int forI = 0; forI < mInputs.Length; forI++)
            {
                inputs[forI] = mInputs[forI].BitState;
            }

            mNetwork.Compute(inputs);

            for (int forI = 0; forI < mOutputs.Length; forI++)
            {
                mOutputs[forI].BitState = (mNetwork.Output[forI] - 0.01) * 100;
            }
        }

        public override Object Clone()
        {
            NNBrain newBrain;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                newBrain = (NNBrain)formatter.Deserialize(stream);
            }

            return newBrain;
        }

        public override Brain Mutate()
        {
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                if (rand.NextDouble() < 0.10)
                {
                    int index = rand.Next(mNetwork.Layers.Length);
                    Layer lay = mNetwork.Layers[index];
                    index = rand.Next(lay.Neurons.Length);
                    Neuron neur = lay.Neurons[index];
                    index = rand.Next(neur.Weights.Length);
                    neur.Weights[index] += (rand.Next(10) / 100.0) - 0.05;
                }
            }

            return this;
        }
    }
}
