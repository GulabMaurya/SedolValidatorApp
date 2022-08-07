using System;
using System.Collections.Generic;
using System.Text;
using Sedol.Validator;
using Xunit;

namespace Sedol.Tests
{
    public class SedolMainTests
    {
        [Theory]
        [InlineData("VA.CDE8")]
        public void Should_Contains_AlphaNumeric_Charcters_SEDOL(string input)
        {
            SedolMain sedolinput = new SedolMain(input);
            var isAlphaNumeric = sedolinput.CheckIfAlphaNumeric();
            Assert.False(isAlphaNumeric);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("12")]
        [InlineData("123456789")]
        public void Should_Have_Valid_Length_SEDOL(string input) {

            SedolMain sedolinput = new SedolMain(input);
            var isValidLength = sedolinput.CheckIfValidLength();
            Assert.False(isValidLength);
        }

        [Theory]
        [InlineData("9123458")]
        [InlineData("9ABCDE1")]
        public void Should_Validate_UserDefined_SEDOL(string input)
        {

            SedolMain sedolinput = new SedolMain(input);
            var isUserDefined = sedolinput.CheckIfUserDefined();
            Assert.True(isUserDefined);
        }
        [Theory]
        [InlineData("1234567")]
        public void Should_Have_Valid_Checksum_SEDOL(string input)
        {
            SedolMain sedolinput = new SedolMain(input);
            var isValidChecksum = sedolinput.IsValidChecksum();
            Assert.False(isValidChecksum);
        }


    }
}
