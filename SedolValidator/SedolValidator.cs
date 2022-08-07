using Sedol.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sedol.Validator
{
    public class SedolValidator : ISedolValidator
    {   
        public ISedolValidationResult ValidateSedol(string input)
        {

            var sedolMain = new SedolMain(input);

            var validationResult = new SedolValidationResult
            {
                InputString = input,
                IsUserDefined = false,
                IsValidSedol = false,
                ValidationDetails = null
            };
            if (string.IsNullOrEmpty(input)) {
                validationResult.ValidationDetails = "Input string was not 7-characters long";
                return validationResult;
            }

            if (!sedolMain.CheckIfAlphaNumeric())
            {
                validationResult.ValidationDetails = "SEDOL contains invalid characters";
                return validationResult;
            }
            
            if (!sedolMain.CheckIfValidLength())
            {
                validationResult.ValidationDetails = "Input string was not 7-characters long";
                return validationResult;
            }
            if (sedolMain.CheckIfUserDefined())
            {
                validationResult.IsUserDefined = true;
                if (sedolMain.IsValidChecksum())
                {
                    validationResult.IsValidSedol = true;
                    return validationResult;
                }
                else
                {
                    validationResult.ValidationDetails = "Checksum digit does not agree with the rest of the input";
                    return validationResult;
                }
            }

            if (sedolMain.IsValidChecksum())
                validationResult.IsValidSedol = true;
            else
                validationResult.ValidationDetails = "Checksum digit does not agree with the rest of the input";
            return validationResult;
        }
    }
}
