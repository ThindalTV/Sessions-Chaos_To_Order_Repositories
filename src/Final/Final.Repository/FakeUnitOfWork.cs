using Final.Repository.Abstractions.Repositories;
using Final.Repository.Abstractions.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Repository;
public class FakeUnitOfWork : IUnitOfWork
{ 
    public bool TransactionOpen { get; private set; }

    private readonly List<IRepository> _repositories = new();

    public async Task StartTransaction(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // NOOP
        TransactionOpen = true;
    }

    public async Task CommitTransaction(CancellationToken cancellationToken)
    {
        foreach(var repository in _repositories)
        {
            await repository.SaveChanges(cancellationToken);
        }
        TransactionOpen = false;
    }

    public async Task RollbackTransaction(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // NOOP
        TransactionOpen = false;
    }

    public async Task Attach(IRepository repository, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        _repositories.Add(repository);
    }

    public async Task Detach(IRepository repository, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        _repositories.Remove(repository);
    }
}
