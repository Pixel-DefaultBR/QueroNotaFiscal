using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace QueroNotaFiscal.Utils
{
    public class CNPJValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult("CNPJ é obrigatório.");

            string cnpj = new string(value.ToString().Where(char.IsDigit).ToArray());

            if (!IsValidCnpj(cnpj))
                return new ValidationResult("CNPJ inválido.");

            return ValidationResult.Success;
        }

        private bool IsValidCnpj(string cnpj)
        {
            if (cnpj.Length != 14)
                return false;

            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCnpj = cnpj.Substring(0, 12);
            var soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            var resto = (soma % 11);
            var digito1 = (resto < 2) ? 0 : 11 - resto;

            tempCnpj += digito1;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            var digito2 = (resto < 2) ? 0 : 11 - resto;

            return cnpj.EndsWith(digito1.ToString() + digito2.ToString());
        }
    }
}
