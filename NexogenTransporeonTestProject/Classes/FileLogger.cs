using System;
using NexogenTransporeonTestProject.Enums;

namespace NexogenTransporeonTestProject.Classes
{
    public class FileLogger : LogBase
    {
        private readonly string _path;
        private readonly string _filePath;

        public FileLogger(string path)
        {
            _path = path;
            _filePath = _path + "log.txt";
        }

        public override void Log(LogLevel logLevel, string message)
        {
            RotateLogFiles();

            if (File.Exists(_filePath))
            {
                File.ReadAllLines(_filePath);
                File.AppendAllLines(_filePath, new List<string>() { GetFormattedMessage(logLevel, message) });
            }
            else
            {
                File.WriteAllLines(_filePath, new List<string>() { GetFormattedMessage(logLevel, message) });
            } 
        }

        public void RotateLogFiles()
        {
            DirectoryInfo d = new DirectoryInfo(_path);
            FileInfo[] files = d.GetFiles("*.txt");
            List<string> logFileNames = new List<string>();
            List<int> logFileIndexes = new List<int>();
            logFileNames = files.Where(x => x.Name.Contains("log")).Select(x => x.Name).ToList();
            logFileIndexes = logFileNames.Where(x => x.Split('.').Length > 2).Select(x => int.Parse(x.Split('.')[1])).ToList();
            int maxIndex = 0;
            long length = 0;

            if (logFileIndexes.Count() > 0)
            {
                maxIndex = logFileIndexes.Max();
            }

            if (File.Exists(_filePath))
            {
                length = new FileInfo(_filePath).Length;
            }

            if (length > 5000)
            {
                File.Move(_filePath, _path + String.Format("log.{0}.txt", maxIndex + 1));
            }
        }
    }
}

