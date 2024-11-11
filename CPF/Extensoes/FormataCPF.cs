using CPF.Negocios;
namespace CPF.Extensoes;

public static class FormataCPF
{
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

    public static string LimparFormatacao(this string numeroCPF)
    {
        try
        {
            numeroCPF.ValidarCPFormatado();
            return numeroCPF.Replace(".", "").Replace("-", "");
        }
        catch { throw; }
    }
}
