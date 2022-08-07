using System;


using System.Collections.Generic;
using System.Text;
using Sedol.Interfaces;
using Sedol.Validator;
namespace Sedol.RunnerApp
{
    public class SedolCaller : ISedolCaller
    {
        private readonly ISedolValidationResult _validationResult;
        private readonly ISedolValidator _validator;
        public SedolCaller(ISedolValidationResult validationResult, ISedolValidator validator)
        {
            _validationResult = validationResult;   
            _validator = validator;    
        }

        public ISedolValidationResult CallValidator(string input) {
           
            return _validator.ValidateSedol(input);
        }
    }
}
