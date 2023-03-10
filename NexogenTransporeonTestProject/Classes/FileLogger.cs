using System;
using NexogenTransporeonTestProject.Enums;

namespace NexogenTransporeonTestProject.Classes
{
    public class FileLogger : LogBase
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            DirectoryInfo d = new DirectoryInfo(_path);
            FileInfo[] files = d.GetFiles("*.txt");
            List<string> logFileNames = new List<string>();
            List<int> logFileIndexes = new List<int>();
            logFileNames = files.Where(x => x.Name.Contains("log")).Select(x => x.Name).ToList();
            logFileIndexes = logFileNames.Where(x => x.Split('.').Length > 2).Select(x => int.Parse(x.Split('.')[1])).ToList();
            int maxIndex = logFileIndexes.Max();
            string filePath = _path + "log.txt";
            long length = new FileInfo(filePath).Length;

            if (length > 5000)
            {
                File.Move(filePath, _path + String.Format("log.{0}.txt", maxIndex + 1));
            }

            using (StreamWriter streamWriter = new StreamWriter(_path + "log.txt"))
            {
                streamWriter.WriteLine(GetFormattedMessage(logLevel, message));
                streamWriter.Close();
            }
        }
    }
}

