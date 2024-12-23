namespace DataHandler.Library;

public interface ILogger
{
    Task LogMessage(string message, string data);
}