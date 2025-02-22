using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigDemo;

class Program
{
    static void Main(string[] args)
    {
        // Configuração base usando appsettings.json e variáveis de ambiente
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        IConfiguration configuration = configurationBuilder.Build();

        // ============================================================
        //  1. Acesso direto via IConfiguration
        // ============================================================
        Console.WriteLine("[IConfiguration] Acesso direto:");
        Console.WriteLine($"ConnectionString: {configuration["MyAppSettings:ConnectionString"]}");
        Console.WriteLine($"MaxItems: {configuration["MyAppSettings:MaxItems"]}");

            
        // ============================================================
        // 2. Acesso via Variáveis de Ambiente
        // ============================================================
        // Para testar, você pode definir a variável de ambiente "MY_CONFIG_VALUE" no sistema.
        string envValue = Environment.GetEnvironmentVariable("MY_CONFIG_VALUE") ?? "valor padrão";
        Console.WriteLine("\n[Variável de Ambiente]:");
        Console.WriteLine($"MY_CONFIG_VALUE: {envValue}");

            
            
        // ============================================================
        // 3. Leitura de Arquivo de Configuração Customizado
        // ============================================================
        var customConfigPath = "customconfig.json";
        if (File.Exists(customConfigPath))
        {
            var customJson = File.ReadAllText(customConfigPath);
            var customConfig = JsonSerializer.Deserialize<MyAppSettings>(customJson);
            Console.WriteLine("\n[Arquivo Customizado - customconfig.json]:");
            Console.WriteLine($"ConnectionString: {customConfig?.ConnectionString}");
            Console.WriteLine($"MaxItems: {customConfig?.MaxItems}");
        }
        else
        {
            Console.WriteLine("\n[Arquivo Customizado]: Arquivo 'customconfig.json' não encontrado.");
        }

            
            
        // ============================================================
        // 4. Configuração via Options Pattern
        // ============================================================
        // Configurando o DI e registrando as opções
        var services = new ServiceCollection();

        // Registrando as configurações com validação (usando data annotations)
        services.AddOptions<MyAppSettings>()
            .Bind(configuration.GetSection("MyAppSettings"))
            .ValidateDataAnnotations();

            
        // Registrando serviços que dependem das configurações
        services.AddTransient<MyService>();
        services.AddTransient<MyServiceWithMonitor>();

        var serviceProvider = services.BuildServiceProvider();

            
        // Usando IOptions<T>
        var myService = serviceProvider.GetService<MyService>();
        myService?.DoWork();

            
        // Usando IOptionsMonitor<T> para monitoramento em tempo real
        var myServiceMonitor = serviceProvider.GetService<MyServiceWithMonitor>();
        myServiceMonitor?.DoWork();

        Console.WriteLine("\nPressione ENTER para finalizar...");
        Console.ReadLine();
    }
}