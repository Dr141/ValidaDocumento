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
    /// <param name="cpf"></param>
    /// <returns>Rertona uma <see cref="string"/> com o número do CPF formatado.</returns>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    public static string FormatarCPF(this string cpf)
    {
        cpf.ValidarCPFSemFormatacao();
        return Convert.ToUInt64(cpf).ToString("000\\.000\\.000\\-00");        
    }

    /// <summary>
    /// Método para formata CNPJ.
    /// </summary>
    /// <param name="cnpJ"></param>
    /// <returns>Rertona uma <see cref="string"/> com o número do CNPJ formatado.</returns>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    public static string FormatarCNPJ(this string cnpj)
    {
        cnpj.ValidaCnpjSemFormatacao();
        return Convert.ToUInt64(cnpj).ToString("00\\.000\\.000\\/0000\\-00");
    }
}
