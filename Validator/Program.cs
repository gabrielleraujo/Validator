namespace PhoneValidator
{
    using Validator.Models;
    using Validator.Utils;
    using Validator.Validations;
    using System;


    class Program
    {
        static void Main(string[] args)
        {
            //arrange
            var logger = MyLoggerFactory.Create<Program>();

            ICellphoneValidation cellphoneValidator = new CellphoneValidation(logger);
            var validacao = new InitialDataValidation(cellphoneValidator);

            string cellphone = "21 99938-8070";
            var initialData = new InitialData(cellphone);
            string result = "Número de telefone válido";

            //act
            try { validacao.ValidarDadosIniciais(initialData); }
            catch (ArgumentException e) { result = e.Message; }

            //assert
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}