using Final.Repository.Abstractions.Repositories;
using Repository.Data.Types;
using System.Runtime.CompilerServices;

namespace Final.Repository.ListRepositories;
public class BaseListRepository<TObject> : IRepository<TObject> where TObject : BaseType
{
    protected List<TObject> Source = null!;
    private List<TObject> WorkingSet = null!;

    public BaseListRepository(List<TObject> objects)
    {
        Source = [.. objects];
        // Create a copy of everything in the working set
        WorkingSet = objects.Select(o => o with { }).ToList();
    }
    public async Task Delete(TObject @object, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        WorkingSet.Remove(@object);
    }

    public async Task<bool> Exists(string id, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return Source.Any(x => x.Id.ToString() == id);
    }

    public async Task<TObject?> Get(string id, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return Source.FirstOrDefault(x => x.Id.ToString() == id);
    }

    public async IAsyncEnumerable<TObject> Get(List<string> ids, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach (var id in ids)
        {
            var obj = Source.FirstOrDefault(x => x.Id.ToString() == id);
            if (obj != null)
            {
                yield return obj;
            }
        }
    }

    public async IAsyncEnumerable<TObject> GetAll(int skip, int take, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach (var p in Source.Skip(skip).Take(take))
        {
            if (p != null)
                yield return p;
        }
    }

    public async Task Save(TObject @object, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        WorkingSet.Add(@object);
    }

    public async Task<bool> SaveChanges(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Source = WorkingSet.Select(o => o with { }).ToList();

        return true;
    }

    public async Task Untrack(TObject @object, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // NOOP, untracking doesn't make sense in this context
    }

    public async Task UntrackAll(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // NOOP, untracking doesn't make sense in this context
    }

    public async Task Update(TObject @object, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var existing = Source.FirstOrDefault(x => x.Id == @object.Id);
        if (existing != null)
        {
            WorkingSet.Remove(existing);
            WorkingSet.Add(@object);
        }
    }
}
