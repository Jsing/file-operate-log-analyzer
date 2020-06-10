using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogAnalyzer
{

    class TrackItemFactory
    {
        private enum FieldIndex
        {
            TimeOfDay = 0, ProcessName, ProcessId, ThreadId, OperationType, FilePath, Result, Detail
        }

        static public TrackOpenFileItem CreateTrackItem(string[] fields)
        {
            TrackOpenFileItem newTrackItem = new TrackOpenFileItem();
            
            newTrackItem.TimeOfDay = fields[(int)FieldIndex.TimeOfDay];
            newTrackItem.ThreadId = fields[(int)FieldIndex.ThreadId];
            newTrackItem.Type = fields[(int)FieldIndex.OperationType];
            newTrackItem.FilePath = fields[(int)FieldIndex.FilePath];
            newTrackItem.Result = fields[(int)FieldIndex.Result];
            newTrackItem.Detail = fields[(int)FieldIndex.Detail];

            return newTrackItem;
        }
    }
}
