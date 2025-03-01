# ValidaDocumento

Projeto `ValidaDocumento` é uma biblioteca que fornece métodos para validação, formatação e manipulação de documentos brasileiros (CPF e CNPJ).

## Funcionalidades

- ✅ Validação de CPF e CNPJ com base nos dígitos verificadores.
- ✅ Formatação de CPF e CNPJ.
- ✅ Remoção de formatação de CPF e CNPJ.

---

## Classes e Métodos

### Verificador
Classe responsável por implementar a validação de CPF e CNPJ.

#### Métodos

##### `VerificadorCpf(string cpf)`

Verifica se um CPF informado é válido.

- **Parâmetro**: 
    - `cpf` - Número do CPF no formato `string`.
- **Retorno**: 
    - `bool` - `true` se for válido, `false` se for inválido.
- **Exceção**: 
    - `ValidationException` - Lançada quando o CPF é inválido ou contém erros.

##### `VerificadorCnpj(string cnpj)`

Verifica se um CNPJ informado é válido.

- **Parâmetro**: 
    - `cnpj` - Número do CNPJ no formato `string`.
- **Retorno**: 
    - `bool` - `true` se for válido, `false` se for inválido.
- **Exceção**: 
    - `ValidationException` - Lançada quando o CNPJ é inválido ou contém erros.

---

### Formatar
Classe responsável por formatar e desformatar documentos.

#### Métodos

##### `FormatarCPF(string cpf)`

Formata um CPF no padrão `000.000.000-00`.

- **Parâmetro**: 
    - `cpf` - Número do CPF no formato `string`.
- **Retorno**: 
    - `string` - CPF formatado.
- **Exceção**: 
    - `ValidationException` - Lançada se o CPF for inválido.

##### `FormatarCNPJ(string cnpj)`

Formata um CNPJ no padrão `00.000.000/0000-00`.

- **Parâmetro**: 
    - `cnpj` - Número do CNPJ no formato `string`.
- **Retorno**: 
    - `string` - CNPJ formatado.
- **Exceção**: 
    - `ValidationException` - Lançada se o CNPJ for inválido.

##### `RemoverFormatacao(string documento)`

Remove a formatação de CPF ou CNPJ.

- **Parâmetro**: 
    - `documento` - Número do CPF ou CNPJ no formato `string`.
- **Retorno**: 
    - `string` - Documento sem formatação.

---

## Exemplo de Uso

```csharp
using Documentos.Extensoes;

public class Exemplo
{
    public void ValidarDocumentos()
    {
        string cpf = "123.456.789-09";
        string cnpj = "12.345.678/0001-95";

        if (cpf.VerificadorCpf())
        {
            Console.WriteLine("CPF válido!");
        }
        
        if (cnpj.VerificadorCnpj())
        {
            Console.WriteLine("CNPJ válido!");
        }

        string cpfFormatado = cpf.RemoverFormatacao();
        Console.WriteLine($"CPF formatado: {cpfFormatado}");

        string cnpjFormatado = cnpj.RemoverFormatacao();
        Console.WriteLine($"CNPJ formatado: {cnpjFormatado}");
    }
}
