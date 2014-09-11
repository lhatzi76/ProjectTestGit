using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace eDoc_Operations
{
    class Logger
    {
        public void AddLogMessage(String strLogMessage)
        {
            String strFileName = "";

            strFileName = Path.Combine(System.Environment.CurrentDirectory, "LogError.txt");
            try
            {
                FileInfo fi = new FileInfo(strFileName);
                StreamWriter sw = fi.AppendText();

                sw.WriteLine(strLogMessage);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
