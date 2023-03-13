using System;
using System.Text;
using NexogenTransporeonTestProject.Enums;

namespace NexogenTransporeonTestProject.Classes
{
    public class StreamLogger : LogBase
    {
        private readonly Stream _stream;

        public StreamLogger(Stream stream)
        {
            _stream = stream;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter streamWriter = new StreamWriter(_stream);
            streamWriter.WriteLine(GetFormattedMessage(logLevel, message));
            streamWriter.Flush();
        }
    }
}

