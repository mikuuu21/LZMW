﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZMW
{
    class CustomExceptions: Exception
    {
        public CustomExceptions(string message) : base(message) { }

    }
}
