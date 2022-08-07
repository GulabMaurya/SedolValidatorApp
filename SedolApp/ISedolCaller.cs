using System;
using System.Collections.Generic;
using System.Text;

namespace Sedol.Interfaces
{
    public interface ISedolCaller
    {
        ISedolValidationResult CallValidator(string input);
    }
}
