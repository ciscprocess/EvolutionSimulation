using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicIO;
namespace BrainTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Brain testBrain = new MeshBrain(15, 15);
            //for (int i = 0; i < 500; i++)
                //testBrain.Mutate();
            int index = 0;
            foreach (Port pt in testBrain.Inputs)
            {
            //    pt.BitState = 0.8;
                
                index++;
            }

            testBrain.Inputs[5].BitState = 1.0;

            foreach (Port pt in testBrain.Outputs)
            {
                Console.WriteLine("Value: " + pt.BitState);
            }

            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
