namespace Documentos.Negocios;

/// <summary>
/// Classe para calcular digito verificados de CPF e CNPJ.
/// </summary>
internal static class CalcularVerificador
{
    /// <summary>
    /// Método para verificar se o número do CPF é valido.
    /// </summary>
    /// <param name="numeroCPF"></param>
    /// <returns>O método retorna <see cref="true"/> se o número for valido.</returns>
    internal static bool CalculoDigitoVerificadorCpf(this string numeroCPF)
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
                //A subtração de um char por '0' converte o valor em um número inteiro.
                auxiliar += (numerosCpf[i] - '0') * contador;
                contador--;
            }

            numerosCpf += EncontrarDigito(auxiliar);
        }

        return numerosCpf.Equals(numeroCPF);
    }

    /// <summary>
    /// Método para verificar se o número do CNPJ é valido.
    /// </summary>
    /// <param name="numeroCNPJ"></param>
    /// <returns>O método retorna <see cref="true"/> se o número for valido.</returns>
    internal static bool CalculoDigitoVerificadorCnpj(this string numeroCNPJ)
    {
        if (numeroCNPJ.Length != 14)
            return false;

        //Pega apenas a parte sem o digito verificador
        string blocoCompleto = numeroCNPJ.Substring(0, 12);
        //Soma os dois blocos de calculo do CNPJ
        int somatorioBlocos = CalculoBloco(blocoCompleto.Substring(0, 4)) + CalculoBloco(blocoCompleto.Substring(4, 8));
        //Concaterna o primeiro digito encontrado no blocoCompleto
        blocoCompleto += EncontrarDigito(somatorioBlocos);
        //Soma os dois blocos de calculo do CNPJ novamente, agora pegando 5 números no primero bloco
        somatorioBlocos = CalculoBloco(blocoCompleto.Substring(0, 5)) + CalculoBloco(blocoCompleto.Substring(5, 8));
        //Concaterna o segundo digito encontrado no blocoCompleto
        blocoCompleto += EncontrarDigito(somatorioBlocos);

        return blocoCompleto.Equals(numeroCNPJ);
    }

    /// <summary>
    /// Método para calcular os bloco de números do CNPJ.
    /// </summary>
    /// <param name="blocoDeNumero"></param>
    /// <returns>Retorna um <see cref="int"/> com o resultado do calculo do bloco</returns>
    private static int CalculoBloco(string blocoDeNumero)
    {
        int contador = 2;
        int auxiliar = 0;
        for (int i = blocoDeNumero.Length - 1; i >= 0; i--)
        {
            //A subtração de um char por '0' converte o valor em um número inteiro.
            auxiliar += (blocoDeNumero[i] - '0') * contador;
            contador++;
        }

        return auxiliar;
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