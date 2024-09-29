namespace Repository.Data.Types;
public record Todo : BaseType
{
    public string? AssigneeId { get; set; }
    public string? LaneId { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }

}
