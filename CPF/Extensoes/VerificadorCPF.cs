using CPF.Negocios;
using System.Text.RegularExpressions;

namespace CPF.Extensoes;

public static class VerificadorCPF
{
    /// <summary>
    /// Método para verificar se o número do CPF é valido.
    /// </summary>
    /// <param name="numeroCPF"> O parâmetro espera uma <see cref="string"/> com os formato 000.000.000-00 ou 00000000000.</param>
    /// <returns>
    /// O método retorna uma <see cref="bool"/> com o valor verdadeiro, caso o número do CPF seja valido.
    /// </returns>
    public static bool CalculoDigitoVerificador(this string numeroCPF)
    {
        try
        {
            string cpf = Regex.Replace(numeroCPF, "[. -]", "", RegexOptions.IgnoreCase);
            cpf.ValidarCPFSemFormata();
            return CalculoDigitoVerificadorInterno(cpf);
        }
        catch { throw; }
    }

    private static bool CalculoDigitoVerificadorInterno(string numeroCPF)
    {
        if (numeroCPF.Length != 11)
            return false;

        string numerosCpf = numeroCPF.Substring(0, 9);

        for (int x = 0; x < 2; x++)
        {
            int contador = (x == 0) ? 10 : 11;
            int auxiliar = 0;
            for (int i = 0; i < numerosCpf.Length; i++)
            {
                auxiliar += (numerosCpf[i] - '0') * contador;
                contador--;
            }

            numerosCpf += EncontrarDigito(auxiliar);
        }

        return numerosCpf.Equals(numeroCPF);
    }

    /// <summary>
    /// Método para encontrar digito verificador.
    /// </summary>
    /// <param name="valor"></param>
    /// <returns>Retorna um número <see cref="int"/></returns>
    private static int EncontrarDigito(int valor)
    {
        int resultado = valor % 11;
        return resultado == 0 || resultado == 1 ? 0 : 11 - resultado;
    }
}