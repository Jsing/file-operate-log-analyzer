using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogAnalyzer
{
    class FileChecker
    {
        public static bool IsTargetFileForAnalysis(string filePath, string operationResult, string detail)
        {
            // 파일이 아니면 분석 제외
            if (filePath.Contains(".") == false)
            {
                return false;
            }

            // DLL 및 EXE 파일 분석 제외 
            if (filePath.Contains(".dll") == true || filePath.Contains(".exe") == true)
            {
                return false;
            }

            // WINDOWS 파일 분석 제외
            if (filePath.Contains(@"C:\Windows\") == true)
            {
                return false;
            }

            // 파일 연산 결과 존재하지 않는 파일 경로이면 제외 
            if (operationResult.Contains("NAME NOT FOUND") == true)
            {
                return false;
            }

            // 파일 연산 결과 이름 충돌이 발생하였으면 제외
            if (operationResult.Contains("NAME COLLISION") == true)
            {
                return false;
            }

            return true;
        }
    }


}
