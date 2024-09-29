using Final.Repository.Abstractions.Repositories;

namespace Final.Repository.Abstractions.UnitOfWork;
public interface IUnitOfWork
{
    bool TransactionOpen { get; }
    Task StartTransaction(CancellationToken cancellationToken);
    Task CommitTransaction(CancellationToken cancellationToken);
    Task RollbackTransaction(CancellationToken cancellationToken);

    Task Attach(IRepository repository, CancellationToken cancellationToken);
    Task Detach(IRepository repository, CancellationToken cancellationToken);
}
