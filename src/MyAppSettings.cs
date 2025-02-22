using System.ComponentModel.DataAnnotations;

namespace ConfigDemo;

// Classe de configuração para Options Pattern e leitura customizada
public class MyAppSettings
{
    [Required]
    public string? ConnectionString { get; set; }

    [Range(1, 100)]
    public int? MaxItems { get; set; }
}