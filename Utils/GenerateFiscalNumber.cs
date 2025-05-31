namespace QueroNotaFiscal.Utils
{
    public class GenerateFiscalNumber
    {
        private static readonly Random _random = new Random();
        public static string GenerateNumber()
        {
            int randomNumber = _random.Next(10000000, 99999999);
            return randomNumber.ToString("D8");
        }
    }
}
