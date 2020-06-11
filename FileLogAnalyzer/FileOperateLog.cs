using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogAnalyzer
{
    class FileOperateLog
    {
        public string TimeOfDay { get; set; }
        public string ThreadId { get; set; }
        public string Type { get; set; }
        public string FilePath { get; set; }
        public string Result { get; set; }
        public string Detail { get; set; }

        public FileOperateLog() { }

        public override string ToString()
        {
            return string.Format("TimeOfDay:{0},Type:{1},FilePath:{2},Result:{3},Detail:{4}",
                TimeOfDay, Type, FilePath, Result, Detail);
        }
    }
}
