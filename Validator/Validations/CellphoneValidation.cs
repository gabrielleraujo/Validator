namespace Validator.Validations
{
    using Microsoft.Extensions.Logging;
    using System.Text.RegularExpressions;
    using System;


    public class CellphoneValidation : ICellphoneValidation
    {
        private string _pattern = "^\\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\\)? ?(?:[2-8]|9[1-9])[0-9]{3}\\-?[0-9]{4}$";
        
        private ILogger _logger;
        public CellphoneValidation(ILogger logger) { _logger = logger; }


        public void Validate(string telefone)
        {
            var result = Regex.Match(telefone, _pattern);

            if (!result.Success)
            {
                _logger.LogError("Número de telefone inválido");

                throw new ArgumentException("Número de telefone inválido");
            }
            _logger.LogInformation("Número de telefone válido");
        }
    }
}