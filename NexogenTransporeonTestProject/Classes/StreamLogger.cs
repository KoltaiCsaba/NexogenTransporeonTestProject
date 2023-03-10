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
            _stream.Write(Encoding.UTF8.GetBytes(GetFormattedMessage(logLevel, message)));
        }
    }
}

