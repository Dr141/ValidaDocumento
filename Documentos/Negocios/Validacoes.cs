using System.ComponentModel.DataAnnotations;

namespace Documentos.Negocios;

/// <summary>
/// Classe interna de validações
/// </summary>
internal static class Validacoes
{
    /// <summary>
    /// Método para verificar se o CPF contem o comprimento correto, e se contem apenas números.
    /// </summary>
    /// <param name="numeroCpf"></param>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    internal static void ValidarCPFSemFormatacao(this string numeroCpf)
    {
        ValidarComprimentoCpf(numeroCpf);
        ValidarNumeros(numeroCpf);
    }

    /// <summary>
    /// Método para verificar se o CPF contem apenas números.
    /// </summary>
    /// <param name="numeroCpf"></param>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    internal static void ValidarNumeros(string numeroCpf)
    {
        RegularExpressionAttribute regexAttribute = new RegularExpressionAttribute("^[0-9]+$")
        {
            ErrorMessage = "O CPF deve conter apenas números."
        };

        if (!regexAttribute.IsValid(numeroCpf))
        {
            throw new ValidationException(regexAttribute.ErrorMessage);
        }
    }

    /// <summary>
    /// Método para verificar o comprimento do CPF.
    /// </summary>
    /// <param name="numeroCpf"></param>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    internal static void ValidarComprimentoCpf(string numeroCpf)
    {
        StringLengthAttribute cepAttribute = new StringLengthAttribute(11)
        {
            MinimumLength = 11,
            ErrorMessage = "O CPF deve conter 11 dígitos."
        };

        if (!cepAttribute.IsValid(numeroCpf))
        {
            throw new ValidationException(cepAttribute.ErrorMessage);
        }
    }

    /// <summary>
    /// Método para verificar a formatação do CPF.
    /// </summary>
    /// <param name="numeroCpf"></param>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    internal static void ValidarFormatacaoCpf(this string numeroCpf)
    {
        RegularExpressionAttribute regexAttribute = new RegularExpressionAttribute(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
        {
            ErrorMessage = "O CPF deve estar no formato 000.000.000-00."
        };

        if (!regexAttribute.IsValid(numeroCpf))
        {
            throw new ValidationException(regexAttribute.ErrorMessage);
        }
    }

    /// <summary>
    /// Método para verificar o comprimento e se o CNPJ esta sem formatação.
    /// </summary>
    /// <param name="numeroCnpj"></param>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    internal static void ValidaCnpjSemFormatacao(this string numeroCnpj)
    {
        StringLengthAttribute cepAttribute = new StringLengthAttribute(14)
        {
            MinimumLength = 14,
            ErrorMessage = "O CNPJ deve conter 14 dígitos."
        };

        if (!cepAttribute.IsValid(numeroCnpj))
        {
            throw new ValidationException(cepAttribute.ErrorMessage);
        }

        RegularExpressionAttribute regexAttribute = new RegularExpressionAttribute("^[0-9]+$")
        {
            ErrorMessage = "O CNPJ deve conter apenas números."
        };

        if (!regexAttribute.IsValid(numeroCnpj))
        {
            throw new ValidationException(regexAttribute.ErrorMessage);
        }
    }

    /// <summary>
    /// Método para verificar se o CNPJ está sem formatar.
    /// </summary>
    /// <param name="numeroCnpj"></param>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    internal static void ValidarFormatacaoCnpj(this string numeroCnpj)
    {
        RegularExpressionAttribute regexAttribute = new RegularExpressionAttribute(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")
        {
            ErrorMessage = "O CNPJ deve estar no formato XX.XXX.XXX/YYYY-ZZ."
        };

        if (!regexAttribute.IsValid(numeroCnpj))
        {
            throw new ValidationException(regexAttribute.ErrorMessage);
        }
    }
}
