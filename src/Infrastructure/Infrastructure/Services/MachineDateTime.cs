﻿using System;
using UPS.Common;

namespace UPS.Infrastructure.Services
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
