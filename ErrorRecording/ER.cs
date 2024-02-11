using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorRecording
{
    public class ER
    {
        private string path;

        /// <summary>
        /// Just write the path and don't write the file name. Do not put (\) at the end of the path.Example : C:\ali\pourmohammad  
        /// </summary>
        public string ERpath   
        {
            get { return path; }  
            set { path = value; }  
        }
        /// <summary>
        /// Error recording function . Remember to give directions . The error time is recorded automatically 
        /// </summary>
        /// <param name="ErrorCode">The error code can be arbitrary</param>
        /// <param name="Section">You can write the section or function or class where the error occurred. For example, the part of connecting to the database</param>
        /// <param name="Message">The error text is for you to know exactly what happened and provide a quick solution</param>
        public void ErrorRecord(string ErrorCode, string Section, string Message)
        {
            string dateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string newText = ErrorCode + " ; " + dateTimeString + " ; " + Section + " ; " + Message;
            ChechPath();
            using (StreamWriter sw = File.AppendText(path + "\\er.txt"))
            {
                sw.WriteLine();
                sw.WriteLine(newText);
            }
         
        }
        private void ChechPath()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path+"\\er.txt"))
            {
                File.Create(path+"\\er.txt");              
            }

        }
    }
}
