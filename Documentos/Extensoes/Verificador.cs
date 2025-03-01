using Documentos.Negocios;

namespace Documentos.Extensoes;

/// <summary>
/// Classe que implementa os métodos de validação do digito verificador de CPF/CNPJ.
/// </summary>
public static class Verificador
{
    /// <summary>
    /// Método para verificar se o CPF é valido.
    /// </summary>
    /// <param name="cpf"></param>
    /// <returns></returns>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    public static bool VerificadorCpf(this string cpf)
    {
        string numeroCpf = cpf.RemoverFormatacao();
        numeroCpf.ValidarCPFSemFormatacao();
        return numeroCpf.CalculoDigitoVerificadorCpf();
    }

    /// <summary>
    /// Método para verificar se o CNPJ é valido.
    /// </summary>
    /// <param name="cnpj"></param>
    /// <returns></returns>
    /// <exception cref="ValidationException">Rertona uma exception com os erros encontrado no documento.</exception>
    public static bool VerificadorCnpj(this string cnpj)
    {
        string numeroCnpj = cnpj.RemoverFormatacao();
        numeroCnpj.ValidaCnpjSemFormatacao();
        return numeroCnpj.CalculoDigitoVerificadorCnpj();
    }    
}
