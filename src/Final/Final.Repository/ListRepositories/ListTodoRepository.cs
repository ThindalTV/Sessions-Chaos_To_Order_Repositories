using Final.Repository.Abstractions.Repositories;
using Final.Repository.ListRepositories;
using Repository.Data.Example;
using Repository.Data.Types;
using System.Runtime.CompilerServices;

namespace Final.Repository.Repositories;
internal class ListTodoRepository : BaseListRepository<Todo>, ITodoRepository
{
    public ListTodoRepository(ListExampleTodoSource todos) : base(todos) { }

    public async IAsyncEnumerable<Todo> GetTodosByLaneId(string laneId, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach (var todo in Source.Where(t => t.LaneId == laneId))
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            yield return todo;
        }
    }

    public async IAsyncEnumerable<Todo> GetTodosByPersonId(string personId, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach (var todo in Source.Where(t => t.AssigneeId == personId))
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            yield return todo;
        }
    }

    public async IAsyncEnumerable<Todo> Search(string searchTerm, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach (var todo in Source.Where(t => TodoMatchesSearch(t, searchTerm)))
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            yield return todo;
        }
    }

    private bool TodoMatchesSearch(Todo todo, string searchTerm)
    {
        if (todo.Title != null && todo.Description != null)
        {
            return todo.Title.Contains(searchTerm) || todo.Description.Contains(searchTerm);
        }
        return false;
    }
}
    