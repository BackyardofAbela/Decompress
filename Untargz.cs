using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;

namespace DecompressTool
{
    /// <summary>
    /// 解压targz格式的文件
    /// </summary>
    public class Untargz
    {
        public Untargz()
        { }

        /// <summary>
        /// 文件解压
        /// </summary>
        /// <param name="zipPath">压缩文件路径</param>
        /// <param name="goalFolder">解压到的目录</param>
        /// <returns></returns>
        public bool UnzipTgz(string zipPath, string goalFolder)
        {
            Stream inStream = null;
            Stream gzipStream = null;
            TarArchive tarArchive = null;
            try
            {
                using (inStream = File.OpenRead(zipPath))
                {
                    using (gzipStream = new GZipInputStream(inStream))
                    {
                        tarArchive = TarArchive.CreateInputTarArchive(gzipStream);
                        tarArchive.ExtractContents(goalFolder);
                        tarArchive.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("文件解压出错"+ex.Message);
                return false;
            }
            finally
            {
                if (null != tarArchive) tarArchive.Close();
                if (null != gzipStream) gzipStream.Close();
                if (null != inStream) inStream.Close();
            }
        }
    }
}
