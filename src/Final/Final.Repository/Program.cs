// See https://aka.ms/new-console-template for more information


using Final.Repository;
using Final.Repository.Abstractions.Repositories;
using Final.Repository.Abstractions.UnitOfWork;
using Final.Repository.FileRepositories;
using Final.Repository.Repositories;
using System.Runtime.CompilerServices;

/////// This should be Depencency Injected



// Pick a IPeopleRepository
//var peopleRepository = new ListPeopleRepository(new Repository.Data.Example.ListExamplePeopleSource());
IPeopleRepository peopleRepository = new FilePeopleRepository();

ITodoRepository todoRepository = new ListTodoRepository(new Repository.Data.Example.ListExampleTodoSource());
ILaneRepository laneRepository = new ListLaneRepository(new Repository.Data.Example.ListExampleLaneSource());

await UpdateFirstDoe();

var lanes = laneRepository.GetAll(0, 100, default);

Console.WriteLine("Lanes:");

await foreach (var l in lanes)
{
    Console.WriteLine($"{l.Name} - {l.Index}:");

    var todos = todoRepository.GetTodosByLaneId(l.Id, default);
    await foreach (var t in todos)
    {
        var asignee = await peopleRepository.Get(t.AssigneeId?.ToString()!, default);
        string asigneeName = "Unassigned";
        if(asignee != null)
        {
            asigneeName = $"{asignee.FirstName} {asignee.LastName}";
        }
        Console.WriteLine($"\t{asigneeName}: {t.Title}");
    }
}

async Task UpdateFirstDoe()
{
    IUnitOfWork unitOfWork = new FakeUnitOfWork();
    await unitOfWork.Attach(peopleRepository, default);

    var firstDoe = await peopleRepository.Get("1", default);
    if (firstDoe != null)
    {
        firstDoe.FirstName = "Updated";
        await peopleRepository.Save(firstDoe, default);
    }
    await unitOfWork.CommitTransaction(default);
}