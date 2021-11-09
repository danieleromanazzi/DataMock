using DataMock.Behaviors;
using DataMock.Configuration;
using DataMock.Console.Demo.Model;

namespace DataMock.Console.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO managed List of, example: .MockingData<List<Person>>()
            var persons = Activator.CreateMock.Configure()
                            .AddBehavior<StringBehavior>(new WordsBehavior() { Lenght = 5, Number = 2 })
                            .AddBehavior<CollectionBehavior>(new CollectionBehavior { Lenght = 3 })
                            .MockingData<Persons>();

            foreach (var person in persons.Items)
            {
                System.Console.WriteLine(person.ToString());
                System.Console.WriteLine("");
            }

            System.Console.ReadLine();
        }
    }
}
