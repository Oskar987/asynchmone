using System.Configuration;

namespace DataHandler.Library;

public class FileLogger : ILogger
{
    private readonly string _logPath;

    public FileLogger()
    {
        var logFile = ConfigurationManager.AppSettings["LogLocation"];
        _logPath = AppDomain.CurrentDomain.BaseDirectory + logFile;

        using (var writer = new StreamWriter(_logPath, true))
        {
            writer.WriteLine("<==================>");
        }
    }

    public async Task LogMessage(string message, string data)
    {
        using var writer = new StreamWriter(_logPath, true);
        await writer.WriteLineAsync(
            $"{DateTime.Now:s}: {message} - {data}");
    }
}
