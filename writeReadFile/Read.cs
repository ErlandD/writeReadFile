using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace writeReadFile
{
    public class Read
    {
        private String getPath(String fileName, String path)
        {
            if (path.IndexOf('\\') == -1)
            {
                String systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                path = Path.Combine(systemPath, path);
            }
            else if (path == "exe")
            {
                path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            }

            path += "\\" + fileName;
            return path;
        }
        public String readOne(String fileName, String path)
        {
            path = getPath(fileName, path);
            StreamReader sr = File.OpenText(path);
            String read = sr.ReadLine();
            sr.Close();
            return read;
        }
    }
}
