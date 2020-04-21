using System;
namespace DIExample.Services
{
    public interface ILogger
    {
        void Log(string message, params string[] args);
    }

    public class Logger : ILogger
    {
        public void Log(string message, params string[] args)
        {
            string messageToLog = string.Format(message, args);

            Console.WriteLine(messageToLog);
        }
    }
}
