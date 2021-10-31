namespace Validator.Models
{
    public class InitialData
    {
        public string Cellphone { get; set; }
        
        public InitialData(string number)
        {
            Cellphone = number;
        }
    }
}