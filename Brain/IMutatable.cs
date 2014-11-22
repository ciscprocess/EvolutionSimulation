using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLGBrain.Brain
{
    public interface IMutatable<T>
    {
        T Mutate();
    }
}
