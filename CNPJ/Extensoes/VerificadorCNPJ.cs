using CNPJ.Negocios;
using System.Text.RegularExpressions;

namespace CNPJ.Extensoes;

public static class VerificadorCNPJ
{
    /// <summary>
    /// Método para verificar se o número do CNPJ é valido.
    /// </summary>
    /// <param name="numeroCNPJ"> O parâmetro espera uma <see cref="string"/> com os formato 00.000.000/0000-00 ou 00000000000000.</param>
    /// <returns>
    /// O método retorna uma <see cref="bool"/> com o valor verdadeiro, caso o número do CNPJ seja valido.
    /// </returns>
    public static bool CalculoDigitoVerificador(this string numeroCNPJ)
    {
        try
        {
            string cnpj = Regex.Replace(numeroCNPJ, @"[.\-\/]", "", RegexOptions.IgnoreCase);
            cnpj.ValidarCNPJSemFormata();
            return CalculoDigitoVerificadorInterno(cnpj);
        }
        catch { throw; }
    }

    private static bool CalculoDigitoVerificadorInterno(string numeroCNPJ)
    {
        int auxiliar = 0;
        int contador = 2;
        List<char> blocoCompleto = numeroCNPJ.ToCharArray(0, 12).ToList();
        IEnumerable<char> primeiroBloco = blocoCompleto.Take(4).Reverse();
        IEnumerable<char> segundoBloco = blocoCompleto.Skip(4).Reverse();

        foreach (char c in primeiroBloco)
        {
            auxiliar += int.Parse(c.ToString()) * contador;
            contador++;
        }

        contador = 2;
        foreach (char c in segundoBloco)
        {
            auxiliar += int.Parse(c.ToString()) * contador;
            contador++;
        }

        blocoCompleto.Add(EncontrarDigito(auxiliar));
        auxiliar = 0;
        contador = 2;
        primeiroBloco = blocoCompleto.Take(5).Reverse();
        segundoBloco = blocoCompleto.Skip(5).Reverse();

        foreach (char c in primeiroBloco)
        {
            auxiliar += int.Parse(c.ToString()) * contador;
            contador++;
        }

        contador = 2;
        foreach (char c in segundoBloco)
        {
            auxiliar += int.Parse(c.ToString()) * contador;
            contador++;
        }

        blocoCompleto.Add(EncontrarDigito(auxiliar));

        return string.Concat(blocoCompleto).Equals(numeroCNPJ);
    }

    private static char EncontrarDigito(int valor)
    {
        int resto = valor % 11;
        if ((resto - 11) == 10 || resto == 0)
        {
            return '0';
        }

        int resultado = 11 - resto;
        return char.Parse(resultado.ToString());
    }
}
