using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogAnalyzer
{
    class FileOperateLogBuilder
    {
        private readonly int logFieldCount = 8;
        private readonly string[] fieldSeparator = new string[] { "\",\"" };
        private readonly char[] charsToTrim = { '오', '전', '후', '"', ' ', '\t' };

        private enum FieldIndex
        {
            TimeOfDay = 0, ProcessName, ProcessId, ThreadId, OperationType, FilePath, Result, Detail
        }

        public bool Build(string rawLog, FileOperateLog newLog)
        {
            // 각 필드로 쪼개기 
            string[] fields = rawLog.Split(fieldSeparator, StringSplitOptions.None);

            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = fields[i].Trim(charsToTrim);
            }
            
            if (fields.Length < logFieldCount)
            {
                return false;
            }

            // 로그 구조화 
            newLog.TimeOfDay = fields[(int)FieldIndex.TimeOfDay];
            newLog.ThreadId = fields[(int)FieldIndex.ThreadId];
            newLog.Type = fields[(int)FieldIndex.OperationType];
            newLog.FilePath = fields[(int)FieldIndex.FilePath];
            newLog.Result = fields[(int)FieldIndex.Result];
            newLog.Detail = fields[(int)FieldIndex.Detail];

            return true;
        }
    }
}
