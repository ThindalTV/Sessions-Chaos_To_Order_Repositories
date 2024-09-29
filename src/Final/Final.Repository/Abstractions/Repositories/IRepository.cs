using Repository.Data.Types;

namespace Final.Repository.Abstractions.Repositories;
public interface IRepository
{
    Task UntrackAll(CancellationToken cancellationToken);
    Task<bool> SaveChanges(CancellationToken cancellationToken);
}

public interface IRepository<TObject> : IRepository where TObject : BaseType
{
    IAsyncEnumerable<TObject> GetAll(int skip, int take, CancellationToken cancellationToken);
    Task<TObject?> Get(string id, CancellationToken cancellationToken);
    IAsyncEnumerable<TObject> Get(List<string> ids, CancellationToken cancellationToken);
    Task<bool> Exists(string id, CancellationToken cancellationToken);
    Task Untrack(TObject @object, CancellationToken cancellationToken);
    Task Save(TObject @object, CancellationToken cancellationToken);
    Task Delete(TObject @object, CancellationToken cancellationToken);
    Task Update(TObject @object, CancellationToken cancellationToken);
}
