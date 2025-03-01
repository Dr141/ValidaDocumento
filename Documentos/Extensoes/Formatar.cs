using Documentos.Negocios;

namespace Documentos.Extensoes;

/// <summary>
/// Classe para formatar documentos (CPF e CNPJ).
/// </summary>
public static class Formatar
{
    /// <summary>
    /// Método para formata CPF.
    /// </summary>
    /// <param name="cpf">deverá passar o número do CPF no formato <see cref="string"/></param>
    /// <returns>Retorna uma <see cref="string"/> com o número do CPF formatado.</returns>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    public static string FormatarCPF(this string cpf)
    {
        cpf.ValidarCPFSemFormatacao();
        return Convert.ToUInt64(cpf).ToString("000\\.000\\.000\\-00");        
    }

    /// <summary>
    /// Método para formata CNPJ.
    /// </summary>
    /// <param name="cnpj">deverá passar o número do CNPJ no formato <see cref="string"/></param>
    /// <returns>Retorna uma <see cref="string"/> com o número do CNPJ formatado.</returns>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    public static string FormatarCNPJ(this string cnpj)
    {
        cnpj.ValidaCnpjSemFormatacao();
        return Convert.ToUInt64(cnpj).ToString("00\\.000\\.000\\/0000\\-00");
    }

    /// <summary>
    /// Método para remover formatação do CPF/CNPJ.
    /// </summary>
    /// <param name="documento">deverá passar o número do CPF/CNPJ no formato <see cref="string"/></param>
    /// <returns>retorna uma <see cref="string"/> com o número do CPF/CNPJ.</returns>
    public static string RemoverFormatacao(this string documento)
    {
        string apenasNumeros = string.Empty;

        for (int i = 0; i < documento.Length; i++)
        {
            if(char.IsDigit(documento[i])) 
                apenasNumeros += documento[i];
        }

        return apenasNumeros;
    }
}
