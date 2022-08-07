using System;
using Xunit;
using Sedol.Validator;
using Sedol.Interfaces;

namespace Sedol.Tests
{
    public class SedolValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("12")]
        [InlineData("123456789")]
        public void Should_Have_Valid_Length_SEDOL(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);           
            var expected = new SedolValidationResult(input, false, false, "Input string was not 7-characters long");
            AssertEquals(expected, actual);

        }

        [Theory]
        [InlineData("1234567")]
        public void Should_Have_Valid_Checksum_SEDOL(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            var expected = new SedolValidationResult(input, false, false, "Checksum digit does not agree with the rest of the input");
            AssertEquals(expected, actual);


        }
        [Theory]
        [InlineData("0709954")]
        [InlineData("B0YBKJ7")]
        public void Should_Validate_Invalid_SEDOL(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            var expected = new SedolValidationResult(input, true, false, null);
            AssertEquals(expected, actual);

        }

        [Theory]
        [InlineData("9123451")]
        [InlineData("9ABCDE8")]
        public void Should_Validate_Valid_SEDOL(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            var expected = new SedolValidationResult(input, false, true, "Checksum digit does not agree with the rest of the input");
            AssertEquals(expected, actual);

        }

        [Theory]
        [InlineData("9123_51")]
        [InlineData("VA.CDE8")]
        public void Should_Validate_Invalid_Characters_SEDOL(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            var expected = new SedolValidationResult(input, false, false, "SEDOL contains invalid characters");
            AssertEquals(expected, actual);

        }

        [Theory]
        [InlineData("9123458")]
        [InlineData("9ABCDE1")]
        public void Should_Validate_user_defined_SEDOL(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            var expected = new SedolValidationResult(input, true, true, null);
            AssertEquals(expected, actual);

        }
        private void AssertEquals(ISedolValidationResult expected, ISedolValidationResult actual)
        {
            Assert.Equal(expected.IsValidSedol, actual.IsValidSedol);
            Assert.Equal(expected.IsUserDefined, actual.IsUserDefined);
            Assert.Equal(expected.ValidationDetails, actual.ValidationDetails);
        }

    }
}
