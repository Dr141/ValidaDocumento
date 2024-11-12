using CNPJ.Negocios;

namespace CNPJ.Extensoes
{
    public static class FormataCNPJ
    {
        /// <summary>
        /// Método responsável por formata o número do CNPJ para o padrão 00.000.000/0000-00.
        /// </summary>
        /// <param name="numeroCNPJ">O parâmetro espera uma <see cref="string"/> com números com 14 dígitos.</param>
        /// <returns>
        /// O método retorna uma <see cref="string"/> com o CEP no seguinte formato: 00.000.000/0000-00.
        /// </returns>
        public static string Formata(this string numeroCNPJ)
        {
            try
            {
                numeroCNPJ.ValidarCNPJSemFormata();
                char[] cnpj = numeroCNPJ.ToCharArray();
                return $"{string.Concat(cnpj.Take(2))}.{string.Concat(cnpj.Skip(2).Take(3))}.{string.Concat(cnpj.Skip(5).Take(3))}/{string.Concat(cnpj.Skip(8).Take(4))}-{string.Concat(cnpj.Skip(12).Take(2))}";
            }
            catch { throw; }
        }

        /// <summary>
        /// Método responsável por remover a formatação no número do CNPJ.
        /// </summary>
        /// <param name="numeroCNPJ">O parâmetro espera uma <see cref="string"/> com o seguinte formato 00.000.000/0000-00.</param>
        /// <returns>
        /// O método retorna uma <see cref="string"/> com o CNPJ no seguinte formato: 00000000000000.
        /// </returns>
        public static string LimparFormatacao(this string numeroCNPJ)
        {
            try
            {
                numeroCNPJ.ValidarCNPJormatado();
                return numeroCNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
            }
            catch { throw; }
        }
    }
}
