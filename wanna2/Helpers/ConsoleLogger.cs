using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wanna2.Helpers
{
    
    public class ConsoleLogger
    {
        public static event AddLogDelegate AddLogEvent;

        private const string DATETIME_FORMAT = "yyyy-MM-dd][hh:mm:ss:fff";
        private const int CATEGORY_LENGHT = 10
                        , SECTION_LENGTH = 12;


        public LogLevel LogLevel { get; set; } = LogLevel.Verbose;

        public void LogMessage(string Category, string Section, string Message, LogLevel loglevel = LogLevel.Verbose)
        {
            if (LogLevel > loglevel)
                return;

            var UnformattedMessage = "[{0}][{1}][{2}] {3}";
            var FormattedMessage = string.Format(UnformattedMessage, DateTime.Now.ToString(DATETIME_FORMAT), Category.PadRight(CATEGORY_LENGHT), Section.PadRight(SECTION_LENGTH), Message);
            AddLogEvent?.Invoke(FormattedMessage);

            //    $"{DateTime.Now.ToString()}\t{Section}\t{Message}\t2\t{LoggedUser.Login}\n";
            //File.AppendAllText("log.txt", FormattedMessage);
        }
    }
}
