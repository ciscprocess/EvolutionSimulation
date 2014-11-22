using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLGBrain.Brain
{
    /// <summary>
    /// Abstract Brain Class which defines the basic operations and methods the brain supports
    /// </summary>
    [Serializable]
    public abstract class Brain : ICloneable, IMutatable<Brain>
    {
        
    }
}
