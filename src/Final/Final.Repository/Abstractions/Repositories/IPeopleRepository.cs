using Repository.Data.Types;

namespace Final.Repository.Abstractions.Repositories;
public interface IPeopleRepository : IRepository<Person>
{
    IAsyncEnumerable<Person> GetByLastName(string lastName, CancellationToken cancellationToken);
    IAsyncEnumerable<Person> GetByBirthYear(DateTime birthDate, CancellationToken cancellationToken);
}
