﻿using System;
namespace DIExample.Services
{
    public class Logger
    {
        public void Log(string message, params string[] args)
        {
            string messageToLog = string.Format(message, args);

            Console.WriteLine(messageToLog);
        }
    }
}
