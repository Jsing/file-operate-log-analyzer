using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogAnalyzer
{
    class TrackOpenFileItem
    {
        public string TimeOfDay { get; set;  }
        public string ThreadId { get; set; }
        public string Type { get; set; }
        public string FilePath { get; set; }
        public string Result { get; set; }
        public string Detail { get; set; }
        public int OpenCount { get; set; }

        public TrackOpenFileItem()
        {
            OpenCount = 0;
        }

        public TrackOpenFileItem(string timeOfDay, string threadId, string type,
            string filePath, string result, string detail)
        {
            TimeOfDay = timeOfDay;
            ThreadId = threadId;
            Type = type;
            FilePath = filePath;
            Result = result;
            Detail = detail;
            OpenCount = 0;
        }

        public TrackOpenFileItem(string timeOfDay, string type, string filePath, string result, string detail)
        {
            TimeOfDay = timeOfDay;
            Type = type;
            FilePath = filePath;
            Result = result;
            Detail = detail;
            OpenCount = 0;
        }

        public override string ToString()
        {
            return string.Format("TimeOfDay:{0},Type:{1},FilePath:{2},Result:{3},Detail:{4},OpenCount:{5}",
                TimeOfDay, Type, FilePath, Result, Detail, OpenCount);
        }
    }
}
