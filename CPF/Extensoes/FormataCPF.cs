using CPF.Negocios;
using System.Text.RegularExpressions;
namespace CPF.Extensoes;

public static class FormataCPF
{
    /// <summary>
    /// Método responsável por formata o número do CPF para o padrão 000.000.000-00.
    /// </summary>
    /// <param name="numeroCPF">O parâmetro espera uma <see cref="string"/> com números com 11 dígitos.</param>
    /// <returns>
    /// O método retorna uma <see cref="string"/> com o CPF no seguinte formato: 000.000.000-00.
    /// </returns>
    public static string Formata(this string numeroCPF)
    {
        try
        {
            numeroCPF.ValidarCPFSemFormata();
            char[] arrayCpf = numeroCPF.ToCharArray();
            return $"{string.Concat(arrayCpf.Take(3))}.{string.Concat(arrayCpf.Skip(3).Take(3))}.{string.Concat(arrayCpf.Skip(6).Take(3))}-{string.Concat(arrayCpf.Skip(9).Take(2))}";
        }
        catch { throw; }
    }

    /// <summary>
    /// Método responsável por remover a formatação no número do CPF.
    /// </summary>
    /// <param name="numeroCPF">O parâmetro espera uma <see cref="string"/> com o seguinte formato 000.000.000-00.</param>
    /// <returns>
    /// O método retorna uma <see cref="string"/> com o CPF no seguinte formato: 00000000000.
    /// </returns>
    public static string LimparFormatacao(this string numeroCPF)
    {
        try
        {
            numeroCPF.ValidarCPFormatado();
            return Regex.Replace(numeroCPF, "[. -]", "", RegexOptions.IgnoreCase);
        }
        catch { throw; }
    }
}
