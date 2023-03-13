// See https://aka.ms/new-console-template for more information
using NexogenTransporeonTestProject.Classes;

Console.WriteLine("Testing the log library...");
Console.WriteLine("Testing the console logger...");
LogBase consoleLogger = new ConsoleLogger();
consoleLogger.Log(NexogenTransporeonTestProject.Enums.LogLevel.Debug, "This is a debug message.");
consoleLogger.Log(NexogenTransporeonTestProject.Enums.LogLevel.Info, "This is an info message.");
consoleLogger.Log(NexogenTransporeonTestProject.Enums.LogLevel.Error, "This is an error message.");
Console.WriteLine("Success.");
Console.WriteLine("Press enter to continue...");
Console.Read();

Console.WriteLine("Testing the file logger.");
LogBase fileLogger = new FileLogger("./");
fileLogger.Log(NexogenTransporeonTestProject.Enums.LogLevel.Debug, "This is a debug message.");
fileLogger.Log(NexogenTransporeonTestProject.Enums.LogLevel.Info, "This is an info message.");
fileLogger.Log(NexogenTransporeonTestProject.Enums.LogLevel.Error, "This is an error message.");
Console.WriteLine("Success.");
Console.WriteLine("Press enter to continue...");
Console.Read();

Console.WriteLine("Testing the stream logger.");
MemoryStream streamLog = new MemoryStream();
LogBase streamLogger = new StreamLogger(streamLog);
streamLogger.Log(NexogenTransporeonTestProject.Enums.LogLevel.Debug, "This is a debug message.");
streamLogger.Log(NexogenTransporeonTestProject.Enums.LogLevel.Info, "This is an info message.");
streamLogger.Log(NexogenTransporeonTestProject.Enums.LogLevel.Error, "This is an error message.");

using (StreamReader streamReader = new StreamReader(streamLog))
{
    streamLog.Position = 0;
    string? line;

    while ((line = streamReader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
};

Console.WriteLine("Success.");
Console.WriteLine("Press enter to exit...");
Console.Read();