using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogAnalyzer
{
    class TrackOpenFileItem
    {
        public string TimeOfDay { get; set; }
        public string ThreadId { get; set; }
        public string Type { get; set; }
        public string FilePath { get; set; }
        public string Result { get; set; }
        public string Detail { get; set; }
        public int OpenCount { get; set; }

        public TrackOpenFileItem(FileOperateLog log)
        {
            TimeOfDay = log.TimeOfDay;
            ThreadId = log.ThreadId;
            Type = log.Type;
            FilePath = log.FilePath;
            Result = log.Result;
            Detail = log.Detail;

            OpenCount = 1;
        }
        
        public string ToKeyString()
        {
            return string.Format("{0} / {1}", ThreadId, FilePath);
        }

        public override string ToString()
        {
            return string.Format("TimeOfDay:{0},ThreadId:{1},Type:{2},FilePath:{3},Result:{4},Detail:{5},OpenCount:{6}",
                TimeOfDay, ThreadId, Type, FilePath, Result, Detail, OpenCount);
        }
    }
}
