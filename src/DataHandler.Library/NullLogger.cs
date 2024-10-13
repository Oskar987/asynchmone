namespace DataHandler.Library;

public class NullLogger : ILogger
{
    public void LogMessage(string message, string data)
    {
        // не делает ничего
    }
}
