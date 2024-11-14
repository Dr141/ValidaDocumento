using CPF.Extensoes;
using System.ComponentModel.DataAnnotations;

namespace CPF_CNPJ_Test.CPF;

public class VerificadorCPFTest
{
    private readonly string cpfSemFormata = "62936381070";
    private readonly string cpfFormatado = "222.075.730-79";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SemFormataTest()
    {
        Assert.IsTrue(cpfSemFormata.CalculoDigitoVerificador());
    }

    [Test]
    public void FormatadoFormataTest()
    {
        Assert.IsTrue(cpfFormatado.CalculoDigitoVerificador());
    }

    [Test]
    public void Test1()
    {
        var ex = Assert.Throws<ValidationException>(() => FormataCPF.Formata("aaaaa"));
        Assert.That(ex.Message, Is.EqualTo("O CPF deve conter 11 dígitos."));
    }

    [Test]
    public void Test2()
    {
        var ex = Assert.Throws<ValidationException>(() => FormataCPF.Formata("0000000000a"));
        Assert.That(ex.Message, Is.EqualTo("O CPF deve conter apenas números."));
    }
}
