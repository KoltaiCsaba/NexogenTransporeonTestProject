using System;
using NexogenTransporeonTestProject.Enums;

namespace NexogenTransporeonTestProject.Classes
{
    public class ConsoleLogger : LogBase
    {
        public override void Log(LogLevel logLevel, string message)
        {
            if (message.Length > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(message), "Log message is too long. Log message should be no longer than 1000 characters");
            }

            switch (logLevel)
            {
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(GetFormattedMessage(logLevel, message));
                    break;
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(GetFormattedMessage(logLevel, message));
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(GetFormattedMessage(logLevel, message));
                    break;
                default:
                    break;
            }
        }
    }
}

