namespace Repository.Data.Types;
public record Person : BaseType
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
}
