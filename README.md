# ConfigDemo

Projeto demonstrando diversas abordagens para acessar configurações em uma aplicação .NET, comparando métodos tradicionais com o uso do Options Pattern.

## Sumário

- [ConfigDemo](#configdemo)
  - [Sumário](#sumário)
  - [Introdução](#introdução)
  - [Pré-requisitos](#pré-requisitos)
  - [Pacotes Necessários](#pacotes-necessários)
  - [Estrutura do Projeto](#estrutura-do-projeto)
  - [Arquivos de Configuração](#arquivos-de-configuração)
    - [appsettings.json](#appsettingsjson)
    - [customconfig.json](#customconfigjson)
  - [Implementação](#implementação)
      - [Acesso Sem Options Pattern](#acesso-sem-options-pattern)
  - [Acesso Com Options Pattern](#acesso-com-options-pattern)
  - [Execução](#execução)
  - [Conclusão](#conclusão)

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
```

## Estrutura do Projeto

ConfigDemo/  
├── src/appsettings.json  
├── src/customconfig.json  
├── src/MyAppSettings.cs  
├── src/MyService.cs  
├── src/MyServiceWithMonitor.cs  
└── src/Program.cs  

* **appsettings.json:**: Arquivo principal de configuração.
* **customconfig.json**: Arquivo opcional para leitura customizada de configurações.
* **MyAppSettings.cs**: Classe de configuração para Options Pattern e leitura customizada.
* **MyService.cs**: Serviço demonstrando o uso do Options Pattern via IOptions\<T>\.
* **MyServiceWithMonitor.cs**: Serviço demonstrando o uso do IOptionsMonitor\<T>\.
* **Program.cs:**: Contém a implementação das abordagens para acesso às configurações.

## Arquivos de Configuração

### appsettings.json  
Arquivo de configuração principal que contém a seção **MyAppSettings**:

```c#
{
  "MyAppSettings": {
    "ConnectionString": "Server=myServer;Database=myDB;User Id=myUser;Password=myPassword;",
    "MaxItems": 50
  }
}
```

### customconfig.json  
Arquivo opcional que demonstra a leitura customizada de configurações:

```c#
{
  "ConnectionString": "Server=myCustomServer;Database=myCustomDB;",
  "MaxItems": 20
}
```

## Implementação
#### Acesso Sem Options Pattern

No `Program.cs` são implementadas as seguintes abordagens tradicionais:

`IConfiguration`: Leitura direta dos valores através de chaves.
`Variáveis de Ambiente`: Uso de `Environment.GetEnvironmentVariable` para recuperar configurações definidas no sistema.
`Arquivo Customizado`: Leitura de um arquivo JSON customizado utilizando `JsonSerializer`.

## Acesso Com Options Pattern
Utilizando o Options Pattern, as configurações são agrupadas em uma classe fortemente tipada:

* **Classe** `MyAppSettings`: Representa a seção de configurações e inclui data annotations para validação.  
* **Serviço** `MyService`: Demonstra a injeção de `IOptions<MyAppSettings>` para acesso às configurações.  
* **Serviço** `MyServiceWithMonitor`: Demonstra o uso do `IOptionsMonitor<MyAppSettings>` para monitorar alterações nas configurações em tempo real.  


A configuração do DI (Injeção de Dependência) é realizada utilizando o `ServiceCollection`, registrando os serviços e as opções para possibilitar uma abordagem centralizada e validada.

## Execução
Para executar o projeto, utilize o seguinte comando:
```bash
dotnet run
```

Durante a execução, o console exibirá os valores de configuração lidos por meio das diferentes abordagens. Se o arquivo appsettings.json for modificado (com reloadOnChange habilitado), o serviço que utiliza IOptionsMonitor<T> detectará e exibirá as alterações.

## Conclusão
Este projeto demonstra a evolução das técnicas de acesso a configurações em .NET, evidenciando as vantagens do Options Pattern em relação aos métodos tradicionais. Ao utilizar uma abordagem fortemente tipada e validada, o Options Pattern facilita a manutenção e melhora a confiabilidade das configurações em aplicações de qualquer escala.