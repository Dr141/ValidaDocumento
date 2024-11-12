using System.ComponentModel.DataAnnotations;

namespace CNPJ.Negocios
{
    internal static class Validacoes
    {
        internal static void ValidarCNPJSemFormata(this string numeroCPF)
        {
            StringLengthAttribute cepAttribute = new StringLengthAttribute(14)
            {
                MinimumLength = 14,
                ErrorMessage = "O CNPJ deve conter 14 dígitos."
            };

            if (!cepAttribute.IsValid(numeroCPF))
            {
                throw new ValidationException(cepAttribute.ErrorMessage);
            }

            RegularExpressionAttribute regexAttribute = new RegularExpressionAttribute("^[0-9]+$")
            {
                ErrorMessage = "O CNPJ deve conter apenas números."
            };

            if (!regexAttribute.IsValid(numeroCPF))
            {
                throw new ValidationException(regexAttribute.ErrorMessage);
            }
        }

        internal static void ValidarCNPJormatado(this string numeroCPF)
        {
            RegularExpressionAttribute regexAttribute = new RegularExpressionAttribute(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")
            {
                ErrorMessage = "O CNPJ deve estar no formato XX.XXX.XXX/YYYY-ZZ."
            };

            if (!regexAttribute.IsValid(numeroCPF))
            {
                throw new ValidationException(regexAttribute.ErrorMessage);
            }
        }
    }
}
