﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public interface IWorldObject
    {
        bool IsDestroyed
        {
            get;
            set;
        }

        int Life
        {
            get;
            set;
        }

    }
}