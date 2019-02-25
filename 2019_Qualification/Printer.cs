﻿using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_Qualification
{
    public class Printer : PrinterBase<ProblemOutput>
    {
        public override void PrintToConsole(ProblemOutput result)
        {
            throw new NotImplementedException();
        }

        public override void PrintToFile(ProblemOutput result, string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                throw new NotImplementedException();
            }
        }
    }
}
