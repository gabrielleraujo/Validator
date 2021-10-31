namespace Validator.Tests
{
    using System;
    using Validator.Utils;
    using Validator.Validations;
    using Xunit;


    public class TelefoneValidationTest
    {
        private void Test(string expectedResult, string telefone)
        {
            //arrange
            var logger = MyLoggerFactory.Create<TelefoneValidationTest>();
           
            ICellphoneValidation validator = new CellphoneValidation(logger);

            string result = "N�mero de telefone v�lido";

            //act
            try
            {
                validator.Validate(telefone);
            }
            catch (ArgumentException e)
            {
                result = e.Message;
            }

            //assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData("N�mero de telefone inv�lido", "(03) 99010-0070")]
        [InlineData("N�mero de telefone inv�lido", "(33) 29900-8000")]
        [InlineData("N�mero de telefone inv�lido", "(00) 00000-0000")]
        [InlineData("N�mero de telefone inv�lido", "(21) 9900-0002")]
        [InlineData("N�mero de telefone inv�lido", "21 79900-8070")]
        [InlineData("N�mero de telefone inv�lido", "(88) 00000-0000")]
        public void ValidateReturnsInvalidWhenPhoneNumberIsInvalid(string resultadoEsperado, string telefone)
        {
            Test(resultadoEsperado, telefone);
        }

        [Theory]
        [InlineData("N�mero de telefone v�lido", "(88) 97845-8070")]
        [InlineData("N�mero de telefone v�lido", "(12) 97925-8552")]
        [InlineData("N�mero de telefone v�lido", "21971573847")]
        [InlineData("N�mero de telefone v�lido", "8297845-8070")]
        [InlineData("N�mero de telefone v�lido", "12 7157-3847")]
        

        public void ValidateReturnsValidWhenPhoneNumberIsValid(string resultadoEsperado, string telefone)
        {
            Test(resultadoEsperado, telefone);
        }
    }
}