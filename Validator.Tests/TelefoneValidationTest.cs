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

            string result = "Número de telefone válido";

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
        [InlineData("Número de telefone inválido", "(03) 99010-0070")]
        [InlineData("Número de telefone inválido", "(33) 29900-8000")]
        [InlineData("Número de telefone inválido", "(00) 00000-0000")]
        [InlineData("Número de telefone inválido", "(21) 9900-0002")]
        [InlineData("Número de telefone inválido", "21 79900-8070")]
        [InlineData("Número de telefone inválido", "(88) 00000-0000")]
        public void ValidateReturnsInvalidWhenPhoneNumberIsInvalid(string resultadoEsperado, string telefone)
        {
            Test(resultadoEsperado, telefone);
        }

        [Theory]
        [InlineData("Número de telefone válido", "(88) 97845-8070")]
        [InlineData("Número de telefone válido", "(12) 97925-8552")]
        [InlineData("Número de telefone válido", "21971573847")]
        [InlineData("Número de telefone válido", "8297845-8070")]
        [InlineData("Número de telefone válido", "12 7157-3847")]
        

        public void ValidateReturnsValidWhenPhoneNumberIsValid(string resultadoEsperado, string telefone)
        {
            Test(resultadoEsperado, telefone);
        }
    }
}