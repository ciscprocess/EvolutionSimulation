using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.Distributions;

namespace LogicIO
{
    public static class Toolbox
    {
        public static Random RAND = new Random();
        public static NormalDistribution NORM = new NormalDistribution(MU, SIGMA);


        //
        // Internal Constants
        //
        private const double MU = 0.005;
        private const double SIGMA = 0.002;
    }
}
