using CPF.Extensoes;
using System.ComponentModel.DataAnnotations;

namespace CPF_CNPJ_Test.CPF;

public class FormataCPFTest
{
    private readonly string cpfSemFormata = "00000000000";
    private readonly string cpfFormatado = "000.000.000-00";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FormataTest()
    {
        var resultado = cpfSemFormata.Formata();
        Assert.That(resultado, Is.EqualTo(cpfFormatado));
    }

    [Test]
    public void FormataTest1()
    {
        var ex = Assert.Throws<ValidationException>(() => FormataCPF.Formata("aaaaa"));
        Assert.That(ex.Message, Is.EqualTo("O CPF deve conter 11 dígitos."));
    }

    [Test]
    public void FormataTest2()
    {
        var ex = Assert.Throws<ValidationException>(() => FormataCPF.Formata("0000000000a"));
        Assert.That(ex.Message, Is.EqualTo("O CPF deve conter apenas números."));
    }

    [Test]
    public void LimparFormatacao()
    {
        var ex = Assert.Throws<ValidationException>(() => FormataCPF.LimparFormatacao("0000000000a"));
        Assert.That(ex.Message, Is.EqualTo("O CPF deve estar no formato 000.000.000-00."));
    }

    [Test]
    public void LimparFormatacao1()
    {
        var resultado = cpfFormatado.LimparFormatacao();
        Assert.That(resultado, Is.EqualTo(cpfSemFormata));
    }
}
