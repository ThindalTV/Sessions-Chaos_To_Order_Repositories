using Repository.Data.Types;

namespace Repository.Data.Example;
public class ListExampleTodoSource : List<Todo>
{
    public ListExampleTodoSource()
    {
        AddRange(
            [

                new Todo { Title = "Fill taskboard" , LaneId = "1" },
                new Todo { Title = "Make coffee" , AssigneeId = "1", LaneId = "1" },
                new Todo { Title = "Plan coffee" , AssigneeId = "1", LaneId = "5" },
                new Todo { Title = "Buy coffee"  , AssigneeId = "2", LaneId = "2" },
                new Todo { Title = "Ask who might want tea" , AssigneeId = "2", LaneId = "2" },
                new Todo { Title = "Fill watertank" , AssigneeId = "2", LaneId = "2" },
                new Todo { Title = "Steal Alices food from the fridge" ,  LaneId = "5" },
                new Todo { Title = "Lock the door" , AssigneeId = "4", LaneId = "4" },
            ]
         );
    }
}
