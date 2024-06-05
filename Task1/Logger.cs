using System;
using System.IO;


public class Logger
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}


public interface ILoggerAdapter
{
    void Log(string message);
    void Error(string message);
    void Warn(string message);
}


public class LoggerAdapter : ILoggerAdapter
{
    private Logger logger;
    private string logFilePath;

    public LoggerAdapter(Logger logger, string logFilePath)
    {
        this.logger = logger;
        this.logFilePath = logFilePath;
    }

    public void Log(string message)
    {
        logger.Log(message);
        WriteToFile("[LOG]: " + message);
    }

    public void Error(string message)
    {
        logger.Error(message);
        WriteToFile("[ERROR]: " + message);
    }

    public void Warn(string message)
    {
        logger.Warn(message);
        WriteToFile("[WARN]: " + message);
    }

    private void WriteToFile(string message)
    {
        
        File.AppendAllText(logFilePath, message + Environment.NewLine);
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        string logFilePath = "log.txt";

        
        var logger = new Logger();

        
        var loggerAdapter = new LoggerAdapter(logger, logFilePath);

        
        loggerAdapter.Log("Це повідомлення буде записано у файл та виведено у консоль");
        loggerAdapter.Error("Це повідомлення про помилку буде записано у файл та виведено у консоль");
        loggerAdapter.Warn("Це попередження буде записано у файл та виведено у консоль");
    }
}
