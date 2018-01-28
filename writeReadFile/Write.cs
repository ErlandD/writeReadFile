using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace writeReadFile
{
    public class Write
    {
        /// <summary>
        /// Write to file
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="text">Text inside the file</param>
        /// <param name="path">Where to save
        /// fill with "exe" if want to save where exe is
        /// "example" = save in C:\Documents and Settings\%USER NAME%\Application Data\example
        /// DO NOT use \ other than specified path!</param>
        /// <param name="type">1 = create or replace
        /// 2 = add at the end of file</param>
        public void write(String fileName, String text, String path, int type)
        {
            if (path.IndexOf('\\') == -1) {
                String systemPath = System.Environment. GetFolderPath( Environment.SpecialFolder.CommonApplicationData );
                path = Path.Combine(systemPath, path);
            }
            else if (path == "exe")
            {
                path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            }
            Directory.CreateDirectory(path);
            path += "\\" + fileName;
            if (type == 1)
            {
                StreamWriter sw = File.CreateText(path);
                sw.WriteLine(text);
                sw.Close();
            }
            else if (type == 2)
            {
                StreamWriter sw = File.AppendText(path);
                sw.WriteLine(text);
                sw.Close();
            }
        }
    }
}
