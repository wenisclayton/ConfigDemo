using Microsoft.Extensions.Options;

namespace ConfigDemo;

// Serviço demonstrando o uso do Options Pattern via IOptions<T>
public class MyService(IOptions<MyAppSettings> options)
{
    private readonly MyAppSettings _settings = options.Value;

    public void DoWork()
    {
        Console.WriteLine("\n[Options Pattern - IOptions<T>] em MyService:");
        Console.WriteLine($"ConnectionString: {_settings.ConnectionString}");
        Console.WriteLine($"MaxItems: {_settings.MaxItems}");
    }
}