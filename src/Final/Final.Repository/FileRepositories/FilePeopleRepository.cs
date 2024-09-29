using Final.Repository.Abstractions.Repositories;
using Repository.Data.Types;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Final.Repository.FileRepositories;
public class FilePeopleRepository : IPeopleRepository
{
    private readonly string _baseDir = "People";

    private List<Person> _dataToUpdate = new List<Person>();
    private List<Person> _dataToDelete = new List<Person>();
    private List<Person> _dataToAdd = new List<Person>();

    public FilePeopleRepository()
    {
        // Make sure the basedir exists
        if (!Directory.Exists(_baseDir))
        {
            Directory.CreateDirectory(_baseDir);
        }
    }

    public async Task Delete(Person @object, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        _dataToDelete.Add(@object);
    }

    public async Task<bool> Exists(string id, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return File.Exists(Path.Combine(_baseDir, id));
    }

    public async Task<Person?> Get(string id, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (File.Exists(_baseDir + id))
        {
            return JsonSerializer.Deserialize<Person>(File.ReadAllText(Path.Combine(_baseDir, id)));
        }
        return null;
    }

    public async IAsyncEnumerable<Person> Get(List<string> ids, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (var id in ids)
        {
            var p = await Get(id, cancellationToken);
            if (p != null)
            {
                yield return p;
            }
        }
    }

    public async IAsyncEnumerable<Person> GetAll(int skip, int take, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach (var file in Directory.GetFiles(_baseDir))
        {
            yield return JsonSerializer.Deserialize<Person>(File.ReadAllText(file))!;
        }
    }

    public async IAsyncEnumerable<Person> GetByBirthYear(DateTime birthDate, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach (var file in Directory.GetFiles(_baseDir))
        {
            var p = JsonSerializer.Deserialize<Person>(File.ReadAllText(file))!;
            if (p.BirthDate.Year == birthDate.Year)
            {
                yield return p;
            }
        }
    }

    public async IAsyncEnumerable<Person> GetByLastName(string lastName, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        foreach (var file in Directory.GetFiles(_baseDir))
        {
            var p = JsonSerializer.Deserialize<Person>(File.ReadAllText(file))!;
            if (p.LastName == lastName)
            {
                yield return p;
            }
        }
    }

    public Task Save(Person @object, CancellationToken cancellationToken)
    {
        _dataToAdd.Add(@object);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChanges(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        foreach (var p in _dataToDelete)
        {
            File.Delete(Path.Combine(_baseDir, p.Id.ToString()));
        }

        foreach (var p in _dataToUpdate)
        {
            File.WriteAllText(Path.Combine(_baseDir, p.Id.ToString()), JsonSerializer.Serialize(p));
        }

        foreach (var p in _dataToAdd)
        {
            File.WriteAllText(Path.Combine(_baseDir, p.Id.ToString()), JsonSerializer.Serialize(p));
        }

        return true;
    }

    public async Task Untrack(Person @object, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        _dataToDelete.Remove(@object);
        _dataToUpdate.Remove(@object);
        _dataToAdd.Remove(@object);
    }

    public async Task UntrackAll(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        _dataToDelete.Clear();
        _dataToUpdate.Clear();
        _dataToAdd.Clear();
    }

    public async Task Update(Person @object, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        _dataToUpdate.Add(@object);
    }
}
