﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01._FileStream_Before
{
    public interface IStreamable
    {
        int Length { get; set; }

        int Sent { get; set; }


    }
}
