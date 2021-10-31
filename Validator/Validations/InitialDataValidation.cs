namespace Validator.Validations
{
    using Validator.Models;


    public class InitialDataValidation
    {
        private ICellphoneValidation _cellphoneValidator;

        public InitialDataValidation(ICellphoneValidation cellphoneValidator) 
        {
            _cellphoneValidator = cellphoneValidator;
        }


        public void ValidarDadosIniciais(InitialData dadosIniciais) =>
            _cellphoneValidator.Validate(dadosIniciais.Cellphone);
    }
}