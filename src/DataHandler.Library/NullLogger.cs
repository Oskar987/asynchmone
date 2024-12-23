namespace DataHandler.Library;

public class NullLogger : ILogger
{
    public async Task LogMessage(string message, string data)
    {
        // не делает ничего
        await Task.FromResult(0);
    }
}
