using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;

using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;

namespace DecompressTool
{
    public partial class FrmDecompress : Form
    {
        private bool isContainSubFloder = true;
        private bool isCreateRARFolder = true;
        private bool isDelSourceFile = false;//解压成功后的源文件（压缩文件是否删除）
        private FileHelp fileHelp;
        List<string> SelectedRARfiles;//存放选中的文件
        
        public FrmDecompress()
        {
            InitializeComponent();
            SelectedRARfiles = new List<string>();
        }

        /// <summary>
        /// 选择源文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSource_Click(object sender, EventArgs e)
        {
            
            //判断是否选择子文件夹
            if (this.IsContainSubfolder.Checked)
                isContainSubFloder = true;
            else
                isContainSubFloder = false;
            
            //选择源文件夹
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                
                if(folder.ShowDialog()==DialogResult.OK)
                {
                    string sourcepath=folder.SelectedPath;
                    this.tbxSource.Text = sourcepath;
                    fileHelp = new FileHelp();
                    SelectedRARfiles = fileHelp.GetRarFiles(sourcepath, isContainSubFloder);                    
                    InitFileList();
                } 
            }

        }

        /// <summary>
        /// 文件列表初始化(相同文件名的应提示重复文件)
        /// </summary>
        private void InitFileList()
        {
            FileList.BeginUpdate();
            FileList.Items.Clear();
            if (SelectedRARfiles == null || SelectedRARfiles.Count == 0)
            {
                FileList.EndUpdate();
                return;
            }
            else
            {
                foreach (string RARFile in SelectedRARfiles)
                {
                    string fileName = Path.GetFileName(RARFile);
                    ListViewItem item = new ListViewItem(fileName);
                    item.SubItems.Add(File.GetCreationTime(RARFile).ToString("yyyyMMdd hh:mm"));
                    item.SubItems.Add("...");
                    item.Checked = true;
                    FileList.Items.Add(item);
                }
                FileList.EndUpdate();
            }
        }

        /// <summary>
        /// 选择解压文件输出路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTarget_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    string targetpath = folder.SelectedPath;
                    this.tbxTarget.Text = targetpath;     
                }
            }
        }

        /// <summary>
        /// 选择矢量文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnshp_Click(object sender, EventArgs e)
        {

        }
   

        /// <summary>
        /// 是否包含子文件夹中的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsContainSubfolder_CheckedChanged(object sender, EventArgs e)
        {
            if (IsContainSubfolder.Checked)
                isContainSubFloder = true;
            else
                isContainSubFloder = false;
            string path = this.tbxSource.Text;
            if (!Directory.Exists(path))
            {
                MessageBox.Show("请选择源文件夹！");
                return;
            }
            fileHelp = new FileHelp();
            SelectedRARfiles = fileHelp.GetRarFiles(path, isContainSubFloder);
            InitFileList();
        }

        private void IsCreateRARFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsCreateRARFolder.Checked)
                isCreateRARFolder = true;
            else
                isCreateRARFolder = false;
        }

        private void IsDelRARFile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxDelSourceFile.Checked)
                isDelSourceFile = true;
            else
                isDelSourceFile = false;
        }

        /// <summary>
        /// 获取文件列表中选中的文件信息
        /// </summary>
        /// <returns></returns>
        private Hashtable GetSelectedFiles()
        {            
            Hashtable ht = new Hashtable(FileList.CheckedItems.Count);
            foreach (ListViewItem item in FileList.CheckedItems)
                ht.Add(item.Text, item);
            return ht;
        }

        private Unrar unrar;
        private Untargz untargz;
        private RARDecompress rarDecompress=new RARDecompress();
        int value = 0;//解压进度的值
        Hashtable selectedFiles;//选中的文件
        string PresentFile;//当前处理文件

        /// <summary>
        /// 解压选中的文件,点击解压按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecompress_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbxSource.Text))
            {
                MessageBox.Show("请选择要解压的文件夹！");
                return;
            }
            if (string.IsNullOrEmpty(this.tbxTarget.Text))
            {
                MessageBox.Show("请选择目标文件夹！");
                return;
            }
            selectedFiles = GetSelectedFiles();
            this.progressBar1.Maximum = selectedFiles.Count;
            this.progressBar1.Minimum = 0;
            value = 0;
            Worker.RunWorkerAsync();//调用后台处理

         
                #region 未进行后台处理的解压代码
                //try
                //{                    
                //    foundItem.SubItems[2].Text = "解压中";
                //    if (Path.GetExtension(fileName).Contains("rar"))
                //    {
                //        unrar = new Unrar();
                //        AttachHandlers(unrar);
                //        if (!isCreateRARFolder)
                //            unrar.DestinationPath = directory;
                //        else
                //            unrar.DestinationPath = directory + "\\" + fileName;
                //        unrar.Open(file, Unrar.OpenMode.Extract);
                //        while (unrar.ReadHeader())
                //        {
                //            if (selectedFiles.ContainsKey(fileName))
                //            {

                //                unrar.Extract();
                //                foundItem.SubItems[2].Text = "解压成功";
                //                //解压成功，删除源文件
                //                if (isDelSourceFile)
                //                    File.Delete(file);
                //            }
                //            else
                //            {
                //                unrar.Skip();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        untargz = new Ustring DestinationPath=directory;
                //        if (isCreateRARFolder)
                //            DestinationPath = directory + "\\" + fileName;

                //        if(untargz.UnzipTgz(file, DestinationPath))ntargz();
                //        foundItem.SubItems[2].Text = "解压中";
                //        
                //            foundItem.SubItems[2].Text = "解压成功";
                //        else
                //            foundItem.SubItems[2].Text = "解压失败";

                //    }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    foundItem.SubItems[2].Text = "解压失败";
                //}
               //finally
                //{
                //    this.progressBar1.Value+=(int)(100 / selectedFiles.Count);                    
                //    if (this.unrar != null)
                //        unrar.Close();
                //}
                #endregion


        }


        /// <summary>
        /// BackgroundWorker后台执行程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {                
                string directory = this.tbxTarget.Text;
                foreach (string file in SelectedRARfiles)//文件夹中的所有文件
                {
                    if (!File.Exists(file))
                    {
                        MessageBox.Show("文件不存在！" + file);
                        continue;
                    }
                    string fileName = Path.GetFileName(file);
                    if (selectedFiles.ContainsKey(fileName))
                    {

                        //是否创建压缩文件的文件夹
                        string DestinationPath = directory;
                        PresentFile = fileName;
                        if (isCreateRARFolder)
                        {
                            DestinationPath = directory + "\\" + fileName;
                            if (Directory.Exists(DestinationPath))
                            {
                                //判断文件夹中的文件个数，弹出对话框供用户选择操作流程
                                int fileNum = Directory.GetFiles(DestinationPath).Length;
                                if (fileNum > 0)
                                {
                                    FrmSameFile frmSameFile = new FrmSameFile();
                                    frmSameFile.DirName = DestinationPath;
                                    frmSameFile.ShowDialog();
                                    if (frmSameFile.ProcessMode == SameNameFileProcessMode.ReName)
                                    {
                                        // 将目标文件夹重命名
                                        DestinationPath = frmSameFile.ReNameDir;
                                    }
                                    else if (frmSameFile.ProcessMode == SameNameFileProcessMode.Replace)
                                    {
                                        //删除文件夹中的所有文件
                                        Directory.GetFiles(DestinationPath).ToList().ForEach(File.Delete);
                                    }
                                    else
                                    //默认跳过文件不进行处理
                                    {
                                        if (Worker.WorkerReportsProgress)
                                        {
                                            if (value == selectedFiles.Count)
                                            {
                                                value = 0;
                                            }
                                            value += 1;
                                            Worker.ReportProgress(value, "跳过");
                                        }
                                        if (isDelSourceFile)
                                            File.Delete(file);
                                        continue;
                                    }

                                }
                            }
                            else
                                Directory.CreateDirectory(DestinationPath);
                        }
                        if (Worker.WorkerReportsProgress)
                        {
                            Worker.ReportProgress(value, "正在解压");
                        }
                        UnzipTgz(file, DestinationPath);
                        if (Worker.WorkerReportsProgress)
                        {
                            if (value == selectedFiles.Count)
                            {
                                value = 0;
                            }
                            value += 1;
                            Worker.ReportProgress(value, "解压成功");
                        }
                        if (isDelSourceFile)
                            File.Delete(file);
                        Thread.Sleep(1000);
                    }
                    else
                        continue;
                }
            }
            catch (Exception ex)
            {
                if (Worker.WorkerReportsProgress)
                {
                    if (value == selectedFiles.Count)
                    {
                        value = 0;
                    }
                    value += 1;
                    Worker.ReportProgress(value, "解压失败");
                }
            }
            finally
            {
                Worker.CancelAsync();//取消后台操作
            }               

        }

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
                Console.WriteLine("文件解压出错" + ex.Message);
                return false;
            }
            finally
            {
                if (null != tarArchive) tarArchive.Close();
                if (null != gzipStream) gzipStream.Close();
                if (null != inStream) inStream.Close();
            }
        }

        #region RAR解压
        private void AttachHandlers(Unrar unrar)
        {
            unrar.ExtractionProgress += new ExtractionProgressHandler(unrar_ExtractionProgress);
            unrar.MissingVolume += new MissingVolumeHandler(unrar_MissingVolume);
            unrar.PasswordRequired += new PasswordRequiredHandler(unrar_PasswordRequired);
        }

   
        private void unrar_ExtractionProgress(object sender, ExtractionProgressEventArgs e)
        {
             this.progressBar1.Value = (int)e.PercentComplete;
        }

        public void unrar_MissingVolume(object sender, MissingVolumeEventArgs e)
        {
            FrmTextInput dialog = new FrmTextInput();
            dialog.Value = e.VolumeName;
            dialog.Prompt = string.Format("信息丢失，继续或取消.");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                e.VolumeName = dialog.Value;
                e.ContinueOperation = true;
            }
            else
                e.ContinueOperation = false;
        }

        private void unrar_PasswordRequired(object sender, PasswordRequiredEventArgs e)
        {
            FrmTextInput dialog = new FrmTextInput();
            dialog.Prompt = string.Format("请输入密码");
            dialog.PasswordChar = '*';
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                e.Password = dialog.Value;
                e.ContinueOperation = true;
            }
            else
                e.ContinueOperation = false;
        }
        #endregion

        private void FrmDecompress_Load(object sender, EventArgs e)
        {
            Worker.WorkerSupportsCancellation = true;//是否支持异步取消
            Worker.WorkerReportsProgress = true;//报告进度更新
            Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            Worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
        }

        /// <summary>
        /// 进度条展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ListViewItem foundItem = FileList.FindItemWithText(PresentFile, false, 0);
            foundItem.SubItems[2].Text = e.UserState.ToString();
            this.progressBar1.Value = e.ProgressPercentage;           
        }

 
    }
}
