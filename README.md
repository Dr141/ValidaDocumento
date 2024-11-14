### Projeto de biblioteca para validar e formatar CPF.
---

### Métodos CPF

1. Para formatar deve chamar o método `Formata(00000000000);`, da classe `FormataCPF`.
2. Para remover a formatação devem chamar o método `LimparFormatacao(000.000.000-00);`, da classe `FormataCPF`.
3. Para validar o dígito de verificação, chamar o método `CalculoDigitoVerificador(00000000000 ou 000.000.000-00)` , da classe `VerificadorCPF`.
---
### Métodos CNPJ

1. Para formatar deve chamar o método `Formata(00000000000000);`, da classe `FormataCNPJ`.
2. Para remover a formatação devem chamar o método `LimparFormatacao(00.000.000/0000-00);`, da classe `FormataCNPJ`.
3. Para validar o dígito de verificação, chamar o método `CalculoDigitoVerificador(00000000000000 ou 00.000.000/0000-00)` , da classe `VerificadorCNPJ`.
