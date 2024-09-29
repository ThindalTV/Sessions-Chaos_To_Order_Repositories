namespace Repository.Data.Types;
public record Lane : BaseType
{
    public string? Name { get; set; }
    public int Index { get; set; }
}
