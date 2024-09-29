using Final.Repository.Abstractions.Repositories;
using Final.Repository.ListRepositories;
using Repository.Data.Example;
using Repository.Data.Types;

namespace Final.Repository.Repositories;
public class ListLaneRepository : BaseListRepository<Lane>, ILaneRepository
{
    public ListLaneRepository(ListExampleLaneSource lanes) : base(lanes) { }

    public async Task<Lane?> GetLaneByName(string name, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return Source.FirstOrDefault(x => x.Name == name);
    }

    public async Task<Lane?> GetLaneByIndex(int index, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return Source.FirstOrDefault(x => x.Index == index);
    }
}
