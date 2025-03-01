using Documentos.Extensoes;
using System.ComponentModel.DataAnnotations;

namespace DocumentosTest;

public class VerificadorTest
{
    private readonly string cpfSemFormata = "62936381070";
    private readonly string cpfFormatado = "222.075.730-79";
    private readonly string cpfErrado = "0000000000a";
    private readonly string cnpjSemFormata = "44517700000123";
    private readonly string cnpjFormatado = "82.344.194/0001-07";
    private readonly string cnpjErrado = "4451770000012a";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void VerificadorCpfTest1()
    {
        var result = Assert.Throws<ValidationException>(() => cpfSemFormata.VerificadorCpf());
        Assert.That(result.Message, Is.EqualTo("O CPF deve conter 11 dígitos."));
    }

    [Test]
    public void VerificadorCpfTest2()
    {
        Assert.That(cpfFormatado.VerificadorCpf(), Is.EqualTo(true));
    }


    [Test]
    public void VerificadorCpfTest3()
    {
        var result = Assert.Throws<ValidationException>(() => cpfErrado.VerificadorCpf());
        Assert.That(result.Message, Is.EqualTo("O CPF deve conter 11 dígitos."));
    }

    [Test]
    public void VerificadorCnpjTest1()
    {
        Assert.That(cnpjFormatado.VerificadorCnpj(), Is.EqualTo(true));
    }

    [Test]
    public void VerificadorCnpjTest2()
    {
        var ex = Assert.Throws<ValidationException>(() => cnpjSemFormata.VerificadorCnpj());
        Assert.That(ex.Message, Is.EqualTo("O CNPJ deve conter 14 dígitos."));
    }


    [Test]
    public void VerificadorCnpjTest3()
    {
        var ex = Assert.Throws<ValidationException>(() => cnpjErrado.VerificadorCnpj());
        Assert.That(ex.Message, Is.EqualTo("O CNPJ deve conter 14 dígitos."));
    }
}
