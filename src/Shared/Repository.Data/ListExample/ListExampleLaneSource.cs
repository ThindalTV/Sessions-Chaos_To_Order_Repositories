using Repository.Data.Types;

namespace Repository.Data.Example;
public class ListExampleLaneSource : List<Lane>
{
    public ListExampleLaneSource()
    {
        AddRange(
            [
            new Lane() { Id = "1", Name = "Planned", Index = 1 },
            new Lane() { Id = "2", Name = "Commited", Index = 2 },
            new Lane() { Id = "3", Name = "In Progress", Index = 3 },
            new Lane() { Id = "4", Name = "Testing", Index = 4 },
            new Lane() { Id = "5", Name = "Complete", Index = 5 }
            ]
        );
    }
}
