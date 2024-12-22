using DataHandler.Library;

namespace DataHandler;

class Program
{
    static void Main(string[] args)
    {
        var records = ProcessData().Result;

        Console.WriteLine($"Успешно обработано: {records.Count()} записей");
        foreach (var person in records)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine("Нажми Enter для продолжения...");
        Console.ReadLine();
    }

    static async Task<IReadOnlyCollection<Person>> ProcessData()
    {
        var loader = new DataLoader();
        IReadOnlyCollection<string> data = loader.LoadData();

        var logger = new FileLogger();
        var handler = new DataHandler.Library.DataHandler(logger);
        var records = await handler.HandleData(data);
        return records;
    }
}