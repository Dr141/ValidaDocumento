using CNPJ.Extensoes;
using System.ComponentModel.DataAnnotations;

namespace CPF_CNPJ_Test.CNPJ;

public class VerificadorCNPJTest
{
    private readonly string cnpjSemFormata = "44517700000123";
    private readonly string cnpjFormatado = "82.344.194/0001-07";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SemFormataTest()
    {
        Assert.IsTrue(cnpjSemFormata.CalculoDigitoVerificador());
    }

    [Test]
    public void FormatadoFormataTest()
    {
        Assert.IsTrue(cnpjFormatado.CalculoDigitoVerificador());
    }

    [Test]
    public void FormataTest1()
    {
        var ex = Assert.Throws<ValidationException>(() => VerificadorCNPJ.CalculoDigitoVerificador("aaaaa"));
        Assert.That(ex.Message, Is.EqualTo("O CNPJ deve conter 14 dígitos."));
    }
}
