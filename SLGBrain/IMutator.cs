﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicIO
{
    public interface IMutatable<T>
    {
        T Mutate();
    }
}
