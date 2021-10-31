namespace Validator.Tests
{
    using System;
    using Validator.Utils;
    using Validator.Validations;
    using Xunit;


    public class CellphoneValidationTest
    {
        const string validMessage = "Número de celular válido";
        const string invalidMessage = "Número de celular inválido";

        private void Test(string expectedResult, string cellphone)
        {
            //arrange
            var logger = MyLoggerFactory.Create<CellphoneValidationTest>();
           
            ICellphoneValidation validator = new CellphoneValidation(logger);

            string result = validMessage;

            //act
            try
            {
                validator.Validate(cellphone);
            }
            catch (ArgumentException e)
            {
                result = e.Message;
            }

            //assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(invalidMessage, "(03) 99010-0070")]
        [InlineData(invalidMessage, "(33) 29900-8000")]
        [InlineData(invalidMessage, "(00) 00000-0000")]
        [InlineData(invalidMessage, "(21) 9900-0002")]
        [InlineData(invalidMessage, "21 79900-8070")]
        [InlineData(invalidMessage, "(88) 00000-0000")]
        public void ValidateReturnsInvalidWhenPhoneNumberIsInvalid(string expectedResult, string cellphone)
        {
            Test(expectedResult, cellphone);
        }


        [Theory]
        [InlineData(validMessage, "(88) 97845-8070")]
        [InlineData(validMessage, "(12) 97925-8552")]
        [InlineData(validMessage, "21971573847")]
        [InlineData(validMessage, "8297845-8070")]
        [InlineData(validMessage, "12 7157-3847")]
        public void ValidateReturnsValidWhenPhoneNumberIsValid(string expectedResult, string cellphone)
        {
            Test(expectedResult, cellphone);
        }
    }
}