using Final.Repository.Abstractions.Repositories;
using Final.Repository.ListRepositories;
using Repository.Data.Example;
using Repository.Data.Types;
using System.Runtime.CompilerServices;

namespace Final.Repository.Repositories;
public class ListPeopleRepository : BaseListRepository<Person>, IPeopleRepository
{
    public ListPeopleRepository(ListExamplePeopleSource people) : base(people) { }

    public async IAsyncEnumerable<Person> GetByLastName(string lastName, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach(var person in Source.Where(x => x.LastName == lastName))
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            yield return person;
        }
    }

    public async IAsyncEnumerable<Person> GetByBirthYear(DateTime birthDate, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach (var person in Source.Where(x => x.BirthDate.Year == birthDate.Year))
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            yield return person;
        }
    }
}
