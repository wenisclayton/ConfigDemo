# ConfigDemo

Projeto demonstrando diversas abordagens para acessar configurações em uma aplicação .NET, comparando métodos tradicionais com o uso do Options Pattern.

## Sumário

- [Introdução](#introdução)
- [Pré-requisitos](#pré-requisitos)
- [Pacotes Necessários](#pacotes-necessários)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Arquivos de Configuração](#arquivos-de-configuração)
- [Implementação](#implementação)
  - [Acesso Sem Options Pattern](#acesso-sem-options-pattern)
  - [Acesso Com Options Pattern](#acesso-com-options-pattern)
- [Execução](#execução)
- [Conclusão](#conclusão)
- [Licença](#licença)

## Introdução

Este projeto tem como objetivo demonstrar diferentes maneiras de acessar configurações em C#. Inicialmente, são apresentadas abordagens tradicionais – como o uso direto de `IConfiguration`, variáveis de ambiente e leitura de arquivos customizados – e, em seguida, é demonstrado como o Options Pattern pode centralizar e melhorar o acesso às configurações, utilizando injeção de dependência e validação via data annotations.

## Pré-requisitos

- [.NET 6 ou superior](https://dotnet.microsoft.com/download) (o projeto foi testado com .NET 9)
- Ambiente de desenvolvimento (Visual Studio, VS Code, etc.)

## Pacotes Necessários

Para utilizar os recursos do projeto, instale os seguintes pacotes NuGet:

- **Microsoft.Extensions.Options**
- **Microsoft.Extensions.Configuration**
- **Microsoft.Extensions.Configuration.Json**
- **Microsoft.Extensions.DependencyInjection**
- **Microsoft.Extensions.Options.DataAnnotations**
- **Microsoft.Extensions.Options.ConfigurationExtensions**
- **Microsoft.Extensions.Configuration.EnvironmentVariables**

Você pode instalar via linha de comando:

```bash
dotnet add package Microsoft.Extensions.Options
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Options.DataAnnotations
dotnet add package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables
