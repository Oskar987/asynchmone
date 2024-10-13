namespace DataHandler.Library;

public class DataHandler
{
    private readonly ILogger _logger;

    public DataHandler(ILogger logger)
    {
        _logger = logger ?? new NullLogger();
    }

    public IReadOnlyCollection<Person> HandleData(IEnumerable<string> data)
    {
        var processedRecords = new List<Person>();
        foreach (var record in data)
        {
            var fields = record.Split(',');
            if (fields.Length != 6)
            {
                _logger.LogMessage("Неправильное количество полей в записи", record);
                continue;
            }

            int id;
            if (!Int32.TryParse(fields[0], out id))
            {
                _logger.LogMessage("Невозможно проанализировать поле Id", record);
                continue;
            }

            DateTime startDate;
            if (!DateTime.TryParse(fields[3], out startDate))
            {
                _logger.LogMessage("Невозможно проанализировать поле «Дата начала»", record);
                continue;
            }

            int rating;
            if (!Int32.TryParse(fields[4], out rating))
            {
                _logger.LogMessage("Невозможно проанализировать поле рейтинга", record);
                continue;
            }

            var person = new Person(id, fields[1], fields[2], 
                startDate, rating, fields[5]);

            // Успешно обработанная запись
            processedRecords.Add(person);
        }
        return processedRecords;
    }
}
