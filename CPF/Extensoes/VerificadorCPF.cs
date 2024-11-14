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
        int auxiliar = 0;
        int contador = 1;
        List<char> numerosCalculo = numeroCPF.ToCharArray(0, 9).ToList();
        List<char> digitoInformado = numeroCPF.ToCharArray(9, 2).ToList();

        foreach (char c in numerosCalculo) 
        {
            auxiliar += int.Parse(c.ToString()) * contador;
            contador++;
        }

        numerosCalculo.Add(EncontrarDigito(auxiliar));
        auxiliar = 0;
        contador = 0;

        foreach (char c in numerosCalculo)
        {
            auxiliar += int.Parse(c.ToString()) * contador;
            contador++;
        }

        numerosCalculo.Add(EncontrarDigito(auxiliar));

        return string.Concat(numerosCalculo).Equals(numeroCPF);
    }

    private static char EncontrarDigito(int valor)
    {
        if(valor % 11 == 10)
        {
            return '0';
        }

        int resultado = valor % 11;
        return char.Parse(resultado.ToString());
    }
}