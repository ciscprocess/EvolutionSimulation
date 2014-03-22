using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogicIO.Gates;

namespace LogicIO
{
    public partial class FormControl : Form
    {
        private MeshBrain mCurrentBrain;
        private static int inputs = 6;
        private int mRuns = 1000;
        private static int outputs = 6;
        private Port[] outputPorts = new Port[outputs];
        private Port[] inputPorts = new Port[inputs];
        private int mGeneration = 0;
        public FormControl()
        {
            InitializeComponent();
            
            for (int forIndex = 0; forIndex < outputs; forIndex++)
            {
                VPort tPort = new VPort();
                tPort.Left = forIndex * 24 + 10;
                tPort.Top = 14;
                grpOutputs.Controls.Add(tPort);
                Port ttPort = new Port(forIndex, tPort);
                outputPorts[forIndex] = ttPort;
                tPort.InternalPort = ttPort;

                VPort desiredPort = new VPort();
                desiredPort.Left = forIndex * 24 + 10;
                desiredPort.Top = 14;
                grpDesOuput.Controls.Add(desiredPort);
            }

            for (int forIndex = 0; forIndex < inputs; forIndex++)
            {
                VPort tPort = new VPort();
                tPort.Left = forIndex * 24 + 10;
                tPort.Top = 14;
                grpInputs.Controls.Add(tPort);
                Port ttPort = new Port(forIndex, tPort);
                inputPorts[forIndex] = ttPort;
                tPort.InternalPort = ttPort;
                //grpOutputs.Controls.Add(tPort);
            }
            //tPort.Outputs.Add(meBrain.RootNodes[forIndex]);
            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            mCurrentBrain = new MeshBrain(inputs, outputs);
            for (int forIndex = 0; forIndex < inputPorts.Length; forIndex++)
            {
                inputPorts[forIndex].Outputs.Add(mCurrentBrain.RootNodes[forIndex]);
            }
        }

        private void ReseatBrain(MeshBrain aCurrentBrain)
        {
            for (int forIndex2 = 0; forIndex2 < inputPorts.Length; forIndex2++)
            {
                inputPorts[forIndex2].Outputs.Clear();
                inputPorts[forIndex2].Outputs.Add(aCurrentBrain.RootNodes[forIndex2]);
            }


            foreach (LinkedMeshGate lGate in aCurrentBrain.RootGates)
            {
                foreach (IFireable lFire in lGate.Outputs)
                {
                    if (lFire is Port)
                    {
                        Port tNewPort = (Port)lFire;
                        foreach (VPort tV in grpOutputs.Controls)
                        {
                            if (tNewPort.ParentID == tV.ID)
                                tNewPort.Component = tV;
                        }
                    }
                }
            }
        }

        private void btnMutate_Click(object sender, EventArgs e)
        {
            if (mCurrentBrain == null)
            {
                MessageBox.Show("Generate a Brain First");
                return;
            }

            double cloneTime = 0;
            double portsTime = 0;
            double mutateTime = 0;
            double fireTime = 0;
            bool running = true;
            DateTime begin = DateTime.Now;
            while (running)
            {
                MeshBrain mutating = mCurrentBrain;
                List<MeshBrain> brains = new List<MeshBrain>();
                List<int> scores = new List<int>();
                mutateBar.Maximum = mRuns;
                mutating.FireRootNodes();

                for (int forIndex = 0; forIndex < mRuns; forIndex++)
                {
                    mutateBar.Value = forIndex;
                    brains.Add(mutating);
                    scores.Add(ScoreOutput());

                    DateTime start = DateTime.Now;

                    mutating = (MeshBrain)mutating.Clone();

                    TimeSpan span = DateTime.Now.Subtract(start);
                    cloneTime += span.TotalSeconds;

                    start = DateTime.Now;

                    ReseatBrain(mutating);

                    span = DateTime.Now.Subtract(start);
                    portsTime += span.TotalSeconds;

                    start = DateTime.Now;
                    mutating.Mutate();
                    span = DateTime.Now.Subtract(start);
                    mutateTime += span.TotalSeconds;

                    start = DateTime.Now;
                    mutating.FireRootNodes();
                    span = DateTime.Now.Subtract(start);
                    fireTime += span.TotalSeconds;

                    listGens.Items.Add("Child: " + mGeneration + ", Score: " + ScoreOutput());
                    mGeneration++;
                }
                int best = scores.IndexOf(scores.Max());
                listGens.Items.Add("Best Child: " + best);
                mCurrentBrain = brains[best];
                ReseatBrain(mCurrentBrain);
                mCurrentBrain.FireRootNodes();
                if (scores.Max() == outputs)
                    running = false;
                listGens.SelectedIndex = listGens.Items.Count - 1;
                this.Refresh();
            }
            
            string message = String.Format("Total Time Spend Cloning: {0:0.0000}s", cloneTime);
            message += String.Format("\nTotal Time Spend Routing Ports: {0:0.0000}s", portsTime);
            message += String.Format("\nTotal Time Spend Mutating: {0:0.0000}s", mutateTime);
            message += String.Format("\nTotal Time Spent Safety Checking: {0:0.0000}s", Gate.TIME_SCAN);
            message += String.Format("\nTotal Time Spend Firing/Calculating: {0:0.0000}s", fireTime);
            message += String.Format("\nTotal adds: {0}, Total Removes {1}", Gate.ADD_COUNT, Gate.REM_COUNT);
            message += String.Format("\nTotal Time: {0:0.0000}s", DateTime.Now.Subtract(begin).TotalSeconds);
            mutateBar.Value = mutateBar.Maximum;
            MessageBox.Show(message, "Speed Stats");
        }

        public int ScoreOutput()
        {
            int score = 0;
            for (int forIndex = 0; forIndex < outputs; forIndex++)
            {
                VPort one = (VPort)grpOutputs.Controls[forIndex];
                VPort two = (VPort)grpDesOuput.Controls[forIndex];
                if (one.BitState == two.BitState)
                    score++;
            }
            return score;

        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Score: " + ScoreOutput());
        }
    }
}
