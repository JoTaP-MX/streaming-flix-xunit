# 🎬 StreamingFlix

![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![xUnit](https://img.shields.io/badge/Testes-xUnit-5C2D91?style=for-the-badge)
![License](https://img.shields.io/badge/Licença-MIT-green?style=for-the-badge)

Uma solução .NET que implementa as regras de negócio de um serviço de streaming, com cobertura de **testes unitários parametrizados** usando **xUnit**. 🍿

> [!NOTE]
> Este projeto foi desenvolvido como atividade prática da disciplina de **Garantia da Qualidade de Software**, com foco em testes parametrizados (`[Theory]` + `[InlineData]`) no ecossistema .NET.

---

## 📖 Sobre o projeto

O `PlanoStreamingService` concentra três regras de negócio de uma plataforma de streaming, cada uma retornando um tipo diferente — **string**, **int** e **bool**.

| Método | Retorno | O que faz |
|---|:---:|---|
| `ObterClassificacaoPorQualidade(telasSimultaneas)` | `string` | Retorna `"BÁSICO"` para 1 tela, `"PADRÃO"` para 2 telas e `"PREMIUM"` para 4 ou mais telas |
| `CalcularMensalidadeComDesconto(valorBase, mesesContratados)` | `int` | Aplica **10%** de desconto para contratos de 6 a 11 meses e **20%** para 12 meses ou mais |
| `PodeAcessarConteudoAdulto(idade, controleParentalAtivo)` | `bool` | Retorna `true` apenas se a idade for **≥ 18** **E** o controle parental estiver desativado |

---

## 🧪 Testes unitários

A suíte de testes, no projeto `StreamingFlix.Tests`, fica na classe `PlanoStreamingServiceTests` e utiliza `[Theory]` com `[InlineData]` para rodar o mesmo corpo de teste com vários conjuntos de dados. São **3 testes parametrizados**, que geram **9 casos de teste** no total.

### Teste 1 — Classificação de planos

| Entrada (telas) | Resultado esperado | Cenário |
|:---:|:---:|---|
| `1` | `"BÁSICO"` | Plano de entrada |
| `2` | `"PADRÃO"` | Plano intermediário |
| `4` | `"PREMIUM"` | Plano com 4 ou mais telas |

### Teste 2 — Cálculo de desconto

| Valor base | Meses | Resultado esperado | Cenário |
|:---:|:---:|:---:|---|
| `50` | `1` | `50` | Sem desconto |
| `50` | `6` | `45` | 10% de desconto |
| `50` | `12` | `40` | 20% de desconto |

### Teste 3 — Validação de acesso a conteúdo adulto

| Idade | Controle parental | Resultado esperado | Cenário |
|:---:|:---:|:---:|---|
| `20` | `false` | `true` | Maior de idade, sem restrição |
| `20` | `true` | `false` | Maior de idade, com restrição |
| `16` | `false` | `false` | Menor de idade |

> [!IMPORTANT]
> Cada linha de `[InlineData]` vira um caso de teste independente no relatório: se um caso falhar, apenas ele aparece como reprovado e os demais continuam passando.

### ✅ Resultado da execução

| Teste | Casos | Aprovados | Reprovados |
|---|:---:|:---:|:---:|
| Classificação de planos | 3 | 3 | 0 |
| Cálculo de desconto | 3 | 3 | 0 |
| Validação de acesso | 3 | 3 | 0 |
| **Total** | **9** | **9** | **0** |

---

## 🚀 Como executar

### Pré-requisitos

![.NET SDK](https://img.shields.io/badge/Requer-.NET%2010%20SDK-blue?style=flat-square)

Você precisa ter o [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado. Para conferir sua versão:

```bash
dotnet --version
```

### Instalação

```bash
git clone https://github.com/JoTaP-MX/streaming-flix-xunit.git
cd streaming-flix-xunit
```

### Rodando a aplicação

```bash
dotnet run --project StreamingFlix.App
```

### Rodando os testes

```bash
dotnet test
```

### Exemplo de saída

```text
Resumo do teste: total: 9; falhou: 0; bem-sucedido: 9; ignorado: 0
Construir êxito
```

---

## 🗂️ Estrutura da solução

```text
streaming-flix-xunit/
├── StreamingFlix.sln
├── StreamingFlix.App/
│   └── PlanoStreamingService.cs
├── StreamingFlix.Tests/
│   └── PlanoStreamingServiceTests.cs
├── .gitignore
├── LICENSE
└── README.md
```

### ⚙️ Como a solução foi criada

```bash
dotnet new sln -n StreamingFlix
dotnet new console -n StreamingFlix.App -f net10.0
dotnet new xunit -n StreamingFlix.Tests -f net10.0
dotnet sln add StreamingFlix.App/StreamingFlix.App.csproj
dotnet sln add StreamingFlix.Tests/StreamingFlix.Tests.csproj
dotnet add StreamingFlix.Tests/StreamingFlix.Tests.csproj reference StreamingFlix.App/StreamingFlix.App.csproj
```

---

## 🛠️ Tecnologias utilizadas

- 🟣 **.NET 10**
- 🧪 **xUnit** — framework de testes unitários (`[Theory]` + `[InlineData]`)
- 📦 Estrutura de solução com dois projetos: `StreamingFlix.App` (produção) e `StreamingFlix.Tests` (testes)

---

## 👤 Sobre o Autor

Feito com 💻 por **João Pedro Gonçalves**

---

## 📄 Licença

Este projeto está sob a licença **MIT**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.