using CNPJ.Negocios;

namespace CNPJ.Extensoes
{
    public static class FormataCNPJ
    {
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
