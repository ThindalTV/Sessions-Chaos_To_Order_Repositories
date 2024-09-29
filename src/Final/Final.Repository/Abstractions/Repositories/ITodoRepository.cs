using Repository.Data.Types;

namespace Final.Repository.Abstractions.Repositories;
public interface ITodoRepository : IRepository<Todo>
{
    public IAsyncEnumerable<Todo> GetTodosByLaneId(string laneId, CancellationToken cancellationToken);
    public IAsyncEnumerable<Todo> GetTodosByPersonId(string personId, CancellationToken cancellationToken);
    public IAsyncEnumerable<Todo> Search(string searchTerm, CancellationToken cancellationToken);
}
