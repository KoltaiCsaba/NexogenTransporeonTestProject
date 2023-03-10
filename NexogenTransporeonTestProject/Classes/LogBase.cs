using System;
namespace NexogenTransporeonTestProject.Classes
{
	public abstract class LogBase
	{
		public abstract void LogDebug(string message);
		public abstract void LogInfo(string message);
		public abstract void LogError(string message);
	}
}

