using CNPJ.Extensoes;
using System.ComponentModel.DataAnnotations;

namespace CPF_CNPJ_Test.CNPJ;

public class FormataCNPJTest
{
    private readonly string cnpjSemFormata = "00000000000000";
    private readonly string cnpjFormatado = "00.000.000/0000-00";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FormataTest()
    {
        var resultado = cnpjSemFormata.Formata();
        Assert.That(resultado, Is.EqualTo(cnpjFormatado));
    }

    [Test]
    public void FormataTest1()
    {
        var ex = Assert.Throws<ValidationException>(() => FormataCNPJ.Formata("aaaaa"));
        Assert.That(ex.Message, Is.EqualTo("O CNPJ deve conter 14 dígitos."));
    }

    [Test]
    public void FormataTest2()
    {
        var ex = Assert.Throws<ValidationException>(() => FormataCNPJ.Formata("0000000000aAAA"));
        Assert.That(ex.Message, Is.EqualTo("O CNPJ deve conter apenas números."));
    }

    [Test]
    public void LimparFormatacao()
    {
        var ex = Assert.Throws<ValidationException>(() => FormataCNPJ.LimparFormatacao("0000000000a"));
        Assert.That(ex.Message, Is.EqualTo("O CNPJ deve estar no formato XX.XXX.XXX/YYYY-ZZ."));
    }

    [Test]
    public void LimparFormatacao1()
    {
        var resultado = cnpjFormatado.LimparFormatacao();
        Assert.That(resultado, Is.EqualTo(cnpjSemFormata));
    }
}
