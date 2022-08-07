using System;
using System.Collections.Generic;
using System.Text;

namespace Sedol.Interfaces
{
    public interface ISedolMain
    {
        public string InputSedol { get; set; }
        public List<int> WeightingFactor { get; set; }
        public bool CheckIfAlphaNumeric();
        public bool CheckIfValidLength();
        public bool CheckIfUserDefined();
        public bool IsValidChecksum();
       
    }
}
