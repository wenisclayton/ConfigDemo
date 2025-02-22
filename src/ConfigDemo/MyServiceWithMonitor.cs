using Microsoft.Extensions.Options;

namespace ConfigDemo;


// Serviço demonstrando o uso do IOptionsMonitor<T>
public class MyServiceWithMonitor
{
    private readonly IOptionsMonitor<MyAppSettings> _optionsMonitor;

    public MyServiceWithMonitor(IOptionsMonitor<MyAppSettings> optionsMonitor)
    {
        _optionsMonitor = optionsMonitor;
        // Subscrevendo para monitorar mudanças nas configurações
        _optionsMonitor.OnChange(newOptions =>
        {
            Console.WriteLine("\n[Options Monitor] MyAppSettings foram alteradas!");
            Console.WriteLine($"Nova ConnectionString: {newOptions.ConnectionString}");
            Console.WriteLine($"Novo MaxItems: {newOptions.MaxItems}");
        });
    }

    public void DoWork()
    {
        var settings = _optionsMonitor.CurrentValue;
        Console.WriteLine("\n[Options Pattern - IOptionsMonitor<T>] em MyServiceWithMonitor:");
        Console.WriteLine($"ConnectionString: {settings.ConnectionString}");
        Console.WriteLine($"MaxItems: {settings.MaxItems}");
    }
}