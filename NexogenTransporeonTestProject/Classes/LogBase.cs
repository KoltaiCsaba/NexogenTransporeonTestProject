using System;
using NexogenTransporeonTestProject.Enums;

namespace NexogenTransporeonTestProject.Classes
{
	public abstract class LogBase
	{
		public abstract void Log(LogLevel logLevel, string message);

        public static string GetFormattedMessage(LogLevel logLevel, string message) => String.Format("{0} [{1}] {2}", DateTime.Now, logLevel, message);
    }
}

