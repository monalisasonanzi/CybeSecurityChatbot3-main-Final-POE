using System;
using System.Collections.Generic;

namespace CyberSecurityChatbot3.Services
{
    public class ActivityLogger
    {
        private List<string> logs = new List<string>();

        public void Log(string action)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            logs.Add("[" + time + "] " + action);
        }

        public List<string> GetLogs()
        {
            return logs;
        }
    }
}