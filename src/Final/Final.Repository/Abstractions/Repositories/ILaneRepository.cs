using Repository.Data.Types;

namespace Final.Repository.Abstractions.Repositories;
public interface ILaneRepository : IRepository<Lane>
{
    Task<Lane?> GetLaneByName(string name, CancellationToken cancellationToken);
    Task<Lane?> GetLaneByIndex(int index, CancellationToken cancellationToken);
}
