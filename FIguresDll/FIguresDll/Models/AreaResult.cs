﻿using FIguresDll.Exceptions;

namespace FIguresDll.Models
{
    public class AreaResult
    {
        public float ResultArea { get; private set; }
        public AreaGetterException Error { get; set; }

        public AreaResult()
        {
            ResultArea = -1;
        }

        public bool HasError()
        {
            return Error != null;
        }

        internal void SetArea(float area)
        {
            ResultArea = area;
        }
    }
}
