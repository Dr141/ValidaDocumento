using System.ComponentModel.DataAnnotations;

namespace CPF.Negocios
{
    internal static class Validacoes
    {
        internal static void ValidarCPFSemFormata(this string numeroCPF)
        {
            ValidarComprimento(numeroCPF);
            ValidarNumeros(numeroCPF);
        }

        internal static void ValidarNumeros(string numeroCPF)
        {
            RegularExpressionAttribute regexAttribute = new RegularExpressionAttribute("^[0-9]+$")
            {
                ErrorMessage = "O CPF deve conter apenas números."
            };

            if (!regexAttribute.IsValid(numeroCPF))
            {
                throw new ValidationException(regexAttribute.ErrorMessage);
            }
        }

        internal static void ValidarComprimento(string numeroCPF)
        {
            StringLengthAttribute cepAttribute = new StringLengthAttribute(11)
            {
                MinimumLength = 11,
                ErrorMessage = "O CPF deve conter 11 dígitos."
            };

            if (!cepAttribute.IsValid(numeroCPF))
            {
                throw new ValidationException(cepAttribute.ErrorMessage);
            }
        }

        internal static void ValidarCPFormatado(this string numeroCPF)
        {
            RegularExpressionAttribute regexAttribute = new RegularExpressionAttribute(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
            {
                ErrorMessage = "O CPF deve estar no formato 000.000.000-00."
            };

            if (!regexAttribute.IsValid(numeroCPF))
            {
                throw new ValidationException(regexAttribute.ErrorMessage);
            }
        }
    }
}
