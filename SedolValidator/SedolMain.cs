using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Sedol.Interfaces;

namespace Sedol.Validator
{
    public class SedolMain :ISedolMain
    {
        public string InputSedol { get; set; }
        public List<int> WeightingFactor { get; set; }       

        public SedolMain(string input)
        {
            InputSedol = input;
            WeightingFactor = new List<int>() { 1, 3, 1, 7, 3, 9 };
        }

        public bool CheckIfAlphaNumeric()
        {
            if (!String.IsNullOrEmpty(InputSedol) && Regex.IsMatch(InputSedol, "^[a-zA-Z0-9]*$"))
                return true;
            else
                return false;
        }

        public bool CheckIfValidLength() 
        {
            if (!String.IsNullOrEmpty(InputSedol) && InputSedol.Length == 7)
                return true;
            else
                return false;
        }



        public bool CheckIfUserDefined()
        {
            if (InputSedol[0].ToString() == "9")
                return true;
            else
                return false;
        }

        private int CharIndex(char input)
        {
            if (Char.IsLetter(input))
                return Char.ToUpper(input) - 55;
            return input - 48;
        }

        public bool IsValidChecksum()
        {

            var codes = InputSedol.ToCharArray().Take(6);
            List<int> result = new List<int>();
            foreach (var item in codes)
            {
                result.Add(CharIndex(item));

            }
            var weightedSum = WeightingFactor.Zip(result, (weightingFactor, result) => weightingFactor * result).Sum();
            var checkSum = Convert.ToChar(((10 - (weightedSum % 10)) % 10).ToString());
            if (InputSedol[6] == checkSum)
                return true;
            return false;

        }



    }

}
