using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DecompressTool
{
    public class FileHelp
    {
        public FileHelp()
        { }

        /// <summary>
        /// 从源文件夹路径中获取路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isContainSubFolder"></param>
        /// <returns></returns>
        public List<string> GetRarFiles(string path, bool isContainSubFolder)
        {
            List<string> rarFiles = new List<string>();
            List<string> rarfileNames = new List<string>();
            if (!Directory.Exists(path))
                return null;
            string[] fileNames;
            if (isContainSubFolder)
            {
                fileNames = Directory.GetFiles(path, "*.tar.gz", SearchOption.AllDirectories);
            }
            else
                fileNames = Directory.GetFiles(path, "*.tar.gz", SearchOption.TopDirectoryOnly);
            rarFiles.AddRange(fileNames);
            return rarFiles;
        }


    }
}
