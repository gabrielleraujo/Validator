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

            ICellphoneValidation validador = new CellphoneValidation(logger);
            var validacao = new InitialDataValidation(validador);

            string telefone = "21 99938-8070";
            var dadosIniciais = new InitialData(telefone);
            string resultado = "Número de telefone válido";

            //act
            try
            {
                validacao.ValidarDadosIniciais(dadosIniciais);
            }
            catch (ArgumentException e)
            {
                resultado = e.Message;
            }

            //assert
            Console.ReadLine();
        }
    }
}