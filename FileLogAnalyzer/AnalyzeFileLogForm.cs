using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace FileLogAnalyzer
{

    public partial class AnalyzeFileLogForm : Form
    {
        private readonly string[] fieldSeparator = new string[] { "\",\"" };  
        private readonly char[] charsToTrim = { '오', '전', '후', '"', ' ', '\t' };

        public AnalyzeFileLogForm()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            Dictionary<String, TrackOpenFileItem> trackOpenFileDictionary = new Dictionary<string, TrackOpenFileItem>();
            StreamReader fileOperateLogReader = null;
            int maxOpenedCount = 0;

            // 로그 파일 전체 읽기
            //string logPath = GetLogPathFromUser();
            //if (logPath == null)
            //{
            //    return;
            //}
            string logPath = @"D:\Working\7.3m C&M Manage\이슈\서버 비정상 종료\로그\200610_K3A.CSV";

            logPathView.Text = "Log Path :" + logPath;

            // 로그 파일 구조화
            try
            {
                int hbmIndex = 0;
                int cbtwIndex = 0;
                int outputIndex = 0;

                fileOperateLogReader = new StreamReader(logPath);

                // Remove a first line as the header. 
                string line = fileOperateLogReader.ReadLine();

                while (fileOperateLogReader.Peek() >= 0)
                {

                    // 하나의 파일 연산 로그 읽기
                    line = fileOperateLogReader.ReadLine();

                    // 로그를 각 필드로 구분
                    string[] fields = line.Split(fieldSeparator, StringSplitOptions.None);

                    for (int i = 0; i < fields.Length; i++)
                    {
                        fields[i] = fields[i].Trim(charsToTrim);
                    }

                    if (fields.Length < 8)
                    {
                        continue;
                    }

                    // 열린 파일 추적 자료 생성
                    TrackOpenFileItem alreadyTrackItem;
                    TrackOpenFileItem newTrackItem = TrackItemFactory.CreateTrackItem(fields);
                    
                    if (!FileChecker.IsTargetFileForAnalysis(newTrackItem.FilePath, newTrackItem.Result, newTrackItem.Detail))
                    {
                        continue;
                    }

                    if (newTrackItem.Type == "CreateFile")
                    {
                        if (trackOpenFileDictionary.TryGetValue(newTrackItem.FilePath, out alreadyTrackItem) == true)
                        {

                            if (newTrackItem.ThreadId != alreadyTrackItem.ThreadId)
                            {
                                handledByMulithreadReport.AppendText("[ " + hbmIndex + " Open ]" + newTrackItem.FilePath + "\r\n");
                                hbmIndex++;
                            }

                            outputIndex++;
                            alreadyTrackItem.OpenCount++;
                            if (alreadyTrackItem.OpenCount > 1)
                            {
                                outputView.AppendText(outputIndex + " ] 2번 이상 열림 (" + newTrackItem.FilePath + " / " + alreadyTrackItem.OpenCount + " )" + "\r\n");
                            }

                        }
                        else
                        {
                            trackOpenFileDictionary.Add(newTrackItem.FilePath, newTrackItem);
                            newTrackItem.OpenCount++;


                            // 열린 파일 최대로 많은 경우 추적
                            if (trackOpenFileDictionary.Count > maxOpenedCount)
                            {
                                maxOpenedCount = trackOpenFileDictionary.Count;

                                // 열린 파일이 500개 이상이면 레포팅
                                if (maxOpenedCount > 500)
                                {
                                    outputView.AppendText("Opend File count is greater than 500 \r\n");
                                }
                            }

                        }


                    }
                    else if (newTrackItem.Type == "CloseFile")
                    {
                        if (trackOpenFileDictionary.TryGetValue(newTrackItem.FilePath, out alreadyTrackItem) == true)
                        {
                            if (newTrackItem.ThreadId != alreadyTrackItem.ThreadId)
                            {
                                handledByMulithreadReport.AppendText("[ " + hbmIndex + " Closed ]" + newTrackItem.FilePath + "\r\n");
                                hbmIndex++;
                            }

                            alreadyTrackItem.OpenCount--;
                            if (alreadyTrackItem.OpenCount <= 0)
                            {
                                trackOpenFileDictionary.Remove(newTrackItem.FilePath);
                            }
                        }
                        else
                        {
                            outputView.AppendText("열리지 않은 파일이 닫힘" + newTrackItem.ToString() + "\r\n");
                        }

                        if (trackOpenFileDictionary.Count > 500)
                        {
                            outputView.AppendText("Opend File count is greater than 500 \r\n");
                        }
                    }
                    else if (newTrackItem.Type == "WriteFile")
                    {
                        // 닫힌 파일에 대한 쓰기 시도 추적
                        if (trackOpenFileDictionary.TryGetValue(newTrackItem.FilePath, out alreadyTrackItem) == false)
                        {
                            closedButTryingWriteReport.AppendText("[ " + cbtwIndex + " ]" + newTrackItem.FilePath + "\r\n");
                            cbtwIndex++;
                        }
                        else
                        {
                            // 서로 다른 쓰레드에서 접근하는 파일 추적 
                            if (newTrackItem.ThreadId != alreadyTrackItem.ThreadId)
                            {
                                handledByMulithreadReport.AppendText("[ " + hbmIndex + " ]" + newTrackItem.FilePath + "\r\n");
                                hbmIndex++;
                            }
                        }
                    }
                    else
                    {

                    }

                }

            }
            catch (Exception exception)
            {
                Console.WriteLine("The process failed: {0}", exception.ToString());
            }
            finally
            {
                if (fileOperateLogReader != null)
                {
                    fileOperateLogReader.Dispose();
                }

                outputView.AppendText("Opend File count is " + trackOpenFileDictionary.Count + "," + maxOpenedCount + "\r\n");
            }

            int index = 1;

            foreach(var item in trackOpenFileDictionary.ToList())
            {
                opendButNotClosedReporter.AppendText("[ " + index + " ]" + item.Value.FilePath + "\r\n");
                index++;
            }


        }

        private string GetLogPathFromUser()
        {
            string fileContent = string.Empty;
            string filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"D:\Working\7.3m C&M Manage\이슈\서버 비정상 종료\로그";
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    return openFileDialog.FileName;
                }
                else
                {
                    return null;
                }
            }
        }


        private void btClearView_Click(object sender, EventArgs e)
        {
            outputView.Clear();
            closedButTryingWriteReport.Clear();
            handledByMulithreadReport.Clear();
            opendButNotClosedReporter.Clear();
        }
    }
}
