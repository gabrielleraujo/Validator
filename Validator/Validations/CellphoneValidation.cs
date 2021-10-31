namespace Validator.Validations
{
    using Microsoft.Extensions.Logging;
    using System.Text.RegularExpressions;
    using System;


    public class CellphoneValidation : ICellphoneValidation
    {
        const string validMessage = "Número de celular válido";
        const string invalidMessage = "Número de celular inválido";

        private string _pattern = "^\\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\\)? ?(?:[2-8]|9[1-9])[0-9]{3}\\-?[0-9]{4}$";
        
        private ILogger _logger;
        public CellphoneValidation(ILogger logger) { _logger = logger; }


        public void Validate(string cellphone)
        {
            var result = Regex.Match(cellphone, _pattern);

            if (!result.Success)
            {
                _logger.LogError(invalidMessage);

                throw new ArgumentException(invalidMessage);
            }
            _logger.LogInformation(validMessage);
        }
    }
}