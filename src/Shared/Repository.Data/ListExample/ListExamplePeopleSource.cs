using Repository.Data.Types;

namespace Repository.Data.Example;
public class ListExamplePeopleSource : List<Person>
{
    public ListExamplePeopleSource()
    {
        AddRange(
            [
            new Person() { Id = "1", FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1980, 1, 1) },
            new Person() { Id = "2", FirstName = "Jane", LastName = "Doe", BirthDate = new DateTime(1985, 1, 1) },
            new Person() { Id = "3", FirstName = "Alice", LastName = "Smith", BirthDate = new DateTime(1990, 1, 1) },
            new Person() { Id = "4", FirstName = "Bob", LastName = "Smith", BirthDate = new DateTime(1995, 1, 1) },
            new Person() { Id = "5", FirstName = "Charlie", LastName = "Brown", BirthDate = new DateTime(2000, 1, 1) }
            ]
        );
    }
}
