using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MyStore.Domain.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Slug { get; private set; } = string.Empty;

    private readonly List<Product> _products = [];
    public IReadOnlyCollection<Product> Products => _products;

    protected Category() { }

    public Category(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
        Slug = GenerateSlug(name);
    }

    private static string GenerateSlug(string text)
    {
        var str = text.ToLowerInvariant().Trim();

        var normalized = str.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }

        str = sb.ToString().Normalize(NormalizationForm.FormC);
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
        str = Regex.Replace(str, @"[\s-]+", "-");
        str = str.Trim('-');

        return str;
    }
}