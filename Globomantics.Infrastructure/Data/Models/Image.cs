namespace Globomantics.Infrastructure.Data.Models;

public class Image
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public byte[] ImageData { get; set; } = default!;
}
