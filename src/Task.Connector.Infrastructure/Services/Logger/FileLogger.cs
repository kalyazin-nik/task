using System.Diagnostics;
using Microsoft.Extensions.Options;
using Task.Connector.Infrastructure.Common.DbModels;
using Task.Integration.Data.Models;

namespace Task.Connector.Infrastructure.Services.Logger;

public class FileLogger : ILogger
{
    private readonly string _fileName;
    private readonly string _connectorName;

    public FileLogger(IOptions<DbProvider> dbProvider)
    {
        _fileName = $"{DateTime.Now: dd.MM.yyyy}_Connector_{dbProvider.Value.Name ?? string.Empty}.Log";
        _connectorName = $"Connector:[{dbProvider.Value.Name ?? string.Empty}]:";
    }

    public FileLogger(string fileName, string connectorName)
    {
        _fileName = fileName;
        _connectorName = connectorName;
    }

    public void Debug(string message) => RunWhenDebugging(message);

    public void Error(string message) => Append($"[{DateTime.Now}]{null,2}[ERROR]{null,4}{_connectorName}{message}", ConsoleColor.Red);

    public void Warn(string message) => Append($"[{DateTime.Now}]{null,2}[WARNING]{null,2}{_connectorName}{message}", ConsoleColor.Yellow);

    [Conditional("DEBUG")]
    private void RunWhenDebugging(string message) => Append($"[{DateTime.Now}]{null,2}[DEBUG]{null,4}{_connectorName}{message}", ConsoleColor.Green);

    private void Append(string text, ConsoleColor color)
    {
        WriteToConsole(text, color);
        WriteToFile(text);
    }

    private static void WriteToConsole(string text, ConsoleColor color)
    {
        var defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = defaultColor;
    }

    private void WriteToFile(string text)
    {
        using var streamWriter = File.AppendText(_fileName);
        streamWriter.WriteLine(text);
    }
}
