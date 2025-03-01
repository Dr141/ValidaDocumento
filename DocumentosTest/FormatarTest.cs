using Documentos.Extensoes;
using System.ComponentModel.DataAnnotations;

namespace DocumentosTest;

public class FormatarTest
{
    private readonly string cnpjSemFormata = "00000000000000";
    private readonly string cnpjFormatado = "00.000.000/0000-00";
    private readonly string cpfSemFormata = "00000000000";
    private readonly string cpfFormatado = "000.000.000-00";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FormatarCPFTest1()
    {
        Assert.That(cpfSemFormata.FormatarCNPJ(), Is.EqualTo(cpfFormatado));
    }

    [Test]
    public void FormatarCPFTest2()
    {
        var ex = Assert.Throws<ValidationException>(() => Formatar.FormatarCPF("aaaaa"));
        Assert.That(ex.Message, Is.EqualTo("O CPF deve conter 11 dígitos."));
    }

    [Test]
    public void FormatarCPFTest3()
    {
        var ex = Assert.Throws<ValidationException>(() => Formatar.FormatarCPF("0000000000a"));
        Assert.That(ex.Message, Is.EqualTo("O CPF deve conter apenas números."));
    }

    [Test]
    public void FormatarCNPJTest1()
    {
        Assert.That(cnpjSemFormata.FormatarCNPJ(), Is.EqualTo(cnpjFormatado));
    }

    [Test]
    public void FormatarCNPJTest2()
    {
        var ex = Assert.Throws<ValidationException>(() => Formatar.FormatarCNPJ("aaaaa"));
        Assert.That(ex.Message, Is.EqualTo("O CNPJ deve conter 14 dígitos."));
    }

    [Test]
    public void FormatarCNPJTest3()
    {
        var ex = Assert.Throws<ValidationException>(() => Formatar.FormatarCNPJ("0000000000aAAA"));
        Assert.That(ex.Message, Is.EqualTo("O CNPJ deve conter apenas números."));
    }

    [Test]
    public void RemoverFormatacaoTest1()
    {
        Assert.That(cnpjFormatado.RemoverFormatacao(), Is.EqualTo(cnpjSemFormata));
    }

    [Test]
    public void RemoverFormatacaoTest2()
    {
        Assert.That(cpfFormatado.RemoverFormatacao(), Is.EqualTo(cpfSemFormata));
    }
}
