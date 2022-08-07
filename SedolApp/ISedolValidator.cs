using System;
using System.Collections.Generic;
using System.Text;

namespace Sedol.Interfaces
{
    public interface ISedolValidator
    {
        ISedolValidationResult ValidateSedol(string input);
    }
}
